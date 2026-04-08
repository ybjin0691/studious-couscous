namespace MyClubB.DataPortal
{
    partial class ucStationIdItem
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
            this.pnList = new System.Windows.Forms.Panel();
            this.lblStationId = new System.Windows.Forms.Label();
            this.lblStationName = new System.Windows.Forms.Label();
            this.pnList.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnList
            // 
            this.pnList.BackColor = System.Drawing.Color.White;
            this.pnList.Controls.Add(this.lblStationId);
            this.pnList.Controls.Add(this.lblStationName);
            this.pnList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnList.Location = new System.Drawing.Point(0, 2);
            this.pnList.Name = "pnList";
            this.pnList.Padding = new System.Windows.Forms.Padding(5);
            this.pnList.Size = new System.Drawing.Size(397, 47);
            this.pnList.TabIndex = 0;
            // 
            // lblStationId
            // 
            this.lblStationId.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblStationId.Location = new System.Drawing.Point(200, 5);
            this.lblStationId.Name = "lblStationId";
            this.lblStationId.Size = new System.Drawing.Size(192, 37);
            this.lblStationId.TabIndex = 1;
            this.lblStationId.Text = "lblStationId";
            this.lblStationId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStationId.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblStationId_MouseClick);
            this.lblStationId.MouseLeave += new System.EventHandler(this.lblStationId_MouseLeave);
            this.lblStationId.MouseHover += new System.EventHandler(this.lblStationId_MouseHover);
            // 
            // lblStationName
            // 
            this.lblStationName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStationName.Location = new System.Drawing.Point(5, 5);
            this.lblStationName.Name = "lblStationName";
            this.lblStationName.Size = new System.Drawing.Size(206, 37);
            this.lblStationName.TabIndex = 0;
            this.lblStationName.Text = "lblStationName";
            this.lblStationName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStationName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblStationName_MouseClick);
            this.lblStationName.MouseLeave += new System.EventHandler(this.lblStationName_MouseLeave);
            this.lblStationName.MouseHover += new System.EventHandler(this.lblStationName_MouseHover);
            // 
            // ucStationIdItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.pnList);
            this.Name = "ucStationIdItem";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Size = new System.Drawing.Size(397, 49);
            this.pnList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnList;
        private System.Windows.Forms.Label lblStationId;
        private System.Windows.Forms.Label lblStationName;
    }
}
