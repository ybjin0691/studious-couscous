using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MyClubB.DataPortal
{
    internal class BusArrivalApi
    {
        [JsonProperty("response")] 
        public BusResponse Response {  get; set; }
    }

    public class BusResponse
    {
        [JsonProperty("msgHeader")]
        public BusArrIdMsgHeader MsgHeader {  get; set; }
        [JsonProperty("msgBody")]
        public BusArrMsgBody MsgBody { get; set; }
    }
    public class BusArrIdMsgHeader
    {
        [JsonProperty("queryTime")]
        public string QueryTime {  get; set; }
        [JsonProperty("resultCode")]
        public string ResultCode { get; set; }
        [JsonProperty("resultMessage")]
        public string ResultMessage {  get; set; }
    } 

    public class BusArrMsgBody
    {
        [JsonProperty("busArrivalList")]
        public List<BusArrival> BusArrivalList { get; set; }
    }

    public class BusArrival
    {
        [JsonProperty("crowded1")]
        public string Crowded1 { get; set; }
        [JsonProperty("crowded2")]
        public string Crowded2 { get; set; }
        [JsonProperty("flag")]
        public string Flag { get; set; }
        [JsonProperty("locationNo1")]
        public string LocationNo1 { get; set; }
        [JsonProperty("locationNo2")]
        public string LocationNo2 { get; set; }
        [JsonProperty("lowPlate1")]
        public string LowPlate1 { get; set; }
        [JsonProperty("lowPlate2")]
        public string LowPlate2 { get; set; }
        [JsonProperty("plateNo1")]
        public string PlateNo1 { get; set; }
        [JsonProperty("plateNo2")]
        public string PlateNo2 { get; set; }
        [JsonProperty("predictTime1")]
        public string PredictTime1 { get; set; }
        [JsonProperty("predictTime2")]
        public string PredictTime2 { get; set; }
        [JsonProperty("remainSeatCnt1")]
        public string RemainSeatCnt1 { get; set; }
        [JsonProperty("remainSeatCnt2")]
        public string RemainSeatCnt2 { get; set; }
        [JsonProperty("routeDestId")]
        public string RouteDestId { get; set; }
        [JsonProperty("routeDestName")]
        public string RouteDestName { get; set; }
        [JsonProperty("routeId")]
        public string RouteId { get; set; }
        [JsonProperty("routeName")]
        public string RouteName{ get; set; }
        [JsonProperty("routeTypeCd")]
        public string RouteTypeCd { get; set; }
        [JsonProperty("staOrder")]
        public string StaOrder { get; set; }
        [JsonProperty("stationId")]
        public string StationId { get; set; }
        [JsonProperty("stationNm1")]
        public string StationNm1 { get; set; }
        [JsonProperty("stationNm2")]
        public string StationNm2 { get; set; }
        [JsonProperty("taglessCd1")]
        public string TaglessCd1 { get; set; }
        [JsonProperty("taglessCd2")]
        public string TaglessCd2 { get; set; }
        [JsonProperty("turnSeq")]
        public string TurnSeq { get; set; }
        [JsonProperty("vehId1")]
        public string VehId1 { get; set; }
        [JsonProperty("vehId2")]
        public string VehId2 { get; set; }
        [JsonProperty("predictTimeSec1")]
        public string PredictTimeSec1 { get; set; }
        [JsonProperty("predictTimeSec2")]
        public string PredictTimeSec2 { get; set; }
        [JsonProperty("stateCd1")]
        public string StateCd1 { get; set; }
        [JsonProperty("stateCd2")]
        public string StateCd2 { get; set; }
    }
}
