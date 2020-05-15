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
        public FamilyTemplatesViewModel(DataSet dataset, System.Data.SQLite.SQLiteConnection sQLiteConnection) : base(dataset, sQLiteConnection)
        {
            TemplateDataView = InternalDataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].DefaultView; 
            RefreshCollection();
        }
        public FamilyTemplatesViewModel(DataSet dataset, System.Data.SQLite.SQLiteConnection sQLiteConnection, object application) : base(dataset, sQLiteConnection, application)
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
                Autodesk.Revit.DB.Document doc = ((Autodesk.Revit.ApplicationServices.Application)ADSKApplciation).OpenDocumentFile(file.FullName);

                SelectedElement = FamilyTemplate.NewTemplate(TemplateDataView);
                SelectedElement.FileName = file.Name;
                SelectedElement.FileSize = file.Length;
                SelectedElement.Thumbnail = Utils.ThumbnailFromView(doc, "Thumbnail");

                if (doc.OwnerFamily.FamilyCategory != null)
                    SelectedElement.FamilyCategory = doc.OwnerFamily.FamilyCategory.Name;
                else
                    SelectedElement.FamilyCategory = "None";

                
                foreach (Autodesk.Revit.DB.FamilyType type in doc.FamilyManager.Types)
                {
                    type.AsInteger(doc.FamilyManager.get_Parameter(Autodesk.Revit.DB.BuiltInParameter.FAMILY_ALWAYS_VERTICAL));
                }
                
                SelectedElement.EndEdit();

                Utils.GetFamilyTemplateParameters(SelectedElement, doc);
                Utils.GetFamilyTemplateReferencePlanes(SelectedElement, doc);
                Utils.GetFamilyTemplateFeatures(SelectedElement, doc);

                doc.Close(false);
                
                SelectedElement.FamilyFile = Utils.FileToByteArray(file.FullName);
                RefreshCollection();
            }
        }

        public override void SaveElement(FamilyTemplate element)
        {

        }
    }
}
