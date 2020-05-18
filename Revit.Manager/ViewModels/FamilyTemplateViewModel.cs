﻿using ModBox.FamFactory.Revit.Manager.Properties;
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

        public override object NewElement(User user)
        {
            FamilyTemplate template = null;
            System.Windows.Forms.OpenFileDialog dialogue = new System.Windows.Forms.OpenFileDialog();
            if (dialogue.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(dialogue.FileName);
                Autodesk.Revit.DB.Document doc = ((Autodesk.Revit.ApplicationServices.Application)ADSKApplciation).OpenDocumentFile(file.FullName);

                template = FamilyTemplate.NewTemplate(TemplateDataView);
                template.FileName = file.Name;
                template.FileSize = file.Length;
                template.DateCreated = DateTime.Now;
                template.DateModified = DateTime.Now;
                template.IsReleased = false;
                template.CreatedByUserId = user.Id;

                byte[] image = Utils.ThumbnailFromView(doc, "Thumbnail");
                if (image == null)
                    template.Thumbnail = new byte[byte.MaxValue];
                else
                    template.Thumbnail = image;

                if (doc.OwnerFamily.FamilyCategory != null)
                    template.FamilyCategory = doc.OwnerFamily.FamilyCategory.Name;
                else
                    template.FamilyCategory = "None";

                Autodesk.Revit.DB.ElementId alwaysVerticalId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.FAMILY_ALWAYS_VERTICAL);
                Autodesk.Revit.DB.ElementId canHostRebarlId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.FAMILY_CAN_HOST_REBAR);
                Autodesk.Revit.DB.ElementId cutsWalllId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.FAMILY_ALLOW_CUT_WITH_VOIDS);
                Autodesk.Revit.DB.ElementId sharedId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.FAMILY_SHARED);
                Autodesk.Revit.DB.ElementId OmniClassCodeId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.OMNICLASS_CODE);
                Autodesk.Revit.DB.ElementId omniClassNameId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.OMNICLASS_DESCRIPTION);
                Autodesk.Revit.DB.ElementId parttypeId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.FAMILY_CONTENT_PART_TYPE);
                Autodesk.Revit.DB.ElementId roomCalculationpointId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.ROOM_CALCULATION_POINT);
                Autodesk.Revit.DB.ElementId roundCOnnectorDescriptionId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.FAMILY_ROUNDCONNECTOR_DIMENSIONTYPE);
                Autodesk.Revit.DB.ElementId workPlaneBasedId = new Autodesk.Revit.DB.ElementId(Autodesk.Revit.DB.BuiltInParameter.FAMILY_WORK_PLANE_BASED);

                foreach (Autodesk.Revit.DB.Parameter parameter in doc.OwnerFamily.Parameters)
                {    
                    if (parameter.Id == alwaysVerticalId)
                        template.AlwaysVertical = Convert.ToBoolean( parameter.AsInteger());

                    if (parameter.Id == canHostRebarlId)
                        template.CanHostRebar = Convert.ToBoolean(parameter.AsInteger());

                    if (parameter.Id == cutsWalllId)
                        template.CutsWithVoidWhenLoaded = Convert.ToBoolean(parameter.AsInteger());
                    
                    if (parameter.Id == sharedId)
                        template.IsShared = Convert.ToBoolean(parameter.AsInteger());

                    if (parameter.Id == omniClassNameId)
                        template.OmniClassTitle = parameter.AsString();

                    if (parameter.Id == OmniClassCodeId)
                        template.OmnoClassNumber = parameter.AsValueString();

                    if (parameter.Id == parttypeId)
                        template.PartType = parameter.AsValueString();

                    if (parameter.Id == roomCalculationpointId)
                        template.RoomCalculationPoint = Convert.ToBoolean(parameter.AsInteger());

                    if (parameter.Id == roundCOnnectorDescriptionId)
                        template.RoundConnectorDimention = parameter.AsValueString();

                    if (parameter.Id == workPlaneBasedId)
                        template.WorkPlaneBased = Convert.ToBoolean(parameter.AsInteger());
                }

                if (template.PartType == string.Empty)
                    template.PartType = "N/A";

                if (template.RoundConnectorDimention == string.Empty)
                    template.PartType = "N/A";

                template.EndEdit();

                Utils.GetFamilyTemplateParameters(template, doc);
                Utils.GetFamilyTemplateReferencePlanes(template, doc);
                Utils.GetFamilyTemplateFeatures(template, doc);

                doc.Close(false);
                
                template.FamilyFile = Utils.FileToByteArray(file.FullName);
                SelectedElement = template;
                RefreshCollection();
            }
            return template;
        }

        public override void SaveElement(FamilyTemplate element)
        {
            element.EndEdit();
            Utils.SaveChanges(SQLiteConnection, TemplateDataView.Table);
            Utils.SaveChanges(SQLiteConnection, InternalDataSet.Tables[TableNames.FF_FamilyTemplateParameters.ToString()]); 
            Utils.SaveChanges(SQLiteConnection, InternalDataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()]);
            Utils.SaveChanges(SQLiteConnection, InternalDataSet.Tables[TableNames.FF_FamilyTemplateGeometry.ToString()]);
        }

        private void FamilyTemplatesViewModel_OnSelectionChagned(object sender, EventArgs e)
        {
            
        }
    }
}
