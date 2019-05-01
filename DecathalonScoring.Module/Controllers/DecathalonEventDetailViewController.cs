using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecathalonScoring.Module.BusinessObjects;
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
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace DecathalonScoring.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class DecathalonEventDetailViewController : ViewController
    {
        public DecathalonEventDetailViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(DecathalonEvent);
            TargetViewType = ViewType.DetailView;
        }

        public DecathalonEvent ThisCurrentObject
        {
            get { return (DecathalonEvent)View.CurrentObject; }
        }

        public DetailView ThisDetailView
        {
            get { return (DetailView)View; }
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            if(ThisDetailView.ViewEditMode != ViewEditMode.Edit)
            {
                ThisDetailView.ViewEditMode = ViewEditMode.Edit;
            }

            ListPropertyEditor scoresLpe = (ListPropertyEditor)ThisDetailView.FindItem("EventScores");
            if (scoresLpe != null && scoresLpe.GetType() == typeof(ListPropertyEditor))
            {
                if(scoresLpe.Frame != null)
                {
                    NewObjectViewController controller = scoresLpe.Frame.GetController<NewObjectViewController>();
                    controller.ObjectCreated += controller_ObjectCreated;
                }
                else
                {
                    scoresLpe.ControlCreated += ScoresLpe_ControlCreated;
                }
            }
        }

        private void ScoresLpe_ControlCreated(object sender, EventArgs e)
        {
            NewObjectViewController controller = ((ListPropertyEditor)sender).Frame.GetController<NewObjectViewController>();
            controller.ObjectCreated += controller_ObjectCreated;
        }

        private void controller_ObjectCreated(object sender, ObjectCreatedEventArgs e)
        {
            if (e.CreatedObject.GetType() == typeof(EventScore))
            {
                ((EventScore)e.CreatedObject).Event = e.ObjectSpace.GetObject(ThisCurrentObject);
            }
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

        //private void SetEventParametersAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        //{
        //    ThisCurrentObject.SetParameterA(((DecathalonEventParameters)e.PopupWindowViewCurrentObject).ParameterA);
        //    ThisCurrentObject.SetParameterB(((DecathalonEventParameters)e.PopupWindowViewCurrentObject).ParameterB);
        //    ThisCurrentObject.SetParameterC(((DecathalonEventParameters)e.PopupWindowViewCurrentObject).ParameterC);
        //    ObjectSpace.CommitChanges();
        //}

        //private void SetEventParametersAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        //{
        //    DecathalonEventParameters parametersObj = new DecathalonEventParameters(((XPObjectSpace)ObjectSpace).Session);
        //    e.DialogController.SaveOnAccept = false;
        //    e.View = Application.CreateDetailView(ObjectSpace, parametersObj, false);
        //    ((DetailView)e.View).ViewEditMode = ViewEditMode.Edit;
        //}
    }
}
