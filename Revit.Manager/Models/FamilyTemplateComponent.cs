using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyTemplateComponent : ModelBase<FamilyTemplateComponent>
    {
        public enum TemplateComponentColumnNames { Id, Name, Description, FamilyId, XRefferencePlaneId, YRefferencePlaneId , ZRefferencePlaneId, DateCreated, DateModified, CreatedById, ModifiedById }
        public string Id { get { return InternalDataRowView[TemplateComponentColumnNames.Id.ToString()].ToString(); } set { InternalDataRowView[TemplateComponentColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); } }

        public string Name
        {
            get { return InternalDataRowView[TemplateComponentColumnNames.Name.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[TemplateComponentColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string Description
        {
            get { return InternalDataRowView[TemplateComponentColumnNames.Description.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[TemplateComponentColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string FamilyId
        {
            get { return InternalDataRowView[TemplateComponentColumnNames.FamilyId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[TemplateComponentColumnNames.FamilyId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string XRefferencePlaneId
        {
            get { return InternalDataRowView[TemplateComponentColumnNames.XRefferencePlaneId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[TemplateComponentColumnNames.XRefferencePlaneId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string YRefferencePlaneId
        {
            get { return InternalDataRowView[TemplateComponentColumnNames.YRefferencePlaneId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[TemplateComponentColumnNames.YRefferencePlaneId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string ZRefferencePlaneId
        {
            get { return InternalDataRowView[TemplateComponentColumnNames.ZRefferencePlaneId.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[TemplateComponentColumnNames.ZRefferencePlaneId.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public object DateCreated
        {
            get { return InternalDataRowView[TemplateComponentColumnNames.DateCreated.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[TemplateComponentColumnNames.DateCreated.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public object DateModified
        {
            get { return InternalDataRowView[TemplateComponentColumnNames.DateModified.ToString()]; }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[TemplateComponentColumnNames.DateModified.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string CreatedById
        {
            get { return InternalDataRowView[TemplateComponentColumnNames.CreatedById.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[TemplateComponentColumnNames.CreatedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public string ModifiedById
        {
            get { return InternalDataRowView[TemplateComponentColumnNames.ModifiedById.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[TemplateComponentColumnNames.ModifiedById.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }

        public FamilyTemplateComponent(DataRowView rowView) : base(rowView)
        {
        }
    }
}
