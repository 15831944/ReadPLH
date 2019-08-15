namespace WindowsFormsApp1.LogIn
{
    partial class frmLogIn
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogIn));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edtPswd = new DevExpress.XtraEditors.TextEdit();
            this.edtUserId = new DevExpress.XtraEditors.TextEdit();
            this.SqlUserCheck = new Npgsql.NpgsqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPswd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "64-64-a184466d26d30f5586da52e444502b9b-equalizer.png");
            this.imageCollection1.Images.SetKeyName(1, "application_vnd_oasis_opendocument_presentation_template.png");
            this.imageCollection1.Images.SetKeyName(2, "apply_32x32.png");
            this.imageCollection1.Images.SetKeyName(3, "cancel_32x32.png");
            this.imageCollection1.Images.SetKeyName(4, "iconfinder_Search_icon_2541673.png");
            this.imageCollection1.Images.SetKeyName(5, "if_new-folder-desktop_111252.png");
            this.imageCollection1.Images.SetKeyName(6, "if_stock_save_79620.png");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.edtPswd);
            this.panelControl1.Controls.Add(this.edtUserId);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(706, 329);
            this.panelControl1.TabIndex = 4;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(484, 181);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 51);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "로그인";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(320, 214);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 15);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "비밀번호";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(315, 187);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 15);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "사용자 ID";
            // 
            // edtPswd
            // 
            this.edtPswd.EditValue = "1234";
            this.edtPswd.Location = new System.Drawing.Point(378, 211);
            this.edtPswd.Name = "edtPswd";
            this.edtPswd.Properties.MaxLength = 8;
            this.edtPswd.Properties.PasswordChar = '*';
            this.edtPswd.Size = new System.Drawing.Size(100, 22);
            this.edtPswd.TabIndex = 1;
            // 
            // edtUserId
            // 
            this.edtUserId.EditValue = "cjooni";
            this.edtUserId.Location = new System.Drawing.Point(378, 184);
            this.edtUserId.Name = "edtUserId";
            this.edtUserId.Size = new System.Drawing.Size(100, 22);
            this.edtUserId.TabIndex = 0;
            // 
            // SqlUserCheck
            // 
            this.SqlUserCheck.AllResultTypesAreUnknown = false;
            this.SqlUserCheck.Transaction = null;
            this.SqlUserCheck.UnknownResultTypeList = null;
            // 
            // frmLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(706, 352);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPswd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserId.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit edtPswd;
        public DevExpress.XtraEditors.TextEdit edtUserId;
        private Npgsql.NpgsqlCommand SqlUserCheck;
    }
}
