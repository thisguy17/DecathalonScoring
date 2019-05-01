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
    [DefaultClassOptions]
    [DefaultProperty("DecathalonName")]
    public class Decathalon : BaseObject
    {
        public Decathalon(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _mDecathalonName;
        public string DecathalonName
        {
            get { return _mDecathalonName; }
            set { SetPropertyValue("DecathalonName", ref _mDecathalonName, value); }
        }

        private DateTime _mDecathalonStartDate;
        public DateTime DecathalonStartDate
        {
            get { return _mDecathalonStartDate; }
            set { SetPropertyValue("DecathalonStartDate", ref _mDecathalonStartDate, value); }
        }

        private DateTime _mDecathalonEndDate;
        public DateTime DecathalonEndDate
        {
            get { return _mDecathalonStartDate; }
            set { SetPropertyValue("DecathalonEndDate", ref _mDecathalonEndDate, value); }
        }

        [Association("Decathalon-Events")]
        public XPCollection<DecathalonEvent> Events
        {
            get { return GetCollection<DecathalonEvent>("Events"); }
        }

        [Association("Decathalons-Competitors")]
        public XPCollection<Competitor> Competitors
        {
            get { return GetCollection<Competitor>("Competitors"); }
        }
    }
}