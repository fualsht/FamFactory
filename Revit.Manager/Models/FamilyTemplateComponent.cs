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
        public enum TemplateComponentColumnNames { Id, Name, Description, FamilyId, XReferencePlaneId, YReferencePlaneId , ZReferencePlaneId, DateCreated, DateModified, CreatedById, ModifiedById }
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

        public object DateCreated
        {
            get { return internalDataRowView[TemplateComponentColumnNames.DateCreated.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.DateCreated.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public object DateModified
        {
            get { return internalDataRowView[TemplateComponentColumnNames.DateModified.ToString()]; }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.DateModified.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string CreatedById
        {
            get { return internalDataRowView[TemplateComponentColumnNames.CreatedById.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.CreatedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        User _CreatedBy;
        public User CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string ModifiedById
        {
            get { return internalDataRowView[TemplateComponentColumnNames.ModifiedById.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.ModifiedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        User _ModifiedBy;
        public User ModifiedBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public ObservableCollection<ReferencePlane> ParentReferencePlanes { get; set; }

        public FamilyTemplateComponent(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
        {
            ParentReferencePlanes = new ObservableCollection<ReferencePlane>();
            RefreshCollections();
        }

        public void RefreshCollections()
        {
            DataView view = internalDataRowView.DataView.Table.DataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].DefaultView;
            view.RowFilter = string.Empty;
            view.Sort = "Id";
            view.RowFilter = $"FamilyId = '{FamilyId}'";
            ParentReferencePlanes.Clear();
            foreach (DataRowView view1 in view)
            {
                ParentReferencePlanes.Add(new ReferencePlane(view1, this.internalSQLConenction));
            }
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
            return component;
        }
    }
}
