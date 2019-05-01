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
    public class ScoringParameterGroup : BaseObject
    { 
        public ScoringParameterGroup(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        DecathalonEventDefinition _mEvent;
        [Association("DecathalonEvent-ScoringParameterGroups")]
        public DecathalonEventDefinition Event
        {
            get { return _mEvent; }
            set { SetPropertyValue("Event", ref _mEvent, value); }
        }

        private int _mSequenceNumber;
        public int SequenceNumber
        {
            get { return _mSequenceNumber; }
            set { SetPropertyValue("SequenceNumber", ref _mSequenceNumber, value); }
        }

        public string GroupTextView
        {
            get
            {
                var parameterString = "";
                if(ScoringParameters != null && ScoringParameters.Count > 0)
                {
                    foreach (var parameter in ScoringParameters.OrderBy(p => p.SequenceNumber))
                    {
                        if (parameter.SequenceNumber == 1)
                        {
                            parameterString = "(";
                        }
                        parameterString += parameter.ParameterTextView;
                        if (parameter.SequenceNumber == ScoringParameters.Count)
                        {
                            parameterString += ")";
                        }
                    }
                    parameterString += " " + OperatorString;
                }
                return parameterString;
            }
        }

        public string GroupExpressionView
        {
            get
            {
                var parameterString = "";
                if (ScoringParameters != null && ScoringParameters.Count > 0)
                {
                    foreach (var parameter in ScoringParameters.OrderBy(p => p.SequenceNumber))
                    {
                        if (parameter.SequenceNumber == 1)
                        {
                            parameterString = "(";
                        }
                        parameterString += parameter.ParameterExpressionView;
                        if (parameter.SequenceNumber == ScoringParameters.Count)
                        {
                            parameterString += ")";
                        }
                    }
                    parameterString += " " + OperatorString;
                }
                return parameterString;
            }
        }

        private Operator _mOperatorValue;
        public Operator OperatorValue
        {
            get { return _mOperatorValue; }
            set { SetPropertyValue("OperatorValue", ref _mOperatorValue, value); }
        }

        public string OperatorString
        {
            get
            {
                switch (OperatorValue)
                {
                    case Operator.Add:
                        return "+";
                    case Operator.Subtract:
                        return "-";
                    case Operator.Multiply:
                        return "*";
                    case Operator.Divide:
                        return "//";
                    default:
                        return "";
                }
            }
        }

        [Association("ScoringParameterGroup-ScoringParameters"), DevExpress.Xpo.Aggregated]
        public XPCollection<ScoringParameter> ScoringParameters
        {
            get { return GetCollection<ScoringParameter>("ScoringParameters"); }
        }
    }
}