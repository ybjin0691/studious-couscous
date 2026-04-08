using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Http;
using Newtonsoft.Json;


namespace MyClubB.DataPortal
{
    public partial class ucBusArrivalInfo : UserControl
    {
        private static readonly HttpClient client = new HttpClient();
        private string _serviceKey = "0tKhNngsGtEi3Bc26iLbgR6OZ9I812DgliOvIibqmILfTTRJ1DpW3wDNBa1q2YLD1HO4VPHHVQMzKjazeCHpZA%3D%3D";
        
        
        
        public ucBusArrivalInfo()
        {
            InitializeComponent();
           
        }
        


        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = tBox_keyword.Text.Trim();
            if(string.IsNullOrEmpty(keyword) )
            {
                MessageBox.Show("도착정보를 검색할 정류장 이름이 검색되지 않습니다.\r\n" +
                    "정류장 이름을 입력해주세요."
                    , "버스 도착정보 검색"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tBox_keyword.Focus();
                return;
            }

            await SearchStationId(keyword);
        }

        private async Task SearchStationId(string keyword)
        {
            string url = $"https://apis.data.go.kr/6410000/busstationservice/v2/getBusStationListv2?serviceKey={_serviceKey}&keyword={keyword}&format=json";
            

            try
            {
                var response = await client.GetStringAsync(url);
                Console.WriteLine(response);
                var data = JsonConvert.DeserializeObject<StationIdResponse>(response);
                
                try
                {
                    string resultCode = data.Response.MsgHeader.ResultCode.Trim();
                    if (resultCode.Equals("1") || (resultCode.Equals("2")) || (resultCode.Equals("4")))
                    {
                        MessageBox.Show(data.Response.MsgHeader.ResultMessage
                            , "버스 도착정보 검색"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch(Exception fail)
                {
                    Console.WriteLine( fail.Message );
                    return;
                }

                flpArrivalList.Controls.Clear();

                    foreach (var stationId in data.Response.MsgBody.BusStationList)
                {
                    string stationIdInfo = $"Id : {stationId.StationId}, Name : {stationId.StationName}, X : {stationId.X}, Y : {stationId.Y}";
                    Console.WriteLine(stationIdInfo);

                    ucStationIdItem ucStationIdItem = new ucStationIdItem(stationId.StationName, stationId.StationId.ToString());
                    
                    ucStationIdItem.StationIdChanged += StationIdItem_Receive;
                    ucStationIdItem.Width = flpArrivalList.ClientSize.Width - 8;
                    flpArrivalList.Controls.Add(ucStationIdItem);

                    Console.WriteLine(ucStationIdItem.Width);
                    Console.WriteLine(flpArrivalList.ClientSize.Width);
                }
            }
            catch(Exception fail)
            {
                Console.WriteLine(fail.Message);
                MessageBox.Show("Station Id를 받아오는 중 오류 발생"
                    , "공공데이터 오류"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //{"response":{"comMsgHeader":"","msgHeader":{"queryTime":"2025-05-07 09:56:39.343","resultCode":0,"resultMessage":"정상적으로 처리되었습니다."},"msgBody":{"busStationList":[{"centerYn":"N","mobileNo":" 15271","regionName":"평택","stationId":214001742,"stationName":"국제대학","x":127.0802333,"y":37.0656667},{"centerYn":"N","mobileNo":" 48584","regionName":"평택","stationId":214002003,"stationName":"은혜중고.국제대학","x":127.0786833,"y":37.0667833}]}}}
        }

        private void tBox_keyword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch_Click(sender, e);
            }
        }

        private async void StationIdItem_Receive(object sender, string stationId)
        {
            Console.WriteLine($"BusArrivalInfo : {stationId}");
            await BusArrivalList(stationId);
        }
        private async Task BusArrivalList(string stationId)
        {
            string url = $"https://apis.data.go.kr/6410000/busarrivalservice/v2/getBusArrivalListv2?serviceKey={_serviceKey}&stationId={stationId}&format=json";
            try
            {
                var response = await client.GetStringAsync(url);
                Console.WriteLine (response);

                var data = JsonConvert.DeserializeObject<BusArrivalApi>(response);

                string resultCode = data.Response.MsgHeader.ResultCode;
                string resultMsg = data.Response.MsgHeader.ResultMessage;

                if(resultCode == "1" || resultCode == "2" || resultCode == "4")
                {
                    string resultMessage = data.Response.MsgHeader.ResultMessage;
                    MessageBox.Show(resultMessage, "버스도착 정보 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                flpArrivalList.Controls.Clear();

                List<BusArrival> busArrivals = new List<BusArrival>();

                foreach(var bus in data.Response.MsgBody.BusArrivalList)
                {
                    if(bus.Flag.Equals("RUN") || bus.Flag.Equals("PASS"))
                    {
                        busArrivals.Add(bus);
                    }
                }
                busArrivals = busArrivals.OrderBy(bus => string.IsNullOrEmpty(bus.PredictTime1) ? 1 : 0).ToList();
                foreach(var bus in busArrivals)
                {
                    ucBusArrivalItem ucBusArrivalItem = new ucBusArrivalItem(bus);
                    ucBusArrivalItem.Width = flpArrivalList.ClientSize.Width - 50;
                    flpArrivalList.Controls.Add(ucBusArrivalItem);
                }
            }
            catch (Exception fail)
            {
                Console.WriteLine($"Error: {fail.Message}") ;
            }
        }
    }
}
