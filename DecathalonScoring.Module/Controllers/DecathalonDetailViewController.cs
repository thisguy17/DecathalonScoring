using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecathalonScoring.Module.BusinessObjects;
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
    public partial class DecathalonDetailViewController : ViewController
    {
        public DecathalonDetailViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(Decathalon);
            TargetViewType = ViewType.DetailView;
        }

        public Decathalon ThisCurrentObject
        {
            get { return (Decathalon)View.CurrentObject; }
        }

        public DetailView ThisDetailView
        {
            get { return (DetailView)View; }
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            if (ThisDetailView.ViewEditMode != ViewEditMode.Edit)
            {
                ThisDetailView.ViewEditMode = ViewEditMode.Edit;
            }
            ListPropertyEditor scoresLpe = (ListPropertyEditor)ThisDetailView.FindItem("Events");
            if (scoresLpe != null && scoresLpe.GetType() == typeof(ListPropertyEditor))
            {
                if (scoresLpe.Frame != null)
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
            //if (e.CreatedObject.GetType() == typeof(DecathalonEventDefinition))
            //{
            //    ((DecathalonEventDefinition)e.CreatedObject).Decathalon = e.ObjectSpace.GetObject(ThisCurrentObject);
            //    ((DecathalonEventDefinition)e.CreatedObject).EventDate = ThisCurrentObject.DecathalonStartDate > DateTime.Today ? ThisCurrentObject.DecathalonStartDate : DateTime.Today;
            //    foreach(var competitor in ThisCurrentObject.Competitors)
            //    {
            //        if(((DecathalonEventDefinition)e.CreatedObject).EventScores.Where(s => s.Competitor == competitor).Count() == 0)
            //        {
            //            EventScore newScore = new EventScore(((XPObjectSpace)e.ObjectSpace).Session);
            //            newScore.Competitor = e.ObjectSpace.GetObject(competitor);
            //            newScore.Event = (DecathalonEventDefinition)e.CreatedObject;
            //            ((DecathalonEventDefinition)e.CreatedObject).EventScores.Add(newScore);
            //        }
            //    }
            //}
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
