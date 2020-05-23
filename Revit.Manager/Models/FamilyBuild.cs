using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBox.FamFactory.Revit.Manager
{
    public class FamilyBuild : ModelBase<FamilyBuild>
    {
        public enum FamilyBuildsColumnNames { Id, Name, Description, FamilyId }
        public string Id { get { return InternalDataRowView[FamilyBuildsColumnNames.Id.ToString()].ToString(); } set { InternalDataRowView[FamilyBuildsColumnNames.Id.ToString()] = value; NotifyPropertyChanged(); } }

        public string Name
        {
            get { return InternalDataRowView[FamilyBuildsColumnNames.Name.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyBuildsColumnNames.Name.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }
        public string Description
        {
            get { return InternalDataRowView[FamilyBuildsColumnNames.Description.ToString()].ToString(); }
            set { InternalDataRowView.BeginEdit(); InternalDataRowView[FamilyBuildsColumnNames.Description.ToString()] = value; NotifyPropertyChanged(); _ValuesChanged = true; NotifyPropertyChanged("ValuesChanged"); }
        }        

        public FamilyBuild(DataRowView rowView) : base(rowView)
        {

        }

        public static FamilyBuild newFamilyBuild(DataView rowView)
        {
            DataRowView row = rowView.AddNew();

            FamilyBuild build = new FamilyBuild(row);
            build.Id = Guid.NewGuid().ToString();
            return build;
        }
    }
}
