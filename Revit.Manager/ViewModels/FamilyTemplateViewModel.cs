using ModBox.FamFactory.Revit.Manager.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyTemplatesViewModel : ViewModelBase<FamilyTemplate>
    {
        DataView TemplateDataView;
        public FamilyTemplatesViewModel(DataSet dataset) : base(dataset)
        {
            TemplateDataView = InternalDataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].DefaultView; 
            RefreshCollection();
        }
        public FamilyTemplatesViewModel(DataSet dataset, object application) : base(dataset, application)
        {
            TemplateDataView = InternalDataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].DefaultView;
            RefreshCollection();
        }

        private void RefreshCollection()
        {
            if (InternalCollection != null)
            {
                InternalCollection.Clear();
                foreach (DataRowView item in InternalDataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].DefaultView)
                {
                    this.AddElement(new FamilyTemplate(item), true);
                }
            }
        }

        public override bool CanAddElement()
        {
            return true;
        }

        public override bool CanCancelElementChanges()
        {
            return true;
        }

        public override void CancelElementChanges()
        {

        }

        public override bool CanCreateNewElement()
        {
            return true;
        }

        public override bool CanDeleteElement()
        {
            return true;
        }

        public override bool CanGoBack()
        {
            return true;
        }

        public override bool CanGoToNext()
        {
            return true;
        }

        public override bool CanSaveElement()
        {
            return true;
        }

        public override void NewElement()
        {
            System.Windows.Forms.OpenFileDialog dialogue = new System.Windows.Forms.OpenFileDialog();
            if (dialogue.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(dialogue.FileName);
                FamilyTemplate temp = FamilyTemplate.NewTemplate(TemplateDataView);
                temp.FileName = file.Name;
                temp.FileSize = file.Length;
                temp.Thumbnail = Utils.ImageToByte(Resources.key);
                temp.FamilyFile = Utils.FileToByteArray(file.FullName);

                temp.EndEdit();
                SelectedElement = temp;
                Autodesk.Revit.DB.Document doc = ((Autodesk.Revit.ApplicationServices.Application)ADSKApplciation).OpenDocumentFile(file.FullName);

                //Autodesk.Revit.DB.Category category;
                foreach (Autodesk.Revit.DB.FamilyParameter item in doc.FamilyManager.Parameters)
                {
                    Parameter parameter = Parameter.newParameter(InternalDataSet.Tables[TableNames.FF_Parameters.ToString()].DefaultView);
                    parameter.FamilyTemplateId = temp.Id;
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
                    temp.ParameterItems.Add(parameter);
                }

                List<Autodesk.Revit.DB.ReferencePlane> planes = Utils.GetReferencePlanes(doc);
                foreach (Autodesk.Revit.DB.ReferencePlane plane in planes)
                {
                    ReferencePlane refPlane = ReferencePlane.NewReferencePlane(InternalDataSet.Tables[TableNames.FF_ReferencePlanes.ToString()].DefaultView);
                    refPlane.FamiltyTemplateId = temp.Id;
                    refPlane.Name = plane.Name;
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
                    temp.RefferencePlaneItems.Add(refPlane);
                }
                doc.Close(false);
            }
        }

        public override void SaveElement(FamilyTemplate element)
        {

        }
    }
}
