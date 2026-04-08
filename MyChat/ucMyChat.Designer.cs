namespace MyClub.MyChat
{
    partial class ucMyChat
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnSearch = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpMessage = new System.Windows.Forms.FlowLayoutPanel();
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.rdoServer = new System.Windows.Forms.RadioButton();
            this.rdoClient = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.tboxValue_address = new System.Windows.Forms.TextBox();
            this.lblTitle_ip = new System.Windows.Forms.Label();
            this.pnSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnSearch
            // 
            this.pnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnSearch.Controls.Add(this.lblTitle_ip);
            this.pnSearch.Controls.Add(this.tboxValue_address);
            this.pnSearch.Controls.Add(this.btnStart);
            this.pnSearch.Controls.Add(this.rdoClient);
            this.pnSearch.Controls.Add(this.rdoServer);
            this.pnSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnSearch.Location = new System.Drawing.Point(0, 0);
            this.pnSearch.Name = "pnSearch";
            this.pnSearch.Padding = new System.Windows.Forms.Padding(5);
            this.pnSearch.Size = new System.Drawing.Size(446, 77);
            this.pnSearch.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.rtbMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 779);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(446, 97);
            this.panel1.TabIndex = 2;
            // 
            // flpMessage
            // 
            this.flpMessage.AutoScroll = true;
            this.flpMessage.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.flpMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMessage.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMessage.Location = new System.Drawing.Point(0, 77);
            this.flpMessage.Name = "flpMessage";
            this.flpMessage.Padding = new System.Windows.Forms.Padding(2);
            this.flpMessage.Size = new System.Drawing.Size(446, 702);
            this.flpMessage.TabIndex = 3;
            this.flpMessage.WrapContents = false;
            // 
            // rtbMessage
            // 
            this.rtbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMessage.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rtbMessage.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.rtbMessage.Location = new System.Drawing.Point(2, 2);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.Size = new System.Drawing.Size(442, 93);
            this.rtbMessage.TabIndex = 0;
            this.rtbMessage.Text = "";
            this.rtbMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbMessage_KeyDown);
            // 
            // rdoServer
            // 
            this.rdoServer.AutoSize = true;
            this.rdoServer.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoServer.Location = new System.Drawing.Point(21, 15);
            this.rdoServer.Name = "rdoServer";
            this.rdoServer.Size = new System.Drawing.Size(114, 19);
            this.rdoServer.TabIndex = 0;
            this.rdoServer.Text = "서버/클라이언트";
            this.rdoServer.UseVisualStyleBackColor = true;
            // 
            // rdoClient
            // 
            this.rdoClient.Checked = true;
            this.rdoClient.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoClient.Location = new System.Drawing.Point(21, 40);
            this.rdoClient.Name = "rdoClient";
            this.rdoClient.Size = new System.Drawing.Size(114, 24);
            this.rdoClient.TabIndex = 1;
            this.rdoClient.TabStop = true;
            this.rdoClient.Text = "클라이언트";
            this.rdoClient.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(353, 10);
            this.btnStart.Margin = new System.Windows.Forms.Padding(5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(83, 54);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "서버접속";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tboxValue_address
            // 
            this.tboxValue_address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxValue_address.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxValue_address.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tboxValue_address.Location = new System.Drawing.Point(141, 40);
            this.tboxValue_address.Name = "tboxValue_address";
            this.tboxValue_address.Size = new System.Drawing.Size(204, 22);
            this.tboxValue_address.TabIndex = 4;
            // 
            // lblTitle_ip
            // 
            this.lblTitle_ip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle_ip.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle_ip.Location = new System.Drawing.Point(141, 15);
            this.lblTitle_ip.Name = "lblTitle_ip";
            this.lblTitle_ip.Size = new System.Drawing.Size(204, 22);
            this.lblTitle_ip.TabIndex = 5;
            this.lblTitle_ip.Text = "서버 IP를 입력해주세요.";
            // 
            // ucMyChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpMessage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnSearch);
            this.Name = "ucMyChat";
            this.Size = new System.Drawing.Size(446, 876);
            this.pnSearch.ResumeLayout(false);
            this.pnSearch.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtbMessage;
        private System.Windows.Forms.FlowLayoutPanel flpMessage;
        private System.Windows.Forms.RadioButton rdoClient;
        private System.Windows.Forms.RadioButton rdoServer;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblTitle_ip;
        private System.Windows.Forms.TextBox tboxValue_address;
    }
}
