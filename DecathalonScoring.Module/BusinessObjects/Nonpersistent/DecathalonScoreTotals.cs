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
using System.Drawing;

namespace DecathalonScoring.Module.BusinessObjects.Nonpersistent
{
    [NonPersistent]
    public class DecathalonScoreTotals : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public DecathalonScoreTotals(Session session)
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

        public void SetCompetitor(Competitor value)
        {
            SetPropertyValue("Competitor", ref _mCompetitor, value);
        }
        private Competitor _mCompetitor;
        [NonPersistent]
        public Competitor Competitor
        {
            get { return _mCompetitor; }
        }

        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, ListViewImageEditorCustomHeight = 40)]
        public Image Image
        {
            get
            {
                if(Competitor == null)
                {
                    return null;
                }
                return Competitor.Image;
            }
        }

        public double TotalDecathalonPoints
        {
            get
            {
                if(EventScores == null)
                {
                    return 0;
                }
                return EventScores.Where(s => s.Event.Decathalon == Decathalon).Sum(cs => cs.Points);
            }
        }

        public void SetEventScores(XPCollection<EventScore> value)
        {
            SetPropertyValue("EventScores", ref _mEventScores, value);
        }
        private XPCollection<EventScore> _mEventScores;
        [NonPersistent]
        public XPCollection<EventScore> EventScores
        {
            get
            {
                return _mEventScores;
            }
        }

        public void UpdateEventScores()
        {
            if(Decathalon != null)
            {
                var eventScores = new XPCollection<EventScore>(Competitor.Scores, CriteriaOperator.Parse("[Decathalon] = ?", Decathalon));
                eventScores.LoadingEnabled = false;
                SetEventScores(eventScores);
            }
        }
    }
}