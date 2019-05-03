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
using DevExpress.ExpressApp.Xpo;

namespace DecathalonScoring.Module.BusinessObjects.Nonpersistent
{
    [NonPersistent]
    public class Leaderboard : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Leaderboard(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        public void SetDecathalon(Decathalon value)
        {
            SetPropertyValue("Decathalon", ref _mDecathalon, value);
        }
        private Decathalon _mDecathalon;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [NonPersistent]
        public Decathalon Decathalon
        {
            get { return _mDecathalon; }
        }

        public void SetLeadCompetitors(XPCollection<DecathalonScoreTotals> value)
        {
            _mLeadCompetitors = value;
        }
        private XPCollection<DecathalonScoreTotals> _mLeadCompetitors;
        [NonPersistent]
        public XPCollection<DecathalonScoreTotals> LeadCompetitors
        {
            get
            {
                return _mLeadCompetitors;
            }
        }

        public void UpdateLeaderBoard(XPObjectSpace os)
        {
            if (Decathalon != null)
            {
                var leadCompetitors = new XPCollection<DecathalonScoreTotals>(os.Session);
                leadCompetitors.LoadingEnabled = false;
                foreach (var competitor in Decathalon.Competitors.Where(c => c.Scores.Count > 0))
                {
                    DecathalonScoreTotals dst = new DecathalonScoreTotals(os.Session);
                    dst.SetCompetitor(os.GetObject(competitor));
                    dst.SetDecathalon(os.GetObject(Decathalon));
                    dst.UpdateEventScores();
                    leadCompetitors.Add(dst);
                }
                SetLeadCompetitors(leadCompetitors);
            }
        }
    }
}