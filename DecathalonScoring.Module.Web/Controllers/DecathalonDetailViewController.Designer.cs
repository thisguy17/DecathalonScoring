namespace DecathalonScoring.Module.Web.Controllers
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
            this.DecathalonDetailViewController_AddScoreAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // DecathalonDetailViewController_AddScoreAction
            // 
            this.DecathalonDetailViewController_AddScoreAction.Caption = "Add Score";
            this.DecathalonDetailViewController_AddScoreAction.Category = "Processes";
            this.DecathalonDetailViewController_AddScoreAction.ConfirmationMessage = null;
            this.DecathalonDetailViewController_AddScoreAction.Id = "DecathalonDetailViewController_AddScoreAction";
            this.DecathalonDetailViewController_AddScoreAction.ToolTip = null;
            this.DecathalonDetailViewController_AddScoreAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.DecathalonDetailViewController_AddScoreAction_Execute);
            // 
            // DecathalonDetailViewController
            // 
            this.Actions.Add(this.DecathalonDetailViewController_AddScoreAction);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction DecathalonDetailViewController_AddScoreAction;
    }
}
