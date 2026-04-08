namespace MyClubB.DataPortal
{
    partial class ucBusArrivalItem
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.lblRouteDestName = new System.Windows.Forms.Label();
            this.lblRouteName = new System.Windows.Forms.Label();
            this.lblCurStation1 = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.lblCurStation2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.58333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.41667F));
            this.tableLayoutPanel1.Controls.Add(this.lblInfo1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblRouteDestName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblRouteName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCurStation1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblInfo2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCurStation2, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.73529F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.26471F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(455, 134);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblInfo1
            // 
            this.lblInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo1.Location = new System.Drawing.Point(239, 9);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(219, 18);
            this.lblInfo1.TabIndex = 2;
            this.lblInfo1.Text = "lblInfo1";
            // 
            // lblRouteDestName
            // 
            this.lblRouteDestName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRouteDestName.Font = new System.Drawing.Font("굴림체", 12F);
            this.lblRouteDestName.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblRouteDestName.Location = new System.Drawing.Point(3, 68);
            this.lblRouteDestName.Name = "lblRouteDestName";
            this.lblRouteDestName.Size = new System.Drawing.Size(214, 34);
            this.lblRouteDestName.TabIndex = 1;
            this.lblRouteDestName.Text = "lblRouteDestName";
            // 
            // lblRouteName
            // 
            this.lblRouteName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRouteName.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRouteName.ForeColor = System.Drawing.Color.Cyan;
            this.lblRouteName.Location = new System.Drawing.Point(3, 35);
            this.lblRouteName.Name = "lblRouteName";
            this.lblRouteName.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblRouteName.Size = new System.Drawing.Size(214, 33);
            this.lblRouteName.TabIndex = 0;
            this.lblRouteName.Text = "lblRouteName";
            // 
            // lblCurStation1
            // 
            this.lblCurStation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurStation1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurStation1.Location = new System.Drawing.Point(245, 41);
            this.lblCurStation1.Name = "lblCurStation1";
            this.lblCurStation1.Size = new System.Drawing.Size(247, 18);
            this.lblCurStation1.TabIndex = 3;
            this.lblCurStation1.Text = "lblCurStation1";
            // 
            // lblInfo2
            // 
            this.lblInfo2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo2.Location = new System.Drawing.Point(243, 78);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(249, 11);
            this.lblInfo2.TabIndex = 4;
            this.lblInfo2.Text = "lblInfo2";
            // 
            // lblCurStation2
            // 
            this.lblCurStation2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurStation2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurStation2.Location = new System.Drawing.Point(247, 113);
            this.lblCurStation2.Name = "lblCurStation2";
            this.lblCurStation2.Size = new System.Drawing.Size(211, 21);
            this.lblCurStation2.TabIndex = 5;
            this.lblCurStation2.Text = "lblCurStation2";
            // 
            // ucBusArrivalItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucBusArrivalItem";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(459, 138);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.Label lblRouteDestName;
        private System.Windows.Forms.Label lblRouteName;
        private System.Windows.Forms.Label lblCurStation1;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.Label lblCurStation2;
    }
}
