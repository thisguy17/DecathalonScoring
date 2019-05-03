using System;
using System.Collections.Generic;
using System.Data;
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

namespace DecathalonScoring.Module.Web.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class EventDetailViewController : ViewController
    {
        public EventDetailViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(DecathalonEvent);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
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

        private void CreateScoreAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            XPObjectSpace os = (XPObjectSpace)Application.CreateObjectSpace(typeof(EnterEventScores));
            EnterEventScores obj = new EnterEventScores(os.Session);
            obj.SetEvent(os.GetObject((DecathalonEvent)View.CurrentObject));
            obj.UpdateScoreParameters();
            e.View = Application.CreateDetailView(os, obj, true);
        }

        private void CreateScoreAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            EventScore newScore = new EventScore(((XPObjectSpace)ObjectSpace).Session);
            EnterEventScores enterEventScores = (EnterEventScores)e.PopupWindowViewCurrentObject;
            DecathalonEvent selectedEvent = enterEventScores.Event;

            string expression = selectedEvent.Definition.ScoringParameterGroups.Count > 1 ? "(" : "";
            // TODO: Get Parameter values
            if (selectedEvent.Definition.ScoringParameterGroups.Count == 1 && selectedEvent.Definition.ScoringParameterGroups[0].ScoringParameters.Count == 1)
            {
                // Only one parameter
                expression += enterEventScores.ScoreParameters[0].Value;
            }
            else if (selectedEvent.Definition.ScoringParameterGroups.Count > 0)
            {
                foreach (var paramGroup in selectedEvent.Definition.ScoringParameterGroups.OrderBy(p => p.SequenceNumber))
                {
                    expression += "(";
                    foreach (var param in paramGroup.ScoringParameters.OrderBy(p => p.SequenceNumber))
                    {
                        if (param.Value == 0)
                        {
                            double doubleValue = enterEventScores.ScoreParameters.Where(p => p.Sequence == param.SequenceNumber && p.Group == paramGroup.SequenceNumber).FirstOrDefault().Value;

                            if (param.SequenceNumber == 1)
                            {
                                if (param.OperatorString != "")
                                {
                                    expression += doubleValue + " " + param.OperatorString;
                                }
                                else
                                {
                                    expression += doubleValue;
                                }
                            }
                            else if (param.SequenceNumber == paramGroup.ScoringParameters.Count)
                            {
                                expression += " " + doubleValue;
                            }
                            else
                            {
                                expression += " " + doubleValue + " " + param.OperatorString;
                            }
                        }
                        else
                        {
                            if (param.SequenceNumber == 1)
                            {
                                if (param.OperatorString != "")
                                {
                                    expression += param.Value + " " + param.OperatorString;
                                }
                                else
                                {
                                    expression += param.Value;
                                }
                            }
                            else if (param.SequenceNumber == paramGroup.ScoringParameters.Count)
                            {
                                expression += " " + param.Value;
                            }
                            else
                            {
                                expression += " " + param.Value + " " + param.OperatorString;
                            }
                        }
                    }
                    expression += ") " + paramGroup.OperatorString;
                }
            }

            expression += selectedEvent.Definition.ScoringParameterGroups.Count > 1 ? ")" : "";

            // TODO: Set and show Points and save Score
            var dt = new DataTable();
            double points = 0;
            string resultString = dt.Compute(expression, "").ToString();
            double.TryParse(resultString, out points);

            newScore.Competitor = ObjectSpace.GetObject(enterEventScores.Competitor);
            newScore.Event = ObjectSpace.GetObject(selectedEvent);
            newScore.SetPoints(points);
            newScore.Notes += Environment.NewLine + "Calculated as: " + expression;

            ObjectSpace.CommitChanges();
        }
    }
}
