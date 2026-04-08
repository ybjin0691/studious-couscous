using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MyClubB.DataPortal
{
    public class StationIdApi
    {
        
    }

    public class StationIdResponse
    {
        [JsonProperty("response")]
        public MsgResponse Response { get; set; }
    }

    public class MsgResponse
    {
        [JsonProperty("msgHeader")]
        public StationMsgHeader MsgHeader { get; set; }
        [JsonProperty("msgBody")]
        public StationIdMsgBody MsgBody { get; set; }
    }

    public class StationMsgHeader
    {
        [JsonProperty("queryTime")]
        public string QueryTime {  get; set; }
        [JsonProperty("resultCode")]
        public string ResultCode {  get; set; }
        [JsonProperty("resultMessage")]
        public string ResultMessage { get; set; }
    }

    public class StationIdMsgBody
    {
        [JsonProperty("busStationList")]
        public List<BusStation> BusStationList { get; set; }
    }

    public class BusStation
    {
        [JsonProperty("centerYn")]
        public string CenterYn {  get; set; }
        [JsonProperty("mobileNo")]
        public string MobileNo {  get; set; }
        [JsonProperty("regionName")]
        public string RegionName {  get; set; }
        [JsonProperty("stationId")]
        public string StationId {  get; set; }
        [JsonProperty("stationName")]
        public string StationName { get; set;}
        [JsonProperty("x")]
        public string X { get; set; }
        [JsonProperty("y")]
        public string Y { get; set; }
    }

}
