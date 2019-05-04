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
    public class ScoringParameter : BaseObject
    {
        public ScoringParameter(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private ScoringParameterGroup _mGroup;
        [Association("ScoringParameterGroup-ScoringParameters")]
        public ScoringParameterGroup Group
        {
            get { return _mGroup; }
            set { SetPropertyValue("Group", ref _mGroup, value); }
        }

        private string _mName;
        public string Name
        {
            get { return _mName; }
            set { SetPropertyValue("Name", ref _mName, value); }
        }

        public string ParameterTextView
        {
            get { return "{" + Name + "} " + OperatorString; }
        }

        public string ParameterExpressionView
        {
            get { return Value.ToString() + OperatorString; }
        }

        private int _mSequenceNumber;
        public int SequenceNumber
        {
            get { return _mSequenceNumber; }
            set { SetPropertyValue("SequenceNumber", ref _mSequenceNumber, value); }
        }

        private double _mValue;
        public double Value
        {
            get { return _mValue; }
            set { SetPropertyValue("Value", ref _mValue, value); }
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
                        return "/";
                    default:
                        return "";
                }
            }
        }
    }

    public enum Operator
    {
        None = 0,
        Add = 1,
        Subtract = 2,
        Multiply = 3,
        Divide = 4
    }
}