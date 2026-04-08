namespace MyClubB
{
    partial class MyClub
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnMenu = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBusInfo = new System.Windows.Forms.Button();
            this.btnMyAccount = new System.Windows.Forms.Button();
            this.pnInfo = new System.Windows.Forms.Panel();
            this.pnContent = new System.Windows.Forms.Panel();
            this.btnChatting = new System.Windows.Forms.Button();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pnMenu.SuspendLayout();
            this.pnInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.White;
            this.pnMenu.Controls.Add(this.btnChatting);
            this.pnMenu.Controls.Add(this.btnExit);
            this.pnMenu.Controls.Add(this.btnBusInfo);
            this.pnMenu.Controls.Add(this.btnMyAccount);
            this.pnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMenu.Location = new System.Drawing.Point(2, 2);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(61, 567);
            this.pnMenu.TabIndex = 0;
            this.pnMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnMenu_MouseDown);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(8, 513);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(41, 39);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBusInfo
            // 
            this.btnBusInfo.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBusInfo.Location = new System.Drawing.Point(8, 69);
            this.btnBusInfo.Name = "btnBusInfo";
            this.btnBusInfo.Size = new System.Drawing.Size(41, 39);
            this.btnBusInfo.TabIndex = 1;
            this.btnBusInfo.Text = "BUS";
            this.btnBusInfo.UseVisualStyleBackColor = true;
            this.btnBusInfo.Click += new System.EventHandler(this.btnBusInfo_Click);
            // 
            // btnMyAccount
            // 
            this.btnMyAccount.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMyAccount.Location = new System.Drawing.Point(8, 12);
            this.btnMyAccount.Name = "btnMyAccount";
            this.btnMyAccount.Size = new System.Drawing.Size(41, 39);
            this.btnMyAccount.TabIndex = 0;
            this.btnMyAccount.Text = "MY";
            this.btnMyAccount.UseVisualStyleBackColor = true;
            this.btnMyAccount.Click += new System.EventHandler(this.btnMyAccount_Click);
            // 
            // pnInfo
            // 
            this.pnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnInfo.Controls.Add(this.lblUserName);
            this.pnInfo.Controls.Add(this.lblUserId);
            this.pnInfo.Controls.Add(this.lblServiceName);
            this.pnInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnInfo.Location = new System.Drawing.Point(63, 2);
            this.pnInfo.Name = "pnInfo";
            this.pnInfo.Size = new System.Drawing.Size(333, 64);
            this.pnInfo.TabIndex = 1;
            // 
            // pnContent
            // 
            this.pnContent.AutoScroll = true;
            this.pnContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(63, 66);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(333, 503);
            this.pnContent.TabIndex = 2;
            // 
            // btnChatting
            // 
            this.btnChatting.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChatting.Location = new System.Drawing.Point(8, 129);
            this.btnChatting.Name = "btnChatting";
            this.btnChatting.Size = new System.Drawing.Size(41, 39);
            this.btnChatting.TabIndex = 3;
            this.btnChatting.Text = "CHAT";
            this.btnChatting.UseVisualStyleBackColor = true;
            this.btnChatting.Click += new System.EventHandler(this.btnChatting_Click);
            // 
            // lblServiceName
            // 
            this.lblServiceName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblServiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblServiceName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblServiceName.Location = new System.Drawing.Point(0, 0);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(151, 64);
            this.lblServiceName.TabIndex = 0;
            this.lblServiceName.Text = "lblServiceName";
            this.lblServiceName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserId
            // 
            this.lblUserId.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUserId.Font = new System.Drawing.Font("굴림", 12F);
            this.lblUserId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUserId.Location = new System.Drawing.Point(151, 0);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(182, 31);
            this.lblUserId.TabIndex = 1;
            this.lblUserId.Text = "lblUserId";
            this.lblUserId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            this.lblUserName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUserName.Font = new System.Drawing.Font("굴림", 12F);
            this.lblUserName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUserName.Location = new System.Drawing.Point(151, 33);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(182, 31);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "lblUserName";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MyClub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(398, 571);
            this.Controls.Add(this.pnContent);
            this.Controls.Add(this.pnInfo);
            this.Controls.Add(this.pnMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyClub";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "MyClub";
            this.pnMenu.ResumeLayout(false);
            this.pnInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMenu;
        private System.Windows.Forms.Button btnBusInfo;
        private System.Windows.Forms.Button btnMyAccount;
        private System.Windows.Forms.Panel pnInfo;
        private System.Windows.Forms.Panel pnContent;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnChatting;
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserId;
    }
}