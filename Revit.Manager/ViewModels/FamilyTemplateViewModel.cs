using ModBox.FamFactory.Revit.Manager.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<User> UsersList { get; set; } = new ObservableCollection<User>();
        DataView usersDataView;

        public FamilyTemplatesViewModel(DataSet dataset, System.Data.SQLite.SQLiteConnection sQLiteConnection) : base(dataset, sQLiteConnection)
        {
            TemplateDataView = InternalDataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].DefaultView;
            usersDataView = InternalDataSet.Tables[TableNames.FF_Users.ToString()].DefaultView;
            OnSelectionChagned += FamilyTemplatesViewModel_OnSelectionChagned;
            RefreshCollection();
        }

        public FamilyTemplatesViewModel(DataSet dataset, System.Data.SQLite.SQLiteConnection sQLiteConnection, object application) : base(dataset, sQLiteConnection, application)
        {
            TemplateDataView = InternalDataSet.Tables[TableNames.FF_FamilyTemplates.ToString()].DefaultView;
            usersDataView = InternalDataSet.Tables[TableNames.FF_Users.ToString()].DefaultView;
            OnSelectionChagned += FamilyTemplatesViewModel_OnSelectionChagned;
            RefreshCollection();
        }

        private void RefreshCollection()
        {
            if (InternalCollection != null)
            {
                InternalCollection.Clear();
                UsersList.Clear();
                foreach (DataRowView item in TemplateDataView)
                {
                    this.AddElement(new FamilyTemplate(item), true);
                }
                foreach (DataRowView rowView in usersDataView)
                {
                    UsersList.Add(new User(rowView));
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

        public override FamilyTemplate NewElement(User user)
        {
            FamilyTemplate template = null;
            System.Windows.Forms.OpenFileDialog dialogue = new System.Windows.Forms.OpenFileDialog();
            if (dialogue.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(dialogue.FileName);
                Autodesk.Revit.DB.Document doc = ((Autodesk.Revit.ApplicationServices.Application)ADSKApplciation).OpenDocumentFile(file.FullName);

                SelectedElement = FamilyTemplate.NewTemplate(TemplateDataView);
                SelectedElement.FileName = file.Name;
                SelectedElement.FileSize = file.Length;
                SelectedElement.DateCreated = DateTime.Now;
                SelectedElement.DateModified = DateTime.Now;
                SelectedElement.IsReleased = false;
                SelectedElement.CreatedByUserId = user.Id;

                byte[] image = Utils.ThumbnailFromView(doc, "Thumbnail");
                if (image == null)
                    SelectedElement.Thumbnail = new byte[byte.MaxValue];
                else
                    SelectedElement.Thumbnail = image;

                if (doc.OwnerFamily.FamilyCategory != null)
                    SelectedElement.FamilyCategory = doc.OwnerFamily.FamilyCategory.Name;
                else
                    SelectedElement.FamilyCategory = "None";

                Autodesk.Revit.DB.ElementId alwaysVerticalId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.FAMILY_ALWAYS_VERTICAL);
                Autodesk.Revit.DB.ElementId canHostRebarlId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.FAMILY_CAN_HOST_REBAR);
                Autodesk.Revit.DB.ElementId cutsWalllId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.WALL_SWEEP_CUTS_WALL_PARAM);
                Autodesk.Revit.DB.ElementId categorylId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.SCHEDULE_CATEGORY);
                Autodesk.Revit.DB.ElementId sharedId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.FAMILY_SHARED);
                Autodesk.Revit.DB.ElementId OmniClassCodeId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.OMNICLASS_CODE);
                Autodesk.Revit.DB.ElementId omniClassNameId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.OMNICLASS_DESCRIPTION);
                Autodesk.Revit.DB.ElementId parttypeId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.FAMILY_CONTENT_PART_TYPE);
                Autodesk.Revit.DB.ElementId roomCalculationpointId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.ROOM_CALCULATION_POINT);
                Autodesk.Revit.DB.ElementId roundCOnnectorDescriptionId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.FAMILY_ROUNDCONNECTOR_DIMENSIONTYPE);
                Autodesk.Revit.DB.ElementId workPlaneBasedId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.FAMILY_WORK_PLANE_BASED);

                string s = "";
                foreach (Autodesk.Revit.DB.Parameter parameter in doc.OwnerFamily.Parameters)
                {    
                    if (parameter.Id == alwaysVerticalId)
                        SelectedElement.AlwaysVertical = Convert.ToBoolean( parameter.AsInteger());

                    if (parameter.Id == canHostRebarlId)
                        SelectedElement.CanHostRebar = Convert.ToBoolean(parameter.AsInteger());

                    if (parameter.Id == cutsWalllId)
                        SelectedElement.CutsWithVoidWhenLoaded = Convert.ToBoolean(parameter.AsInteger());

                    if (parameter.Id == categorylId)
                        SelectedElement.FamilyCategory = parameter.AsValueString();

                    if (parameter.Id == sharedId)
                        SelectedElement.IsShared = Convert.ToBoolean(parameter.AsInteger());

                    if (parameter.Id == omniClassNameId)
                        SelectedElement.OmniClassTitle = parameter.AsValueString();

                    if (parameter.Id == OmniClassCodeId)
                        SelectedElement.OmnoClassNumber = parameter.AsValueString();

                    if (parameter.Id == parttypeId)
                        SelectedElement.PartType = parameter.AsValueString();

                    if (parameter.Id == roomCalculationpointId)
                        SelectedElement.RoomCalculationPoint = Convert.ToBoolean(parameter.AsInteger());

                    if (parameter.Id == roundCOnnectorDescriptionId)
                        SelectedElement.RoundConnectorDimention = parameter.AsValueString();

                    if (parameter.Id == workPlaneBasedId)
                        SelectedElement.WorkPlaneBased = Convert.ToBoolean(parameter.AsInteger());
                    
                    s += string.Format("{0}: {1}\n", parameter.Definition.Name, parameter.AsValueString());
                }

                Autodesk.Revit.UI.TaskDialog tdiag = new Autodesk.Revit.UI.TaskDialog("Details");
                tdiag.MainContent = s;
                tdiag.Show();

                SelectedElement.EndEdit();

                Utils.GetFamilyTemplateParameters(SelectedElement, doc);
                Utils.GetFamilyTemplateReferencePlanes(SelectedElement, doc);
                Utils.GetFamilyTemplateFeatures(SelectedElement, doc);

                doc.Close(false);
                
                SelectedElement.FamilyFile = Utils.FileToByteArray(file.FullName);
                RefreshCollection();
            }
            return template;
        }

        public override void SaveElement(FamilyTemplate element)
        {

        }

        private void FamilyTemplatesViewModel_OnSelectionChagned(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
