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
        public FamilyTemplatesViewModel(DataSet dataset, Autodesk.Revit.ApplicationServices.Application application) : base(dataset, application)
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
                SelectedElement = temp;

                Autodesk.Revit.DB.Document doc = ADSKApplciation.OpenDocumentFile(file.FullName);

                Autodesk.Revit.DB.Category category = doc.ProjectInformation.Category;
                foreach (Autodesk.Revit.DB.FamilyParameter item in doc.FamilyManager.Parameters)
                {
                    Parameter parameter = Parameter.newParameter(InternalDataSet.Tables["FFParameters"].DefaultView);
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
                    parameter.StorageType = item.StorageType;
                    parameter.BuiltInParamGroup = item.Definition.ParameterGroup;
                    parameter.ParameterType = item.Definition.ParameterType;
                    parameter.UnitType = item.Definition.UnitType;

                    try
                    {
                        parameter.DisplayUnitType = item.DisplayUnitType;
                    }
                    catch (Exception e)
                    {
                        parameter.DisplayUnitType = Autodesk.Revit.DB.DisplayUnitType.DUT_UNDEFINED;
                    }

                    parameter.UserModifiable = item.UserModifiable;
                    parameter.IsDeterminedByFormula = item.IsDeterminedByFormula;
                    parameter.Formula = item.Formula;
                    parameter.IsActive = false;
                    parameter.IsEditable = true;
                    parameter.EndEdit();
                    temp.ParameterItems.Add(parameter);
                }
                doc.Close(false);

            }
        }

        public override void SaveElement(FamilyTemplate element)
        {

        }
    }
}
