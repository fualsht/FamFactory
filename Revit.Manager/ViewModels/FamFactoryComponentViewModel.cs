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
    public class FamFactoryComponentViewModel : ViewModelBase<FamilyComponent>
    {
        DataView ComponentDataView;
        public FamFactoryComponentViewModel(DataSet dataSet): base(dataSet)
        {
            ComponentDataView = InternalDataSet.Tables[TableNames.FF_FamilyComponents.ToString()].DefaultView;
            RefreshCollection();
        }

        public FamFactoryComponentViewModel(DataSet dataSet, object application) : base(dataSet, application)
        {
            ComponentDataView = InternalDataSet.Tables[TableNames.FF_FamilyComponents.ToString()].DefaultView;
            RefreshCollection();
        }

        private void RefreshCollection()
        {
            if (InternalCollection != null)
            {
                InternalCollection.Clear();
                foreach (DataRowView item in InternalDataSet.Tables[TableNames.FF_FamilyComponents.ToString()].DefaultView)
                {
                    this.AddElement(new FamilyComponent(item), true);
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

                SelectedElement = FamilyComponent.NewFamilyComponent(ComponentDataView);
                SelectedElement.FileName = file.Name;
                SelectedElement.FileSize = file.Length;
                SelectedElement.Thumbnail = Utils.ImageToByte(Resources.key);
                SelectedElement.Thumbnail = Utils.ThumbnailFromView(doc, "Thumbnail");

                if (doc.OwnerFamily.FamilyCategory != null)
                    SelectedElement.FamilyCategory = doc.OwnerFamily.FamilyCategory.Name;
                else
                    SelectedElement.FamilyCategory = "None";

                SelectedElement.EndEdit();

                Utils.GetFamilyComponentFeatures(SelectedElement, doc);
                Utils.GetFamilyComponentParameters(SelectedElement, doc);
                Utils.GetFamilyComponentReferencePlanes(SelectedElement, doc);

                doc.Close(false);

                SelectedElement.FamilyFile = Utils.FileToByteArray(file.FullName);
                RefreshCollection();
            }
        }

        public override void SaveElement(FamilyComponent element)
        {
     
        }
    }
}
