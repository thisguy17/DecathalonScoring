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
    public class NewEventScore : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public NewEventScore(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        
        public void SetParameterName(string value)
        {
            SetPropertyValue("ParameterName", ref _mParameterName, value);
        }
        private string _mParameterName;
        public string ParameterName
        {
            get { return _mParameterName; }
        }
        
        private double _mValue;
        public double Value
        {
            get { return _mValue; }
            set { SetPropertyValue("Value", ref _mValue, value); }
        }

        public void SetSequence(int value)
        {
            SetPropertyValue("Sequence", ref _mSequence, value);
        }
        private int _mSequence;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public int Sequence
        {
            get { return _mSequence; }
        }

        public void SetGroup(int value)
        {
            SetPropertyValue("Group", ref _mGroup, value);
        }
        private int _mGroup;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public int Group
        {
            get { return _mGroup; }
        }
    }
}