namespace MyClubB
{
    partial class Form1
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
            this.gBoxMyInfo = new System.Windows.Forms.GroupBox();
            this.picMyImage = new System.Windows.Forms.PictureBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.gBoxMyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMyImage)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxMyInfo
            // 
            this.gBoxMyInfo.Controls.Add(this.picMyImage);
            this.gBoxMyInfo.Location = new System.Drawing.Point(40, 37);
            this.gBoxMyInfo.Name = "gBoxMyInfo";
            this.gBoxMyInfo.Size = new System.Drawing.Size(241, 298);
            this.gBoxMyInfo.TabIndex = 0;
            this.gBoxMyInfo.TabStop = false;
            this.gBoxMyInfo.Text = "내정보";
            // 
            // picMyImage
            // 
            this.picMyImage.Location = new System.Drawing.Point(20, 20);
            this.picMyImage.Name = "picMyImage";
            this.picMyImage.Size = new System.Drawing.Size(203, 262);
            this.picMyImage.TabIndex = 0;
            this.picMyImage.TabStop = false;
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(287, 72);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(54, 12);
            this.lblUserId.TabIndex = 1;
            this.lblUserId.Text = "lblUserId";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(287, 97);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(78, 12);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "lblUserName";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(287, 123);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(50, 12);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "lblEmail";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.gBoxMyInfo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gBoxMyInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMyImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxMyInfo;
        private System.Windows.Forms.PictureBox picMyImage;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblEmail;
    }
}

