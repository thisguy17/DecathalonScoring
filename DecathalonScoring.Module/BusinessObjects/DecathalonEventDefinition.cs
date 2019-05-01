using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace DecathalonScoring.Module.BusinessObjects
{
    public class DecathalonEventDefinition : BaseObject
    {
        public DecathalonEventDefinition(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _mEventName;
        public string EventName
        {
            get { return _mEventName; }
            set { SetPropertyValue("EventName", ref _mEventName, value); }
        }

        public string ScoringCalculationText
        {
            get
            {
                var calculationString = "";
                if (ScoringParameterGroups != null && ScoringParameterGroups.Count > 1)
                {
                    foreach (var parameterGroup in ScoringParameterGroups.OrderBy(p => p.SequenceNumber))
                    {
                        if (parameterGroup.SequenceNumber == 1)
                        {
                            calculationString = "(";
                        }
                        calculationString += parameterGroup.GroupTextView;
                        if (parameterGroup.SequenceNumber == ScoringParameterGroups.Count)
                        {
                            calculationString += ")";
                        }
                    }
                }
                else if (ScoringParameterGroups != null && ScoringParameterGroups.Count == 1)
                {
                    calculationString = ScoringParameterGroups[0].GroupTextView;
                }
                return calculationString;
            }
        }

        public string ScoringCalculationExpression
        {
            get
            {
                var calculationString = "";
                if (ScoringParameterGroups != null && ScoringParameterGroups.Count > 1)
                {
                    foreach (var parameterGroup in ScoringParameterGroups.OrderBy(p => p.SequenceNumber))
                    {
                        if (parameterGroup.SequenceNumber == 1)
                        {
                            calculationString = "(";
                        }
                        calculationString += parameterGroup.GroupExpressionView;
                        if (parameterGroup.SequenceNumber == ScoringParameterGroups.Count)
                        {
                            calculationString += ")";
                        }
                    }
                }
                else if (ScoringParameterGroups != null && ScoringParameterGroups.Count == 1)
                {
                    calculationString = ScoringParameterGroups[0].GroupExpressionView;
                }
                return calculationString;
            }
        }

        [Association("DecathalonEvent-ScoringParameterGroups"), DevExpress.Xpo.Aggregated]
        public XPCollection<ScoringParameterGroup> ScoringParameterGroups
        {
            get { return GetCollection<ScoringParameterGroup>("ScoringParameterGroups"); }
        }

        //[Association("DecathalonEvent-PerformanceParameterGroups"), DevExpress.Xpo.Aggregated]
        //public XPCollection<PerformanceParameterGroup> PerformanceParameterGroups
        //{
        //    get { return GetCollection<PerformanceParameterGroup>("PerformanceParameterGroups"); }
        //}
    }
}