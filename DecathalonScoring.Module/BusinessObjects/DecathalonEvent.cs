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
    [DefaultProperty("EventName")]
    public class DecathalonEvent : BaseObject
    {
        public DecathalonEvent(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private Decathalon _mDecathalon;
        [Association("Decathalon-Events")]
        public Decathalon Decathalon
        {
            get { return _mDecathalon; }
            set { SetPropertyValue("Decathalon", ref _mDecathalon, value); }
        }

        private string _mEventName;
        public string EventName
        {
            get { return _mEventName; }
            set { SetPropertyValue("EventName", ref _mEventName, value); }
        }

        private DateTime _mEventDate;
        public DateTime EventDate
        {
            get { return _mEventDate; }
            set { SetPropertyValue("EventDate", ref _mEventDate, value); }
        }

        private DecathalonEventDefinition _mDefinition;
        public DecathalonEventDefinition Definition
        {
            get { return _mDefinition; }
            set { SetPropertyValue("Definition", ref _mDefinition, value); }
        }

        [Association("DecathalonEvent-EventScores"), DevExpress.Xpo.Aggregated]
        public XPCollection<EventScore> EventScores
        {
            get { return GetCollection<EventScore>("EventScores"); }
        }
    }
}