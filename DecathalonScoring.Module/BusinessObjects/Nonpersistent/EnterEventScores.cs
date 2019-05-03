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
using DecathalonScoring.Module.BusinessObjects.Nonpersistent;

namespace DecathalonScoring.Module.BusinessObjects
{
    [NonPersistent]
    public class EnterEventScores : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public EnterEventScores(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private Competitor _mCompetitor;
        public Competitor Competitor
        {
            get { return _mCompetitor; }
            set
            {
                SetPropertyValue("Competitor", ref _mCompetitor, value);
            }
        }

        public void SetEvent(DecathalonEvent value)
        {
            SetPropertyValue("Event", ref _mEvent, value);
        }
        private DecathalonEvent _mEvent;
        public DecathalonEvent Event
        {
            get { return _mEvent; }
        }

        public string Equation
        {
            get { return Event.Definition.ScoringCalculationText; }
        }

        private string _mNotes;
        [Size(SizeAttribute.Unlimited)]
        public string Notes
        {
            get { return _mNotes; }
            set { SetPropertyValue("Notes", ref _mNotes, value); }
        }

        public void SetScoreParameters(XPCollection<NewEventScore> value)
        {
            SetPropertyValue("ScoreParameters", ref _mScoreParameters, value);
        }
        private XPCollection<NewEventScore> _mScoreParameters;
        public XPCollection<NewEventScore> ScoreParameters
        {
            get { return _mScoreParameters; }
        }

        public void UpdateScoreParameters()
        {
            XPCollection<NewEventScore> scoreParams = new XPCollection<NewEventScore>(Session);
            scoreParams.LoadingEnabled = false;
            foreach (var group in Event.Definition.ScoringParameterGroups)
            {
                foreach (var param in group.ScoringParameters.Where(p => p.Value == 0))
                {
                    var scoreParam = new NewEventScore(Session);
                    scoreParam.SetParameterName(param.Name);
                    scoreParam.SetSequence(param.SequenceNumber);
                    scoreParam.SetGroup(group.SequenceNumber);
                    scoreParams.Add(scoreParam);
                }
            }
            SetScoreParameters(scoreParams);
        }
    }
}