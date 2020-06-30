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
        public string Id { get { return internalDataRowView[TemplateComponentsColumnNames.Id.ToString()].ToString(); } set { internalDataRowView[TemplateComponentsColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); } }

        public string Name
        {
            get { return internalDataRowView[TemplateComponentsColumnNames.Name.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentsColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public string Description
        {
            get { return internalDataRowView[TemplateComponentsColumnNames.Description.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentsColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public bool IsProfile
        {
            get { return (bool)internalDataRowView[TemplateComponentsColumnNames.IsProfile.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentsColumnNames.IsProfile.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public string FamilyId
        {
            get { return internalDataRowView[TemplateComponentsColumnNames.FamilyId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentsColumnNames.FamilyId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); RefreshCollections(); }
        }

        public string XReferencePlaneId
        {
            get 
            {
                return internalDataRowView[TemplateComponentsColumnNames.XReferencePlaneId.ToString()].ToString();
            }
            set
            {
                internalDataRowView.BeginEdit(); 
                internalDataRowView[TemplateComponentsColumnNames.XReferencePlaneId.ToString()] = value; 
                NotifyPropertyChanged(); 
                _valuesChanged = true; 
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
                _valuesChanged = true; 
                NotifyPropertyChanged("ValuesChanged"); 
            }
        }

        public string YReferencePlaneId
        {
            get 
            {
                return internalDataRowView[TemplateComponentsColumnNames.YReferencePlaneId.ToString()].ToString(); 
            }
            set
            {
                internalDataRowView.BeginEdit();
                internalDataRowView[TemplateComponentsColumnNames.YReferencePlaneId.ToString()] = value;
                NotifyPropertyChanged();
                _valuesChanged = true; 
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
                _valuesChanged = true;
                NotifyPropertyChanged("ValuesChanged");
            }
        }


        public string ZReferencePlaneId
        {
            get
            { 
                return internalDataRowView[TemplateComponentsColumnNames.ZReferencePlaneId.ToString()].ToString();
            }
            set
            { 
                internalDataRowView.BeginEdit();
                internalDataRowView[TemplateComponentsColumnNames.ZReferencePlaneId.ToString()] = value;
                NotifyPropertyChanged(); 
                _valuesChanged = true;
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
                _valuesChanged = true;
                NotifyPropertyChanged("ValuesChanged");
            }
        }

        public string ProfileGeometryId
        {
            get { return internalDataRowView[TemplateComponentsColumnNames.ProfileGeometryId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentsColumnNames.ProfileGeometryId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }
        private FamilyGeometry _ProfileGeometry;

        public FamilyGeometry ProfileGeometry
        {
            get { return _ProfileGeometry; }
            set { _ProfileGeometry = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }


        public string ProfileTypeNameId
        {
            get { return internalDataRowView[TemplateComponentsColumnNames.ProfileTypeNameId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentsColumnNames.ProfileTypeNameId.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public decimal ProfileVerticalOffset
        {
            get { return (decimal)internalDataRowView[TemplateComponentsColumnNames.ProfileVerticalOffset.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentsColumnNames.ProfileVerticalOffset.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public decimal ProfileHorizontalOffset
        {
            get { return (decimal)internalDataRowView[TemplateComponentsColumnNames.ProfileHorizontalOffset.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentsColumnNames.ProfileHorizontalOffset.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public decimal ProfileAngle
        {
            get { return (decimal)internalDataRowView[TemplateComponentsColumnNames.ProfileAngle.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentsColumnNames.ProfileAngle.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public bool ProfileIsFlipped
        {
            get { return (bool)internalDataRowView[TemplateComponentsColumnNames.ProfileIsFlipped.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentsColumnNames.ProfileIsFlipped.ToString()] = value; NotifyPropertyChanged(); NotifyValueChanged(); }
        }

        public string FamilyComponentTypeId
        {
            get
            {
                return internalDataRowView[TemplateComponentsColumnNames.FamilyComponentTypeId.ToString()].ToString();
            }
            set
            {
                internalDataRowView.BeginEdit();
                internalDataRowView[TemplateComponentsColumnNames.FamilyComponentTypeId.ToString()] = value;
                NotifyPropertyChanged();
                NotifyValueChanged();
                FamilyComponentType = FamilyComponentTypes.FirstOrDefault(x => x.Id == value);
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
                NotifyValueChanged();
                if (value != null && FamilyComponentTypeId != value.Id)
                {
                    FamilyComponentTypeId = value.Id;
                }
            }
        }

        public ObservableCollection<ReferencePlane> ParentReferencePlanes { get; set; }
        public ObservableCollection<FamilyGeometry> ParentGeometries { get; set; }
        public ObservableCollection<FamilyComponentType> FamilyComponentTypes { get; set; }

        public FamilyTemplateComponent(DataRowView rowView, SQLiteConnection connection, User user) : base(rowView, connection, user)
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
                ParentReferencePlanes.Add(new ReferencePlane(referencePlane, this.internalSQLConenction, ActiveUser));
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
                ParentGeometries.Add(new FamilyGeometry(item, this.internalSQLConenction, ActiveUser));
            }

            ProfileGeometry = ParentGeometries.FirstOrDefault(x => x.Id == ProfileGeometryId);

            DataView componentTypes = internalDataRowView.DataView.Table.DataSet.Tables[TableNames.FF_FamilyComponentTypes.ToString()].DefaultView;
            componentTypes.RowFilter = string.Empty;
            FamilyComponentTypes.Clear();
            foreach (DataRowView item in componentTypes)
            {
                FamilyComponentTypes.Add(new FamilyComponentType(item, this.internalSQLConenction, ActiveUser));
            }

            FamilyComponentType = FamilyComponentTypes.FirstOrDefault(x => x.Id == FamilyComponentTypeId);
        }

        internal static FamilyTemplateComponent NewTemplateComponent(SQLiteConnection connection, DataView dataVew, User user, FamilyTemplate parent)
        {
            FamilyTemplateComponent component = new FamilyTemplateComponent(dataVew.AddNew(), connection, user);
            component.Id = Guid.NewGuid().ToString();
            component.FamilyComponentTypeId = parent.FamilyTemplateComponents.InternalCollection[0].Id;
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
