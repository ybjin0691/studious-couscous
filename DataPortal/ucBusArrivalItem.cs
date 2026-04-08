using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClubB.DataPortal
{
    public partial class ucBusArrivalItem : UserControl
    {
        public ucBusArrivalItem(BusArrival busArrival)
        {
            InitializeComponent();

            lblRouteName.Text = busArrival.RouteName;
            lblRouteDestName.Text = busArrival.RouteDestName;
            lblCurStation1.Text = busArrival.StationNm1;
            lblCurStation2.Text = busArrival.StationNm2;
            string busInfo1, busInfo2;

            if(string.IsNullOrEmpty(busArrival.PredictTime1)&& string.IsNullOrEmpty(busArrival.PredictTime2))
            {
                lblInfo1.Text = "도착 정보 없음";
                lblCurStation1.Hide();
                lblInfo2.Hide();
                lblCurStation2.Hide();

                lblInfo1.TextAlign = ContentAlignment.MiddleLeft;
                tableLayoutPanel1.SetRowSpan(lblInfo1, 4);
                return;
            }
            busInfo1 = $"{busArrival.PredictTime1}분 후 도착 - {busArrival.LocationNo1} 번쨰 전";

            if (string.IsNullOrEmpty(busArrival.PredictTime2))
            {
                busInfo2 = "도착 정보 없음";
            }
            else
            {
                busInfo2 = $"{busArrival.PredictTime2}분 후 도착 - {busArrival.LocationNo2} 번쨰 전";
            }
            lblInfo1.Text = busInfo1;
            lblInfo2.Text = busInfo2;  
        }

        private void lblRouteName_Click(object sender, EventArgs e)
        {

        }
    }
}
