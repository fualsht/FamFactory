﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyComponent : ModelBase<FamilyComponent>
    {
        public enum FamilyComponentsTableColumnNames { Id, Name, Description, FamilyComponentTypeId, FamilyCategory, FamilyFile, Thumbnail, FileSize, DateCreated, DateModified, CreatedByUserId, Version, 
            IsReleased, RoundConnectorDimention, PartType, OmniClassNumber, OmniClassTitle, WorkPlaneBased, AlwaysVertical, CutsWithVoidWhenLoaded, IsShared, RoomCalculationPoint, FileName }

        public string Id
        {
            get { return InternalDataRowView[FamilyComponentsTableColumnNames.Id.ToString()].ToString(); }
            set { InternalDataRowView[FamilyComponentsTableColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return InternalDataRowView[FamilyComponentsTableColumnNames.Name.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Description
        {
            get { return InternalDataRowView[FamilyComponentsTableColumnNames.Description.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string FamilyComponentTypeId
        {
            get { return InternalDataRowView[FamilyComponentsTableColumnNames.FamilyComponentTypeId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.FamilyComponentTypeId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string FamilyCategory
        {
            get { return InternalDataRowView[FamilyComponentsTableColumnNames.FamilyCategory.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.FamilyCategory.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public byte[] FamilyFile
        {
            get { return (byte[])InternalDataRowView[FamilyComponentsTableColumnNames.FamilyFile.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.FamilyFile.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public byte[] Thumbnail
        {
            get { return (byte[])InternalDataRowView[FamilyComponentsTableColumnNames.Thumbnail.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.Thumbnail.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public long FileSize
        {
            get { return (long)InternalDataRowView[FamilyComponentsTableColumnNames.FileSize.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.FileSize.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public DateTime DateCreated
        {
            get { return (DateTime)InternalDataRowView[FamilyComponentsTableColumnNames.DateCreated.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.DateCreated.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public DateTime DateModified
        {
            get { return (DateTime)InternalDataRowView[FamilyComponentsTableColumnNames.DateModified.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.DateModified.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string CreatedBy
        {
            get { return InternalDataRowView[FamilyComponentsTableColumnNames.CreatedByUserId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.CreatedByUserId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public Version Version
        {
            get { return Version.AsVersion(InternalDataRowView[FamilyComponentsTableColumnNames.Version.ToString()].ToString()); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.Version.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsReleased
        {
            get { return (bool)InternalDataRowView[FamilyComponentsTableColumnNames.IsReleased.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.IsReleased.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string RoundConnectorDimention
        {
            get { return InternalDataRowView[FamilyComponentsTableColumnNames.RoundConnectorDimention.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.RoundConnectorDimention.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string PartType
        {
            get { return InternalDataRowView[FamilyComponentsTableColumnNames.PartType.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.PartType.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string OmnoClassNumber
        {
            get { return InternalDataRowView[FamilyComponentsTableColumnNames.OmniClassNumber.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.OmniClassNumber.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string OmniClassTitle
        {
            get { return InternalDataRowView[FamilyComponentsTableColumnNames.OmniClassTitle.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool WorkPlaneBased
        {
            get { return (bool)InternalDataRowView[FamilyComponentsTableColumnNames.WorkPlaneBased.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.WorkPlaneBased.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool AlwaysVertical
        {
            get { return (bool)InternalDataRowView[FamilyComponentsTableColumnNames.AlwaysVertical.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.AlwaysVertical.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool CutsWithVoidWhenLoaded
        {
            get { return (bool)InternalDataRowView[FamilyComponentsTableColumnNames.CutsWithVoidWhenLoaded.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.CutsWithVoidWhenLoaded.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool IsShared
        {
            get { return (bool)InternalDataRowView[FamilyComponentsTableColumnNames.IsShared.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.IsShared.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public bool RoomCalculationPoint
        {
            get { return (bool)InternalDataRowView[FamilyComponentsTableColumnNames.RoomCalculationPoint.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.RoomCalculationPoint.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string FileName
        {
            get { return InternalDataRowView[FamilyComponentsTableColumnNames.FileName.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyComponentsTableColumnNames.FileName.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public ObservableCollection<ReferencePlane> RefferencePlaneItems { get; set; }
        public ObservableCollection<FamilyGeometry> FamilyGeometryItems { get; set; }
        public ObservableCollection<Parameter> ParameterItems { get; set; }

        DataView _FamilyComponentReferencePlanesView;
        public DataView FamilyComponentReferencePlanesView { get { return _FamilyComponentReferencePlanesView; } }

        DataView _FamilyComponentParametersView;
        public DataView FamilyComponentParametersView { get { return _FamilyComponentParametersView; } }

        DataView _FamilyComponentGeometryView;
        public DataView FamilyComponentGeometryView { get { return _FamilyComponentGeometryView; } }

        public FamilyComponent(DataRowView view) : base(view)
        {
            RefferencePlaneItems = new ObservableCollection<ReferencePlane>();
            FamilyGeometryItems = new ObservableCollection<FamilyGeometry>();
            ParameterItems = new ObservableCollection<Parameter>();
            _FamilyComponentParametersView = InternalDataRowView.CreateChildView(TableRelations.ParametersFamilyTemplateId_FamilyTemplatesId.ToString());
            _FamilyComponentReferencePlanesView = InternalDataRowView.CreateChildView(TableRelations.ReferencePlanesFamilyTemplateId_FamilyTemplatesId.ToString());
            _FamilyComponentGeometryView = InternalDataRowView.CreateChildView(TableRelations.GeometryFamilyTemplateid_FamilyTemplateId.ToString());
            RefreshChildRows();
        }
        private void RefreshChildRows()
        {
            ParameterItems.Clear();
            foreach (DataRowView item in FamilyComponentParametersView)
                ParameterItems.Add(new Parameter(item));

            RefferencePlaneItems.Clear();
            foreach (DataRowView item in FamilyComponentReferencePlanesView)
                RefferencePlaneItems.Add(new ReferencePlane(item));

            FamilyGeometryItems.Clear();
            foreach (DataRowView item in FamilyComponentGeometryView)
                FamilyGeometryItems.Add(new FamilyGeometry(item));
        }

        public static FamilyComponent NewFamilyComponent(DataView rowView)
        {
            DataRowView row = rowView.AddNew();

            FamilyComponent template = new FamilyComponent(row);
            template.Id = Guid.NewGuid().ToString();
            template.Version = new Version(0, 0, 0);
            template.DateCreated = DateTime.Now;
            template.DateModified = DateTime.Now;

            return template;
        }
    }
}
