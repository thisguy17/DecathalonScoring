using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace DecathalonScoring.Module.Web.Controllers
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

        Decathalon ThisCurrentObject
        {
            get { return (Decathalon)View.CurrentObject; }
        }

        DetailView ThisDetailView
        {
            get { return (DetailView)View; }
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            //foreach (var scoreTotal in new XPCollection<DecathalonScoreTotals>(((XPObjectSpace)ObjectSpace).Session))
            //{
            //    scoreTotal.Delete();
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

        private void LeaderboardAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
        }

        private void LeaderboardAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            XPObjectSpace os = (XPObjectSpace)Application.CreateObjectSpace(typeof(Leaderboard));
            Leaderboard obj = new Leaderboard(os.Session);
            obj.SetDecathalon(os.GetObject(ThisCurrentObject));
            obj.UpdateLeaderBoard(os);
            e.View = Application.CreateDetailView(os, obj, true);
        }

        //private void DecathalonDetailViewController_AddScoreAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        //{
        //    EventScore newScore = new EventScore(((XPObjectSpace)ObjectSpace).Session);
        //    XtraInputBoxArgs args = new XtraInputBoxArgs();
        //    args.Caption = "Create New Score";

        //    // TODO: Get Decathalon Event
        //    args.Prompt = "Select Event:";
        //    args.DefaultButtonIndex = 0;

        //    ComboBoxEdit combo = new ComboBoxEdit();
        //    ComboBoxItemCollection coll = combo.Properties.Items;
        //    coll.BeginUpdate();
        //    try
        //    {
        //        foreach(var xpoEvent in ThisCurrentObject.Events)
        //        {
        //            coll.Add(xpoEvent);
        //        }
        //    }
        //    finally
        //    {
        //        coll.EndUpdate();
        //    }
        //    combo.SelectedIndex = -1;

        //    args.Editor = combo;

        //    args.DefaultResponse = null;

        //    DecathalonEvent selectedEvent = (DecathalonEvent)XtraInputBox.Show(args);

        //    if(selectedEvent != null)
        //    {
        //        // TODO: Get Competitor
        //        args.Prompt = "Select Competitor:";
        //        args.DefaultButtonIndex = 0;

        //        combo = new ComboBoxEdit();
        //        coll = combo.Properties.Items;
        //        coll.BeginUpdate();
        //        try
        //        {
        //            foreach (var xpoCompetitor in new XPCollection<Competitor>(((XPObjectSpace)ObjectSpace).Session))
        //            {
        //                coll.Add(xpoCompetitor);
        //            }
        //        }
        //        finally
        //        {
        //            coll.EndUpdate();
        //        }
        //        combo.SelectedIndex = -1;

        //        args.Editor = combo;

        //        args.DefaultResponse = null;

        //        Competitor selectedCompetitor = (Competitor)XtraInputBox.Show(args);

        //        if(selectedCompetitor != null)
        //        {
        //            string expression = selectedEvent.Definition.ScoringParameterGroups.Count > 1 ? "(" : "";
        //            // TODO: Get Parameter values
        //            if(selectedEvent.Definition.ScoringParameterGroups.Count == 1 && selectedEvent.Definition.ScoringParameterGroups[0].ScoringParameters.Count == 1)
        //            {
        //                // Only one parameter
        //                args.Prompt = "Enter Performance Values:" + selectedEvent.Definition.ScoringParameterGroups[0].ScoringParameters[0].Name;
        //                args.DefaultButtonIndex = 0;
        //                DoubleEdit dEdit = new DoubleEdit();
        //                args.Editor = dEdit;
        //                double doubleValue = 0;
        //                double.TryParse(XtraInputBox.Show(args).ToString(), out doubleValue);
        //                expression += doubleValue;
        //            }
        //            else if(selectedEvent.Definition.ScoringParameterGroups.Count > 0)
        //            {
        //                foreach (var paramGroup in selectedEvent.Definition.ScoringParameterGroups.OrderBy(p => p.SequenceNumber))
        //                {
        //                    expression += "(";
        //                    foreach (var param in paramGroup.ScoringParameters.OrderBy(p => p.SequenceNumber))
        //                    {
        //                        if (param.Value == 0)
        //                        {
        //                            args.Prompt = "Enter Performance Values:" + param.Name;
        //                            args.DefaultButtonIndex = 0;
        //                            DoubleEdit dEdit = new DoubleEdit();
        //                            args.Editor = dEdit;
        //                            double doubleValue = 0;
        //                            double.TryParse(XtraInputBox.Show(args).ToString(), out doubleValue);

        //                            if (param.SequenceNumber == 1)
        //                            {
        //                                if(param.OperatorString != "")
        //                                {
        //                                    expression += doubleValue + " " + param.OperatorString;
        //                                }
        //                                else
        //                                {
        //                                    expression += doubleValue;
        //                                }
        //                            }
        //                            else if (param.SequenceNumber == paramGroup.ScoringParameters.Count)
        //                            {
        //                                expression += " " + doubleValue;
        //                            }
        //                            else
        //                            {
        //                                expression += " " + doubleValue + " " + param.OperatorString;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (param.SequenceNumber == 1)
        //                            {
        //                                if (param.OperatorString != "")
        //                                {
        //                                    expression += param.Value + " " + param.OperatorString;
        //                                }
        //                                else
        //                                {
        //                                    expression += param.Value;
        //                                }
        //                            }
        //                            else if (param.SequenceNumber == paramGroup.ScoringParameters.Count)
        //                            {
        //                                expression += " " + param.Value;
        //                            }
        //                            else
        //                            {
        //                                expression += " " + param.Value + " " + param.OperatorString;
        //                            }
        //                        }
        //                    }
        //                    expression += ") " + paramGroup.OperatorString;
        //                }
        //            }

        //            expression += selectedEvent.Definition.ScoringParameterGroups.Count > 1 ? ")" : "";

        //            // TODO: Set and show Points and save Score
        //            var dt = new DataTable();
        //            double points = 0;
        //            string resultString = dt.Compute(expression, "").ToString();
        //            double.TryParse(resultString, out points);

        //            newScore.Competitor = selectedCompetitor;
        //            newScore.Event = selectedEvent;
        //            newScore.SetPoints(points);
        //            newScore.Notes += Environment.NewLine + "Calculated as: " + expression;

        //            ObjectSpace.CommitChanges();
        //        }
        //    }
        //}
    }
}
