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

namespace DecathalonScoring.Module.BusinessObjects.Nonpersistent
{
    [NonPersistent]
    public class DecathalonEventParameters : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public DecathalonEventParameters(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        
        private double _mParameterA;
        public double ParameterA
        {
            get { return _mParameterA; }
            set { SetPropertyValue("ParameterA", ref _mParameterA, value); }
        }
        
        private double _mParameterB;
        public double ParameterB
        {
            get { return _mParameterB; }
            set { SetPropertyValue("ParameterB", ref _mParameterB, value); }
        }

        private double _mParameterC;
        public double ParameterC
        {
            get { return _mParameterC; }
            set { SetPropertyValue("ParameterC", ref _mParameterC, value); }
        }
    }
}