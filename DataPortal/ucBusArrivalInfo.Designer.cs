namespace MyClubB.DataPortal
{
    partial class ucBusArrivalInfo
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.tBox_keyword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flpArrivalList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnSearch
            // 
            this.pnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnSearch.Controls.Add(this.btnSearch);
            this.pnSearch.Controls.Add(this.tBox_keyword);
            this.pnSearch.Controls.Add(this.label1);
            this.pnSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnSearch.Location = new System.Drawing.Point(0, 0);
            this.pnSearch.Name = "pnSearch";
            this.pnSearch.Size = new System.Drawing.Size(287, 63);
            this.pnSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(195, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 36);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tBox_keyword
            // 
            this.tBox_keyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBox_keyword.Location = new System.Drawing.Point(47, 23);
            this.tBox_keyword.Name = "tBox_keyword";
            this.tBox_keyword.Size = new System.Drawing.Size(142, 21);
            this.tBox_keyword.TabIndex = 1;
            this.tBox_keyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBox_keyword_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "정류장";
            // 
            // flpArrivalList
            // 
            this.flpArrivalList.AutoScroll = true;
            this.flpArrivalList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpArrivalList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpArrivalList.Location = new System.Drawing.Point(0, 63);
            this.flpArrivalList.Name = "flpArrivalList";
            this.flpArrivalList.Size = new System.Drawing.Size(287, 401);
            this.flpArrivalList.TabIndex = 1;
            // 
            // ucBusArrivalInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpArrivalList);
            this.Controls.Add(this.pnSearch);
            this.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.Name = "ucBusArrivalInfo";
            this.Size = new System.Drawing.Size(287, 464);
            this.pnSearch.ResumeLayout(false);
            this.pnSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tBox_keyword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpArrivalList;
    }
}
