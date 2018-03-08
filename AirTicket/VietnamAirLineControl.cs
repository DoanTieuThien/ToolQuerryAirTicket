using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AirTicket
{
    public class VietnamAirLineControl
    {
        public Dictionary<String,Object> loadDataOneWayFromVNA(VNARequestObject request)
        {
            Dictionary<String, Object> data = null;
            AirTicketControll airTicketController = new AirTicketControll();
            WebHeaderCollection webHeader = new WebHeaderCollection();

            webHeader.Add("origin", "https://fly.vietnamairlines.com");
            webHeader.Add("execution", "e1s1");
            webHeader.Add("jipcc", "VNDX");
            //webHeader.Add("Host", "dc.vietnamairlines.com");
            webHeader.Add("Conversation-ID", "cjegvbu1woxal54rqog2hqhoy");
            webHeader.Add("Authorization", "Bearer T1RLAQL+i67wtlvvFo0/ByAlqZL1qqzqRBAL4Va8oYIcEMyNBC0gMgT8AACwV+jrVIMLO5M9jzN1Cr9xpL57W8nLYjukieqUBSaO9ngQVv96BexfzeFCcgAp/yjqNlQLmA8jYe45ciqhBVZFixUgC+hz+uX/3MpfyMv5aZKZp05BIvLQ26+WYcS7Ppy9QwAXnBpDqJOV8Mi9TAk209VB3T9RBjKZEEzpJ/C0lDGW1qPhXvmLK60yvvognGC014R4r66hhMhgLx7JfrblGhZZGPGn7W9ETnhArRSMR44*");
            webHeader.Add("Cookie", "_ga=GA1.2.1335391186.1520414096; _gid=GA1.2.1167633169.1520414096; scs=%7B%22t%22%3A1%7D; SSWGID=cjegvbu1woxal54rqog2hqhoy; visid_incap_1362493=vWPnbVqdSBi0zWC51kMt98Stn1oAAAAAQUIPAAAAAAATLIsl73bETY+xuuc0WN/I; s_fid=14649B5CE160C35C-016C1F23DC4EE77D; ins-gaSSId=e0cc55e1-bdb4-6fde-e673-059bc2aa09d0_1520435405; nlbi_1362493=tbnGVNreiwXu4kqF6mvsgwAAAADS7Rtr67Dqz/9Iz9WVqatV; incap_ses_977_1362493=u7c9aU8g/W7j0I0YfwCPDRDzn1oAAAAAvJ1DaxWNVy/UhveBCTUbmg==; s_vnum=1617700549787%26vn%3D3; s_invisit=true; s_lv_s=Less%20than%201%20day; s_vnumpurchase=1617700549788%26vn%3D3; s_pers=true; WLPCOOKIE=sswhlp23636; JSESSIONID=306258EB284EEC3B048A0D693C04E83B; _ssw_ttcB=1520431893095; s_cc=true; incap_ses_443_1362493=ctoNfcNNGkG7kkD/CNslBhbzn1oAAAAAdUXDuJxsNOWYWIlmNEKxXw==; insdrSV=34; ldxev=15; gpv=AIR_SEARCH_PAGE; s_lv=1520432237616; s_sq=sabrg.prod.vn%3D%2526c.%2526a.%2526activitymap.%2526page%253DAIR_SEARCH_PAGE%2526link%253DT%2525C3%2525ACm%252520ki%2525E1%2525BA%2525BFm%2526region%253Dreact-tabs-1%2526pageIDType%253D1%2526.activitymap%2526.a%2526.c");
            String dataResponse = airTicketController.post("https://dc.vietnamairlines.com/v3.3/ssw/products/air/search?execution=e1s1&jipcc=VNDX", request, webHeader);
            data = JsonConvert.DeserializeObject<Dictionary<String, Object>>(dataResponse);
            return data;
        }
    }

    [Serializable]
    public class VNARequestObject 
    {
        public String cabinClass
        {
            get;
            set;
        }

        public List<String> promoCodes
        {
            get;
            set;
        }

        public VNAPassengersObject passengers
        {
            get;
            set;
        }

        public String searchType
        {
            get;
            set;
        }

        public List<VNAItineraryParts> itineraryParts
        {
            get;
            set;
        }
    }

    [Serializable]
    public class VNAItineraryParts
    {
        public VNAWhere from
        {
            get;
            set;
        }

        public VNAWhere to
        {
            get;
            set;
        }

        public VNADateInfo when
        {
            get;
            set;
        }
    }

    [Serializable]
    public class VNADateInfo
    {
        public String date
        {
            get;
            set;
        }
    }

    [Serializable]
    public class VNAWhere
    {
        public Boolean useNearbyLocations
        {
            get;
            set;
        }

        public String code
        {
            get;
            set;
        }
    }

    [Serializable]
    public class VNAPassengersObject
    {
        public String ADT
        {
            get;
            set;
        }

        public String CHD
        {
            get;
            set;
        }

        public String INF
        {
            get;
            set;
        }
    }
}
