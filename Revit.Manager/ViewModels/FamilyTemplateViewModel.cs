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


                Utils.GetParameters(temp, doc);
                Utils.GetReferencePlanes(temp ,doc);
                Utils.GetFamilyFeatures(temp, doc);

                doc.Close(false);
                RefreshCollection();
            }
        }

        public override void SaveElement(FamilyTemplate element)
        {

        }
    }
}
