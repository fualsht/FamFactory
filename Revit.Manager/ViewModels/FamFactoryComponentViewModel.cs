﻿using ModBox.FamFactory.Revit.Manager.Properties;
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
        FamilyComponentTypeViewModel FamilyComponentTypeItems { get; set; }
        DataView ComponentDataView;

        public FamFactoryComponentViewModel(DataSet dataSet, System.Data.SQLite.SQLiteConnection sQLiteConnection, User user) : base(dataSet, sQLiteConnection, user)
        {
            FamilyComponentTypeItems = new FamilyComponentTypeViewModel(dataSet, sQLiteConnection, user);
            ComponentDataView = InternalDataSet.Tables[TableNames.FF_FamilyComponents].DefaultView;
            RefreshCollections();
        }

        public FamFactoryComponentViewModel(DataSet dataSet, System.Data.SQLite.SQLiteConnection sQLiteConnection, User user, object application) : base(dataSet, sQLiteConnection, user, application)
        {
            FamilyComponentTypeItems = new FamilyComponentTypeViewModel(dataSet, sQLiteConnection, user, application);
            ComponentDataView = InternalDataSet.Tables[TableNames.FF_FamilyComponents].DefaultView;
            RefreshCollections();
        }

        public override void RefreshCollections()
        {
            if (InternalCollection != null)
            {
                InternalCollection.Clear();
                foreach (DataRowView item in InternalDataSet.Tables[TableNames.FF_FamilyComponents].DefaultView)
                {
                    this.AddElement(new FamilyComponent(item, SQLiteConnection, ActiveUser, ADSKApplciation), true);
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

        public override object NewElement(object parent)
        {
            FamilyComponent component = null;
            System.Windows.Forms.OpenFileDialog dialogue = new System.Windows.Forms.OpenFileDialog();
            dialogue.Filter = "Revit Families (*.rfa)|*.rfa|All files (*.*)|*.*";
            dialogue.RestoreDirectory = true;
            if (dialogue.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(dialogue.FileName);
                Autodesk.Revit.DB.Document doc = ((Autodesk.Revit.ApplicationServices.Application)ADSKApplciation).OpenDocumentFile(file.FullName);

                component = FamilyComponent.NewFamilyComponent(SQLiteConnection, ComponentDataView, ActiveUser, ADSKApplciation, FamilyComponentTypeItems.InternalCollection[0]);
                component.FileName = file.Name;
                component.FileSize = file.Length;
                component.DateCreated = DateTime.Now;
                component.DateModified = DateTime.Now;
                component.IsReleased = false;
                component.State = EntityStates.Enabled;

                byte[] image = Utils.ThumbnailFromView(doc, "Thumbnail");
                if (image == null)
                    component.Thumbnail = new byte[byte.MaxValue];
                else
                    component.Thumbnail = image;

                if (doc.OwnerFamily.FamilyCategory != null)
                    component.FamilyCategory = doc.OwnerFamily.FamilyCategory.Name;
                else
                    component.FamilyCategory = "None";

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
                        component.AlwaysVertical = Convert.ToBoolean(parameter.AsInteger());

                    if (parameter.Id == canHostRebarlId)
                        component.CanHostRebar = Convert.ToBoolean(parameter.AsInteger());

                    if (parameter.Id == cutsWalllId)
                        component.CutsWithVoidWhenLoaded = Convert.ToBoolean(parameter.AsInteger());

                    if (parameter.Id == sharedId)
                        component.IsShared = Convert.ToBoolean(parameter.AsInteger());

                    if (parameter.Id == omniClassNameId)
                        component.OmniClassTitle = parameter.AsString();

                    if (parameter.Id == OmniClassCodeId)
                        component.OmnoClassNumber = parameter.AsString();

                    if (parameter.Id == parttypeId)
                        component.PartType = parameter.AsValueString();

                    if (parameter.Id == roomCalculationpointId)
                        component.RoomCalculationPoint = Convert.ToBoolean(parameter.AsInteger());

                    if (parameter.Id == roundCOnnectorDescriptionId)
                        component.RoundConnectorDimension = parameter.AsValueString();

                    if (parameter.Id == workPlaneBasedId)
                        component.WorkPlaneBased = Convert.ToBoolean(parameter.AsInteger());
                }

                if (component.PartType == string.Empty)
                    component.PartType = "N/A";

                if (component.RoundConnectorDimension == string.Empty)
                    component.PartType = "N/A";

                component.EndEdit();

                if (doc.OwnerFamily.FamilyCategory != null)
                    component.FamilyCategory = doc.OwnerFamily.FamilyCategory.Name;
                else
                    component.FamilyCategory = "None";

                component.EndEdit();

                Utils.GetFamilyComponentFeatures(component, doc, ActiveUser);
                Utils.GetFamilyComponentParameters(component, doc, ActiveUser);
                Utils.GetFamilyComponentReferencePlanes(component, doc, ActiveUser);

                doc.Close(false);

                component.FamilyFile = Utils.FileToByteArray(file.FullName);
                SelectedElement = component;
                RefreshCollections();
            }
            return component;
        }

        public override void SaveElement(FamilyComponent element)
        {
     
        }

        public override void RefreshCollections(string sortColumn, string filter)
        {
            if (InternalCollection != null)
            {
                InternalCollection.Clear();
                foreach (DataRowView item in InternalDataView)
                {
                    this.AddElement(new FamilyComponent(item, SQLiteConnection, ActiveUser, ADSKApplciation), true);
                }
            }
        }

        public override void EditElement(FamilyComponent element)
        {
            throw new NotImplementedException();
        }

        public override bool CanEditElement()
        {
            throw new NotImplementedException();
        }

        public override void DeleteElement(FamilyComponent element)
        {
            throw new NotImplementedException();
        }
    }
}
