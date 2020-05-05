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
                //material is stored as element id
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


        enum ViewsFromDirection { LEFT_RIGHT, BACK_FROUNT, PLAN_CELING }

        public static void GetReferencePlanes(FamilyTemplate famTemplate, Document doc)
        {
            if (doc != null)
            {
                if (famTemplate.RefferencePlaneItems.Count <= 0)
                {
                    List<Element> referencePlaneElementList = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.ReferencePlane)).ToElements() as List<Element>;
                    foreach (Element element in referencePlaneElementList)
                    {
                        Autodesk.Revit.DB.ReferencePlane plane = (Autodesk.Revit.DB.ReferencePlane)element as Autodesk.Revit.DB.ReferencePlane;
                        ModBox.FamFactory.Revit.Manager.ReferencePlane refPlane = ReferencePlane.NewReferencePlane(famTemplate.FamilyTemplateReferencePlanesView);
                        refPlane.Name = plane.Name;
                        refPlane.FamiltyTemplateId = famTemplate.Id;
                        refPlane.ElementId = plane.Id.IntegerValue;
                        refPlane.UniqueId = plane.UniqueId;
                        refPlane.LevelId = plane.LevelId.IntegerValue;
                        refPlane.ViewId = plane.OwnerViewId.IntegerValue;
                        refPlane.Category = plane.Category.Name;
                        refPlane.DirectionX = plane.Direction.X;
                        refPlane.DirectionY = plane.Direction.Y;
                        refPlane.DirectionZ = plane.Direction.Z;
                        refPlane.BubbleEndX = plane.BubbleEnd.X;
                        refPlane.BubbleEndY = plane.BubbleEnd.Y;
                        refPlane.BubbleEndZ = plane.BubbleEnd.Z;
                        refPlane.NormalX = plane.Normal.X;
                        refPlane.NormalY = plane.Normal.Y;
                        refPlane.NormalZ = plane.Normal.Z;
                        refPlane.FreeEndX = plane.FreeEnd.X;
                        refPlane.FreeEndY = plane.FreeEnd.Y;
                        refPlane.FreeEndZ = plane.FreeEnd.Z;
                        refPlane.IsActive = true;
                        refPlane.EndEdit();
                    }
                }
                else
                {

                }
            }
        }

        public static void GetParameters(FamilyTemplate famTemplate, Document doc)
        {
            if (famTemplate.ParameterItems.Count <= 0)
            {
                //Autodesk.Revit.DB.Category category;
                foreach (Autodesk.Revit.DB.FamilyParameter item in doc.FamilyManager.Parameters)
                {
                    Parameter parameter = Parameter.newParameter(famTemplate.FamilyTemplateParametersView);
                    parameter.FamilyTemplateId = famTemplate.Id;
                    parameter.Name = item.Definition.Name;
                    parameter.ElementId = item.Id.IntegerValue;
                    parameter.IsShared = item.IsShared;
                    if (parameter.IsShared)
                        parameter.ElementGUID = item.GUID.ToString();
                    else
                        parameter.ElementGUID = string.Empty;
                    parameter.HasValue = false;
                    parameter.IsInstance = item.IsInstance;
                    parameter.IsReadOnly = item.IsReadOnly;
                    parameter.IsReporting = item.IsReporting;
                    parameter.StorageType = (int)item.StorageType;
                    parameter.BuiltInParamGroup = (int)item.Definition.ParameterGroup;
                    parameter.ParameterType = (int)item.Definition.ParameterType;
                    parameter.UnitType = (int)item.Definition.UnitType;

                    try
                    {
                        parameter.DisplayUnitType = (int)item.DisplayUnitType;
                    }
                    catch (Exception e)
                    {
                        parameter.DisplayUnitType = (int)Autodesk.Revit.DB.DisplayUnitType.DUT_UNDEFINED;
                    }

                    parameter.UserModifiable = item.UserModifiable;
                    parameter.IsDeterminedByFormula = item.IsDeterminedByFormula;
                    parameter.Formula = item.Formula;
                    parameter.IsActive = false;
                    parameter.IsEditable = true;
                    parameter.EndEdit();
                }
            }
        }

        public static void GetFamilyFeatures(FamilyTemplate famTemplate, Document doc)
        {
            if (famTemplate.FamilyGeometryItems.Count <= 0)
            {
                if (doc != null)
                {
                    List<Element> sweepElementList = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.Sweep)).ToElements() as List<Element>;
                    List<Element> extrudeElementList = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.Extrusion)).ToElements() as List<Element>;
                    List<Element> blendElementList = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.Blend)).ToElements() as List<Element>;
                    List<Element> sweptBlendElementList = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.SweptBlend)).ToElements() as List<Element>;
                    List<Element> revolveElementList = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.Revolution)).ToElements() as List<Element>;

                    foreach (Element element in sweepElementList)
                    {
                        Autodesk.Revit.DB.Sweep sweep = (Autodesk.Revit.DB.Sweep)element as Autodesk.Revit.DB.Sweep;
                        FamilyGeometry familyGeometry = FamilyGeometry.NewFamilyGeometry(famTemplate.FamilyTemplateGeometryView);
                        familyGeometry.Name = sweep.Name;
                        familyGeometry.ElementId = sweep.Id.IntegerValue;
                        familyGeometry.Description = string.Empty;
                        familyGeometry.Category = sweep.Category.Name;
                        familyGeometry.SubCategory = sweep.Subcategory.Name;
                        familyGeometry.FamilyTemplateId = famTemplate.Id;
                        familyGeometry.GeometryType = "Sweep";
                        familyGeometry.UniqueId = sweep.UniqueId;
                        familyGeometry.OwnerViewId = sweep.OwnerViewId.IntegerValue;
                        familyGeometry.LevelId = sweep.LevelId.IntegerValue;
                        familyGeometry.IsSolid = sweep.IsSolid;
                        familyGeometry.MaterialId = 0;
                        familyGeometry.EndEdit();
                    }

                    foreach (Element element in extrudeElementList)
                    {
                        Autodesk.Revit.DB.Extrusion extrude = (Autodesk.Revit.DB.Extrusion)element as Autodesk.Revit.DB.Extrusion;
                        FamilyGeometry familyGeometry = FamilyGeometry.NewFamilyGeometry(famTemplate.FamilyTemplateGeometryView);
                        familyGeometry.Name = extrude.Name;
                        familyGeometry.ElementId = extrude.Id.IntegerValue;
                        familyGeometry.Description = string.Empty;
                        familyGeometry.Category = extrude.Category.Name;
                        familyGeometry.SubCategory = extrude.Subcategory.Name;
                        familyGeometry.FamilyTemplateId = famTemplate.Id;
                        familyGeometry.GeometryType = "Extrusion";
                        familyGeometry.UniqueId = extrude.UniqueId;
                        familyGeometry.OwnerViewId = extrude.OwnerViewId.IntegerValue;
                        familyGeometry.LevelId = extrude.LevelId.IntegerValue;
                        familyGeometry.IsSolid = extrude.IsSolid;
                        familyGeometry.MaterialId = 0;
                        familyGeometry.EndEdit();
                    }
                    foreach (Element element in blendElementList)
                    {
                        Autodesk.Revit.DB.Blend blend = (Autodesk.Revit.DB.Blend)element as Autodesk.Revit.DB.Blend;
                        FamilyGeometry familyGeometry = FamilyGeometry.NewFamilyGeometry(famTemplate.FamilyTemplateGeometryView);
                        familyGeometry.Name = blend.Name;
                        familyGeometry.ElementId = blend.Id.IntegerValue;
                        familyGeometry.Description = string.Empty;
                        familyGeometry.Category = blend.Category.Name;
                        familyGeometry.SubCategory = blend.Subcategory.Name;
                        familyGeometry.FamilyTemplateId = famTemplate.Id;
                        familyGeometry.GeometryType = "Blend";
                        familyGeometry.UniqueId = blend.UniqueId;
                        familyGeometry.OwnerViewId = blend.OwnerViewId.IntegerValue;
                        familyGeometry.LevelId = blend.LevelId.IntegerValue;
                        familyGeometry.IsSolid = blend.IsSolid;
                        familyGeometry.MaterialId = 0;
                        familyGeometry.EndEdit();
                    }
                    foreach (Element element in sweptBlendElementList)
                    {
                        Autodesk.Revit.DB.SweptBlend weptblend = (Autodesk.Revit.DB.SweptBlend)element as Autodesk.Revit.DB.SweptBlend;
                        FamilyGeometry familyGeometry = FamilyGeometry.NewFamilyGeometry(famTemplate.FamilyTemplateGeometryView);
                        familyGeometry.Name = weptblend.Name;
                        familyGeometry.ElementId = weptblend.Id.IntegerValue;
                        familyGeometry.Description = string.Empty;
                        familyGeometry.Category = weptblend.Category.Name;
                        familyGeometry.SubCategory = weptblend.Subcategory.Name;
                        familyGeometry.FamilyTemplateId = famTemplate.Id;
                        familyGeometry.GeometryType = "SweptBlend";
                        familyGeometry.UniqueId = weptblend.UniqueId;
                        familyGeometry.OwnerViewId = weptblend.OwnerViewId.IntegerValue;
                        familyGeometry.LevelId = weptblend.LevelId.IntegerValue;
                        familyGeometry.IsSolid = weptblend.IsSolid;
                        familyGeometry.MaterialId = 0;
                        familyGeometry.EndEdit();
                    }
                    foreach (Element element in revolveElementList)
                    {
                        Autodesk.Revit.DB.Revolution revolve = (Autodesk.Revit.DB.Revolution)element as Autodesk.Revit.DB.Revolution;
                        FamilyGeometry familyGeometry = FamilyGeometry.NewFamilyGeometry(famTemplate.FamilyTemplateGeometryView);
                        familyGeometry.Name = revolve.Name;
                        familyGeometry.ElementId = revolve.Id.IntegerValue;
                        familyGeometry.Description = string.Empty;
                        familyGeometry.Category = revolve.Category.Name;
                        familyGeometry.SubCategory = revolve.Subcategory.Name;
                        familyGeometry.FamilyTemplateId = famTemplate.Id;
                        familyGeometry.GeometryType = "Revolution";
                        familyGeometry.UniqueId = revolve.UniqueId;
                        familyGeometry.OwnerViewId = revolve.OwnerViewId.IntegerValue;
                        familyGeometry.LevelId = revolve.LevelId.IntegerValue;
                        familyGeometry.IsSolid = revolve.IsSolid;
                        familyGeometry.MaterialId = 0;
                        familyGeometry.EndEdit();
                    }
                }
            }
            else
            {

            }
        }
    }
}
