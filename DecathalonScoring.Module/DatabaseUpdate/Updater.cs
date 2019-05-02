using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;

namespace DecathalonScoring.Module.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            //string name = "MyName";
            //DomainObject1 theObject = ObjectSpace.FindObject<DomainObject1>(CriteriaOperator.Parse("Name=?", name));
            //if(theObject == null) {
            //    theObject = ObjectSpace.CreateObject<DomainObject1>();
            //    theObject.Name = name;
            //}

            //ObjectSpace.CommitChanges(); //Uncomment this line to persist created object(s).
            PermissionPolicyRole adminRole = ObjectSpace.GetObjects<PermissionPolicyRole>(CriteriaOperator.Parse("Name = ?", "Admin")).FirstOrDefault();
            if(adminRole == null)
            {
                adminRole = new PermissionPolicyRole(((XPObjectSpace)ObjectSpace).Session);
                adminRole.Name = "Admin";
                adminRole.IsAdministrative = true;
            }
            PermissionPolicyUser adminUser = ObjectSpace.GetObjects<PermissionPolicyUser>(CriteriaOperator.Parse("UserName = ?", "Admin")).FirstOrDefault();
            if (adminUser == null)
            {
                adminUser = new PermissionPolicyUser(((XPObjectSpace)ObjectSpace).Session);
                adminUser.UserName = "Admin";
                adminUser.Roles.Add(adminRole);
            }

            ObjectSpace.CommitChanges();
        }
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
    }
}
