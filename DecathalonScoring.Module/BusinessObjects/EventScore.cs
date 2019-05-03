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
using System.Linq.Expressions;
using System.Data;

namespace DecathalonScoring.Module.BusinessObjects
{
    public class EventScore : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EventScore(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        
        private DecathalonEvent _mEvent;
        [Association("DecathalonEvent-EventScores")]
        public DecathalonEvent Event
        {
            get { return _mEvent; }
            set { SetPropertyValue("Event", ref _mEvent, value); }
        }

        public Decathalon Decathalon
        {
            get { return Event.Decathalon; }
        }
        
        public void SetPoints(double value)
        {
            SetPropertyValue("Points", ref _mPoints, value);
        }
        [Persistent("Points")]
        private double _mPoints;
        [PersistentAlias("_mPoints")]
        public double Points
        {
            get
            {
                return _mPoints;
            }
        }

        private Competitor _mCompetitor;
        [Association("Competitor-Scores")]
        public Competitor Competitor
        {
            get { return _mCompetitor; }
            set { SetPropertyValue("Competitor", ref _mCompetitor, value); }
        }

        private string _mNotes;
        [Size(SizeAttribute.Unlimited)]
        public string Notes
        {
            get { return _mNotes; }
            set { SetPropertyValue("Notes", ref _mNotes, value); }
        }
    }
}