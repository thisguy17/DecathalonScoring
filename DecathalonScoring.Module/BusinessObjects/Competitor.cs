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
using System.IO;

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

        private FileData _mCompetitorImage;
        [FileTypeFilter("ImagesOnly", new string[] { ".jpg", ".jpeg", ".png", ".bmp" })]
        [VisibleInListView(false)]
        public FileData CompetitorImage
        {
            get { return _mCompetitorImage; }
            set { SetPropertyValue("CompetitorImage", ref _mCompetitorImage, value); }
        }

        private Image _mImage;
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, ListViewImageEditorCustomHeight = 40)]
        public Image Image
        {
            get
            {
                if (_mImage == null && CompetitorImage != null && CompetitorImage.Size > 0)
                {
                    try
                    {
                        MemoryStream stream = new MemoryStream();
                        CompetitorImage.SaveToStream(stream);
                        stream.Position = 0;
                        _mImage = Image.FromStream(stream);
                    }
                    catch (Exception e)
                    {
                        throw new UserFriendlyException("Could not load image..." + Environment.NewLine + e.Message);
                    }
                    return _mImage;
                }
                return null;
            }
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

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (propertyName == "CompetitorImage") _mImage = null;
        }
    }
}