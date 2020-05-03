using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace ModBox.FamFactory.Revit.Manager
{
    public static class Utils
    {
        public static byte[] ImageToByte(Image imageToconvert)
        {
            MemoryStream memoryStream = new MemoryStream();
            imageToconvert.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] bytesOfImage = memoryStream.ToArray();
            return bytesOfImage;
        }

        public static Image ByteToImage(byte[] toConvert)
        {
            MemoryStream toImage = new MemoryStream(toConvert);
            Image imageFromBytes = Image.FromStream(toImage);
            return imageFromBytes;
        }

        public static string GetPasswordHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool VerifyPasswordHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetPasswordHash(hashAlgorithm, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }

        public static byte[] FileToByteArray(string path)
        {
            long FileSize;
            byte[] rawData;
            FileStream fs;
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                FileSize = fs.Length;
                rawData = new byte[FileSize];
                fs.Read(rawData, 0, Convert.ToInt32(FileSize));
                fs.Close();
                return rawData;
            }
            catch (Exception e)
            {
                throw new Exception("Error Converting file to Byte[]", e);
            }
        }

        public static bool ByteArrayToFile(string filePath, byte[] file)
        {
            FileStream fs;

            try
            {
                fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Write(file, 0, file.Length);
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Converting Byte[] to File on disk.", ex);
            }
        }

        public static bool CopyToCache(byte[] famFile, string destinationPath)
        {
            try
            {
                FileInfo file = new FileInfo(destinationPath);
                if (file.Exists)
                    return true;
                else
                {
                    ByteArrayToFile(destinationPath, famFile);
                    if (file.Exists)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Copying to cahce folder.", ex);
            }
        }

        public static byte[] ThumbnailFromView(User user, string fileName, byte[] item, Autodesk.Revit.ApplicationServices.Application app, string previewview)
        {
            Document doc;
            FileInfo famfile = new FileInfo(fileName);

            if (famfile.Extension.Contains("rft"))
                doc = app.NewFamilyDocument(fileName);
            else
                doc = app.OpenDocumentFile(fileName);

            string ext = ".png";
            if (doc != null)
            {
                byte[] returnbytes = null;
                FilteredElementCollector views = new FilteredElementCollector(doc).OfClass(typeof(View));
                foreach (View view in views)
                {
                    if (view.IsTemplate) continue;
                    IList<ElementId> ImageExportList = new List<ElementId>();
                    if (view.Name == previewview)
                    {
                        ImageExportList.Clear();
                        ImageExportList.Add(view.Id);
                        string tempThumbnail = Guid.NewGuid().ToString().Replace("-", "");
                        var BilledeExportOptions_3D_PNG = new ImageExportOptions
                        {
                            ZoomType = ZoomFitType.FitToPage,
                            PixelSize = 1024,
                            FilePath = user.TempFolder + "\\" + tempThumbnail + ext,
                            FitDirection = FitDirectionType.Horizontal,
                            HLRandWFViewsFileType = ImageFileType.JPEGLossless,
                            ShadowViewsFileType = ImageFileType.JPEGLossless,
                            ImageResolution = ImageResolution.DPI_600,
                            ExportRange = ExportRange.SetOfViews
                        };
                        BilledeExportOptions_3D_PNG.SetViewsAndSheets(ImageExportList);

                        doc.ExportImage(BilledeExportOptions_3D_PNG);
                        Thread.Sleep(100);

                        DirectoryInfo directory = new DirectoryInfo(user.TempFolder);
                        foreach (FileInfo file in directory.GetFiles())
                        {
                            string name = file.Name.Substring(0, file.Name.IndexOf('.'));

                            if (name.Length > tempThumbnail.Length)
                                name = file.Name.Substring(0, file.Name.IndexOf(' '));

                            if (file.Name.Contains(tempThumbnail))
                            {
                                file.MoveTo(user.TempFolder + "\\" + tempThumbnail + ext);
                                break;
                            }
                        }
                        returnbytes = FileToByteArray(user.TempFolder + "\\" + tempThumbnail + ext);
                        break;
                    }
                }
                doc.Close(false);
                return returnbytes;
            }
            return
                new byte[0];
        }

        public static string FullCacheFilePath(User user, string Filename, string cacheName)
        {
            string familyEncryptedName = cacheName;
            string CahceLocation = user.TempFolder;
            return CahceLocation + "\\" + familyEncryptedName + Filename.Substring(Filename.LastIndexOf('.'), Filename.Length - Filename.LastIndexOf('.'));
        }

        public static string GetMaterialName(Document document, Element element)
        {
            string returnString = string.Empty;
            foreach (Autodesk.Revit.DB.Parameter parameter in element.Parameters)
            {
                Definition definition = parameter.Definition;
                // material is stored as element id
                if (parameter.StorageType == StorageType.ElementId)
                {
                    if (definition.ParameterGroup == BuiltInParameterGroup.PG_MATERIALS && definition.ParameterType == ParameterType.Material)
                    {
                        Autodesk.Revit.DB.Material material = null;
                        Autodesk.Revit.DB.ElementId materialId = parameter.AsElementId();
                        if (-1 == materialId.IntegerValue)
                        {
                            //Invalid ElementId, assume the material is "By Category"
                            returnString = "<ByCategory>";
                        }
                        else
                        {
                            material = document.GetElement(materialId) as Material;
                            returnString = material.Name;
                        }
                    }
                }
            }
            return returnString;
        }
        public static Material GetMaterial(Document document, Element element)
        {
            Autodesk.Revit.DB.Material material = null;
            foreach (Autodesk.Revit.DB.Parameter parameter in element.Parameters)
            {
                Definition definition = parameter.Definition;
                // material is stored as element id
                if (parameter.StorageType == StorageType.ElementId)
                {
                    if (definition.ParameterGroup == BuiltInParameterGroup.PG_MATERIALS &&
                            definition.ParameterType == ParameterType.Material)
                    {

                        Autodesk.Revit.DB.ElementId materialId = parameter.AsElementId();
                        if (-1 == materialId.IntegerValue)
                        {
                            //Invalid ElementId, assume the material is "By Category"
                            if (null != element.Category)
                            {
                                material = element.Category.Material;
                            }
                        }
                        else
                        {
                            material = document.GetElement(materialId) as Material;
                        }
                        break;
                    }
                }
            }
            return material;
        }
    }
}
