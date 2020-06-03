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
        public enum TemplateComponentColumnNames { Id, Name, Description, FamilyId, XRefferencePlaneId, YRefferencePlaneId , ZRefferencePlaneId, DateCreated, DateModified, CreatedById, ModifiedById }
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

        public string XRefferencePlaneId
        {
            get { return internalDataRowView[TemplateComponentColumnNames.XRefferencePlaneId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.XRefferencePlaneId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string YRefferencePlaneId
        {
            get { return internalDataRowView[TemplateComponentColumnNames.YRefferencePlaneId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.YRefferencePlaneId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string ZRefferencePlaneId
        {
            get { return internalDataRowView[TemplateComponentColumnNames.ZRefferencePlaneId.ToString()].ToString(); }
            set { internalDataRowView.BeginEdit(); internalDataRowView[TemplateComponentColumnNames.ZRefferencePlaneId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
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

        public FamilyTemplateComponent(DataRowView rowView, SQLiteConnection connection) : base(rowView, connection)
        {
            RefreshCollections();
        }

        private void RefreshCollections()
        {
            DataView view = internalDataRowView.DataView.Table.DataSet.Tables[TableNames.FF_FamilyTemplateReferencePlanes.ToString()].DefaultView;
            view.Sort = "Id";
            view.RowFilter = $"Id = '{FamilyId}'";
        }

        internal static FamilyTemplateComponent NewTemplateComponent(SQLiteConnection connection, DataView dataVew, User user)
        {
            FamilyTemplateComponent component = new FamilyTemplateComponent(dataVew.AddNew(), connection);
            component.Id = Guid.NewGuid().ToString();
            component.DateCreated = DateTime.Now;
            component.DateModified = DateTime.Now;
            component.CreatedById = user.Id;
            component.ModifiedById = user.Id;
            component.CreatedBy = user;
            component.ModifiedBy = user;
            return component;
        }
    }
}
