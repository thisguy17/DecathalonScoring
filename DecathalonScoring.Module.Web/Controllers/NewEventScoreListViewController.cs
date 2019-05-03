using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecathalonScoring.Module.BusinessObjects.Nonpersistent;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Web.SystemModule;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace DecathalonScoring.Module.Web.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class NewEventScoreListViewController : ViewController
    {
        public NewEventScoreListViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(NewEventScore);
            TargetViewType = ViewType.ListView;
            TargetViewNesting = Nesting.Nested;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            ListViewProcessCurrentObjectController lvpcoc = Frame.GetController<ListViewProcessCurrentObjectController>();
            if(lvpcoc != null)
            {
                lvpcoc.CustomProcessSelectedItem += Lvpcoc_CustomProcessSelectedItem;
            }

            ListViewController listViewController = Frame.GetController<ListViewController>();
            if (listViewController != null)
            {
                listViewController.EditAction.Active["Deactivate"] = false;
            }
        }

        private void Lvpcoc_CustomProcessSelectedItem(object sender, CustomProcessListViewSelectedItemEventArgs e)
        {
            DetailView createdView = Application.CreateDetailView(ObjectSpace, (NewEventScore)View.CurrentObject, false);
            createdView.ViewEditMode = ViewEditMode.Edit;
            e.InnerArgs.ShowViewParameters.CreatedView = createdView;
            e.Handled = true;
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
