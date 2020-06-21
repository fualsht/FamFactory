using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyTemplateComponent : ModelBase<FamilyTemplateComponent>
    {
        public enum TemplateComponentColumnNames { Id, Name, Description, IsProfile, FamilyId, XReferencePlaneId, YReferencePlaneId , ZReferencePlaneId, DateCreated, DateModified, CreatedById, ModifiedById, ProfileGeometryId, 
                                                    ProfileTypeNameId, ProfileVerticalOffset, ProfileHorizontalOffset, ProfileAngle, ProfileIsFlipped, FamilyComponentTypeId }
        public string Id { get { return internalDataRowView[TemplateComponentColumnNames.Id.ToString()].ToString(); } set { internalDataRowView[TemplateComponentColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); } }

        public string Name
        {
            get { return internalDataRowView[TemplateComponentColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string Description
        {
            get { return internalDataRowView[TemplateComponentColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public bool IsProfile
        {
            get { return (bool)internalDataRowView[TemplateComponentColumnNames.IsProfile.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.IsProfile.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string FamilyId
        {
            get { return internalDataRowView[TemplateComponentColumnNames.FamilyId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.FamilyId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); RefreshCollections(); }
        }

        public string XReferencePlaneId
        {
            get 
            {
                return internalDataRowView[TemplateComponentColumnNames.XReferencePlaneId.ToString()].ToString();
            }
            set
            {
                internalDataRowView.BeginEdit(); 
                internalDataRowView[TemplateComponentColumnNames.XReferencePlaneId.ToString()] = value; 
                NotifyPropertyChanged(); 
                _ValuesChanged = true; 
                NotifyPropertyChanged("ValuesChanged"); }
        }

        ReferencePlane _XReferencePlane;
        public ReferencePlane XReferencePlane
        {
            get { 
                return _XReferencePlane; 
            }
            set
            {
                internalDataRowView.BeginEdit(); 
                _XReferencePlane = value;
                NotifyPropertyChanged(); 
                _ValuesChanged = true; 
                NotifyPropertyChanged("ValuesChanged"); 
            }
        }

        public string YReferencePlaneId
        {
            get 
            {
                return internalDataRowView[TemplateComponentColumnNames.YReferencePlaneId.ToString()].ToString(); 
            }
            set
            {
                internalDataRowView.BeginEdit();
                internalDataRowView[TemplateComponentColumnNames.YReferencePlaneId.ToString()] = value;
                NotifyPropertyChanged();
                _ValuesChanged = true; 
                NotifyPropertyChanged("ValuesChanged");
            }
        }

        private ReferencePlane _YRreferencePlane;
        public ReferencePlane YReferencePlane
        {
            get
            {
                return _YRreferencePlane; 
            }
            set
            {
                internalDataRowView.BeginEdit();
                _YRreferencePlane = value;
                NotifyPropertyChanged();
                _ValuesChanged = true;
                NotifyPropertyChanged("ValuesChanged");
            }
        }


        public string ZReferencePlaneId
        {
            get
            { 
                return internalDataRowView[TemplateComponentColumnNames.ZReferencePlaneId.ToString()].ToString();
            }
            set
            { 
                internalDataRowView.BeginEdit();
                internalDataRowView[TemplateComponentColumnNames.ZReferencePlaneId.ToString()] = value;
                NotifyPropertyChanged(); 
                _ValuesChanged = true;
                NotifyPropertyChanged("ValuesChanged");
            }
        }

        private ReferencePlane _ZRreferencePlane;

        public ReferencePlane ZReferencePlane
        {
            get
            {
                return _ZRreferencePlane;
            }
            set
            {
                internalDataRowView.BeginEdit();
                _ZRreferencePlane = value;
                NotifyPropertyChanged();
                _ValuesChanged = true;
                NotifyPropertyChanged("ValuesChanged");
            }
        }

        public string ProfileGeometryId
        {
            get { return internalDataRowView[TemplateComponentColumnNames.ProfileGeometryId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.ProfileGeometryId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        private FamilyGeometry _ProfileGeometry;

        public FamilyGeometry ProfileGeometry
        {
            get { return _ProfileGeometry; }
            set { _ProfileGeometry = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }


        public string ProfileTypeNameId
        {
            get { return internalDataRowView[TemplateComponentColumnNames.ProfileTypeNameId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.ProfileTypeNameId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public decimal ProfileVerticalOffset
        {
            get { return (decimal)internalDataRowView[TemplateComponentColumnNames.ProfileVerticalOffset.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.ProfileVerticalOffset.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public decimal ProfileHorizontalOffset
        {
            get { return (decimal)internalDataRowView[TemplateComponentColumnNames.ProfileHorizontalOffset.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.ProfileHorizontalOffset.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public decimal ProfileAngle
        {
            get { return (decimal)internalDataRowView[TemplateComponentColumnNames.ProfileAngle.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.ProfileAngle.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public bool ProfileIsFlipped
        {
            get { return (bool)internalDataRowView[TemplateComponentColumnNames.ProfileIsFlipped.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.ProfileIsFlipped.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string FamilyComponentTypeId
        {
            get
            {
                return internalDataRowView[TemplateComponentColumnNames.FamilyComponentTypeId.ToString()].ToString();
            }
            set
            {
                internalDataRowView.BeginEdit();
                internalDataRowView[TemplateComponentColumnNames.FamilyComponentTypeId.ToString()] = value;
                NotifyPropertyChanged();
                _ValuesChanged = true;
                NotifyPropertyChanged("ValuesChanged");
            }
        }

        private FamilyComponentType _FamilyComponentType;

        public FamilyComponentType FamilyComponentType
        {
            get
            {
                return _FamilyComponentType;
            }
            set
            {
                internalDataRowView.BeginEdit();
                _FamilyComponentType = value;
                NotifyPropertyChanged();
                _ValuesChanged = true;
                NotifyPropertyChanged("ValuesChanged");
            }
        }

        public ObservableCollection<ReferencePlane> ParentReferencePlanes { get; set; }
        public ObservableCollection<FamilyGeometry> ParentGeometries { get; set; }
        public ObservableCollection<FamilyComponentType> FamilyComponentTypes { get; set; }

        public FamilyTemplateComponent(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
        {
            ParentReferencePlanes = new ObservableCollection<ReferencePlane>();
            ParentGeometries = new ObservableCollection<FamilyGeometry>();
            FamilyComponentTypes = new ObservableCollection<FamilyComponentType>();
            RefreshCollections();
        }

        public override void RefreshCollections()
        {
            DataView references = internalDataRowView.DataView.Table.DataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].DefaultView;
            references.RowFilter = string.Empty;
            references.Sort = "Id";
            references.RowFilter = $"FamilyId = '{FamilyId}'";
            ParentReferencePlanes.Clear();
            foreach (DataRowView referencePlane in references)
            {
                ParentReferencePlanes.Add(new ReferencePlane(referencePlane, this.internalSQLConenction));
            }

            XReferencePlane = ParentReferencePlanes.FirstOrDefault(x => x.Id == XReferencePlaneId);
            YReferencePlane = ParentReferencePlanes.FirstOrDefault(x => x.Id == YReferencePlaneId);
            ZReferencePlane = ParentReferencePlanes.FirstOrDefault(x => x.Id == ZReferencePlaneId);

            DataView geometries = internalDataRowView.DataView.Table.DataSet.Tables[TableNames.FF_FamilyTemplateGeometries.ToString()].DefaultView;
            geometries.RowFilter = string.Empty;
            geometries.Sort = "Id";
            geometries.RowFilter = $"FamilyId = '{FamilyId}'";
            ParentGeometries.Clear();
            foreach (DataRowView item in geometries)
            {
                ParentGeometries.Add(new FamilyGeometry(item, this.internalSQLConenction));
            }

            ProfileGeometry = ParentGeometries.FirstOrDefault(x => x.Id == ProfileGeometryId);

            DataView componentTypes = internalDataRowView.DataView.Table.DataSet.Tables[TableNames.FF_FamilyComponentTypes.ToString()].DefaultView;
            componentTypes.RowFilter = string.Empty;
            FamilyComponentTypes.Clear();
            foreach (DataRowView item in componentTypes)
            {
                FamilyComponentTypes.Add(new FamilyComponentType(item, this.internalSQLConenction));
            }

            FamilyComponentType = FamilyComponentTypes.FirstOrDefault(x => x.Id == FamilyComponentTypeId);
        }

        internal static FamilyTemplateComponent NewTemplateComponent(SQLiteConnection connection, DataView dataVew, User user, FamilyTemplate parent)
        {
            FamilyTemplateComponent component = new FamilyTemplateComponent(dataVew.AddNew(), connection);
            component.Id = Guid.NewGuid().ToString();
            component.DateCreated = DateTime.Now;
            component.DateModified = DateTime.Now;
            component.CreatedById = user.Id;
            component.ModifiedById = user.Id;
            component.CreatedBy = user;
            component.ModifiedBy = user;
            component.FamilyId = parent.Id;
            component.RefreshCollections();
            component.XReferencePlane = component.ParentReferencePlanes[0];
            component.XReferencePlaneId = component.XReferencePlane.Id;
            component.YReferencePlane = component.ParentReferencePlanes[0];
            component.YReferencePlaneId = component.YReferencePlane.Id;
            component.ZReferencePlane = component.ParentReferencePlanes[0];
            component.ZReferencePlaneId = component.ZReferencePlane.Id;
            component.IsProfile = false;
            if (component.ParentGeometries.Count > 0)
                component.ProfileGeometryId = component.ParentGeometries[0].Id;
            component.ProfileTypeNameId = "Type1";
            component.ProfileVerticalOffset = 0;
            component.ProfileHorizontalOffset = 0;
            component.ProfileAngle = 0;
            component.ProfileIsFlipped = false;
            return component;
        }

        public override void RefreshCollections(string sortColumn, string filter)
        {
            throw new NotImplementedException();
        }
    }
}
