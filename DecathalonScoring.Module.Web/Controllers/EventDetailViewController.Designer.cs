namespace DecathalonScoring.Module.Web.Controllers
{
    partial class EventDetailViewController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CreateScoreAction = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // CreateScoreAction
            // 
            this.CreateScoreAction.AcceptButtonCaption = null;
            this.CreateScoreAction.CancelButtonCaption = null;
            this.CreateScoreAction.Caption = "Create Score";
            this.CreateScoreAction.Category = "Processes";
            this.CreateScoreAction.Id = "CreateScoreAction";
            this.CreateScoreAction.ToolTip = null;
            this.CreateScoreAction.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CreateScoreAction_CustomizePopupWindowParams);
            this.CreateScoreAction.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CreateScoreAction_Execute);
            // 
            // EventDetailViewController
            // 
            this.Actions.Add(this.CreateScoreAction);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CreateScoreAction;
    }
}
