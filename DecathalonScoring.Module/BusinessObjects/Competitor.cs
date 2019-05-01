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
    [DefaultProperty("FullName")]
    public class Competitor : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Competitor(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _mFirstName;
        public string FirstName
        {
            get { return _mFirstName; }
            set { SetPropertyValue("FirstName", ref _mFirstName, value); }
        }

        private string _mLastName;
        public string LastName
        {
            get { return _mLastName; }
            set { SetPropertyValue("LastName", ref _mLastName, value); }
        }

        private string _mNickName;
        public string NickName
        {
            get { return _mNickName; }
            set { SetPropertyValue("NickName", ref _mNickName, value); }
        }

        public string FullName
        {
            get { return string.IsNullOrEmpty(NickName) ? FirstName + " \"" + NickName + "\" " + LastName : FirstName + " " + LastName; }
        }

        [Association("Competitor-Scores")]
        public XPCollection<EventScore> Scores
        {
            get { return GetCollection<EventScore>("Scores"); }
        }

        [Association("Decathalons-Competitors")]
        public XPCollection<Decathalon> Decathalons
        {
            get { return GetCollection<Decathalon>("Decathalons"); }
        }
    }
}