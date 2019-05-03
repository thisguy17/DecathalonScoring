﻿namespace DecathalonScoring.Module.Web.Controllers
{
    partial class DecathalonDetailViewController
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
            this.LeaderboardAction = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // LeaderboardAction
            // 
            this.LeaderboardAction.AcceptButtonCaption = null;
            this.LeaderboardAction.CancelButtonCaption = null;
            this.LeaderboardAction.Caption = "Leaderboard";
            this.LeaderboardAction.Category = "Processes";
            this.LeaderboardAction.ConfirmationMessage = null;
            this.LeaderboardAction.Id = "LeaderboardAction";
            this.LeaderboardAction.ToolTip = null;
            this.LeaderboardAction.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.LeaderboardAction_CustomizePopupWindowParams);
            this.LeaderboardAction.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.LeaderboardAction_Execute);
            // 
            // DecathalonDetailViewController
            // 
            this.Actions.Add(this.LeaderboardAction);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction LeaderboardAction;
    }
}
