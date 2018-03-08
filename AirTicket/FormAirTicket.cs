using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Newtonsoft.Json;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Globalization;

namespace AirTicket
{
    public partial class FormAirTicket : Form
    {
        private int miThreadState = 1;
        private Queue mqResponseQueue = new Queue();
        private Queue mqTripRequestQueue = new Queue();
        private Queue mqResponseMinTicketQueue = new Queue();
        private EmailObject emailObject = null;
        private Boolean mblIsSchedulerRunning = false;
        private String jsonPostData = "";

        public FormAirTicket()
        {
            InitializeComponent();
            initForm();
        }

        private void initForm()
        {
            ThreadStart threadStart = new ThreadStart(threadAnylizeData);
            Thread thread = new Thread(threadStart);

            this.miThreadState = 1;
            thread.IsBackground = true;
            thread.Start();

            loadDateTime();
            initDataPlace();

            ToolTip t = new ToolTip();

            t.SetToolTip(this.btnSetting, "Cài đặt tham số nhận biết vé rẻ");
            initFileConfig();

            //threadStart = new ThreadStart(threadScheduler);
            //thread = new Thread(threadStart);

            //thread.IsBackground = true;
            //thread.Start();

            threadStart = new ThreadStart(threadPutTicketInfo);
            thread = new Thread(threadStart);

            thread.IsBackground = true;
            thread.Start();

            threadStart = new ThreadStart(threadTripTicket);
            thread = new Thread(threadStart);

            thread.IsBackground = true;
            thread.Start();
        }

        private void loadDateTime()
        {
            this.dtStartDate.Value = DateTime.Today;
            this.dtEndDate.Value = DateTime.Today;
        }

        private void initDataPlace()
        {
            AirTicketControll ticketControl = new AirTicketControll();
            WebHeaderCollection webHeader = new WebHeaderCollection();

            try
            {
                webHeader.Add("origin", "https://www.traveloka.com");
                webHeader.Add("x-domain", "flight");
                webHeader.Add("x-route-prefix", "vi-vn");
                webHeader.Add("Cookie", "__flash={}; _ga=GA1.2.932927324.1520040064; _gid=GA1.2.1732572559.1520040064; tv-repeat-visit=true; G_ENABLED_IDPS=google; smartlock-login=1; ajs_user_id=null; ajs_group_id=null; ajs_anonymous_id=%22d486c849-3bdd-47ac-ac45-08f498e8d791%22; cto_lwid=089dc1ee-2bc0-462a-926a-c7b268f0568b; __zlcmid=lFhA7B3G6c3dki; __ssid=6feafe47-4261-4b22-b7ee-64a51e03cb04; bannerMessage=null; ab-testingGroup.testingWebTreatmentA=testingWebControlA; ab-testingGroup.testingWebTreatmentB=testingWebControlB; ab-testingGroup.testingMWebTreatmentA=testingMWebDefaultA; ab-testingGroup.testingMWebTreatmentB=testingMWebDefaultB; ab-flight.international-roundtrip=existing; ab-payment.paymentflow=existing; ab-promoBanner.promoNewExperience=promoNewExperience1; isPriceFinderActive=null; dateIndicator=null; displayPrice=null; tvs=3XL5Gyq/zs8YRbSAew0nhzRK2evJ+5aGgvgVLKkXZuMDuqK2m0b3376NU86IvO931JJnWF3Y9oETnFuSeHhawRws3r5fKxPj62n1bJ+Nck309g3Rkogk+dtxsoMRpFHbkVkEJbYuNFbd9Ckp9iEBGg==; _gac_UA-29776811-1=1.1520044257.Cj0KCQiAieTUBRCaARIsAHeLDCTbTioXLme4pJtN5V1rps7dbgecIbLcMKlWacGBZ7fCmJRDLi_TAtsaAk_yEALw_wcB; usePromoFinder=null; flightSourceAirport=HAN; flightDestinationAirport=DAD; flightFlightType=ONE_WAY; flightNumOfAdults=2; flightNumChildren=0; flightNumInfants=1; flightSeatClassType=ECONOMY; useDateFlow=true; flightDepartureDate=05-03-2018; lux_uid=152005001724069055; _uetsid=_uetab59fdfb; _gat_UA-29776811-1=1; _ceg.s=p4zymd; _ceg.u=p4zymd; tvl=f3wCB3cKgUze5BpspQzAL+mnbaBIfEBR1bZE25xsOsUHUhJKz+1BoXpjQ8ko3dXyMPnI/qv+kTSWIGTa6QZ6ieGmx/pO9MJ6JYp16Im3tLPG73yaxePN4oY9LstiXVmH556o/4HaBfKKupVITYOshQCMk6oOaLdxHOMRqTQva54Q9vR7PG0TFlUgabNp7yEsyjDKZfnBFQySog//2+De71Rdyq6rhcCSa1qy2WTRug0StB0tiQB5rYa76tq+9shbRlv3hvKL2CDJjjw/ZIlNpQ==");

                String dataResponse = ticketControl.get("https://www.traveloka.com/vi-vn/flight/staticdata", webHeader);
                Dictionary<String, JObject>  dataDicResponse = JsonConvert.DeserializeObject<Dictionary<String, JObject>>(dataResponse);
                JObject jsonData =  dataDicResponse["data"];
                JToken jsonAirLines = jsonData["airlines"];
                JToken jsonairports = jsonData["airports"];
                JToken jsonairportAreas = jsonData["airportAreas"];
                JToken jsonairportGroup = jsonData["airportGroups"];
                JToken jsonairlineAddOnTypes = jsonData["airlineAddOnTypes"];
                JToken jsonairportServiceTypes = jsonData["airportServiceTypes"];
                JToken jsonpopularDestination = jsonData["popularDestination"];
                JToken jsoncountryGroups = jsonData["countryGroups"];
                JToken jsonairportsClassifiedByCountry = jsonData["airportsClassifiedByCountry"];
                JToken jsoncountriesDictionary = jsonData["countriesDictionary"];

                foreach(JProperty jsonProperties in jsonairports)
                {
                    String place = jsonProperties.Name + "-" + jsonProperties.Value["location"];

                    comboSourcePlace.Items.Add(place);
                    comboDesPlace.Items.Add(place);
                }
            }catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.btnSearch.Enabled = false;
            this.lbLoadingStatus.Text = "Trạng thái: Đang tải dữ liệu";
            this.dataTicket.Rows.Clear();

            if (comboWebsiteSearch.SelectedIndex == 0)
            {
                callTraveloka();
            }else if (comboWebsiteSearch.SelectedIndex == 1)
            {
                callVNA();
            }
            this.btnSearch.Enabled = true;
        }

        private void callVNA()
        {
            VietnamAirLineControl vnaControll = new VietnamAirLineControl();
            VNARequestObject request = new VNARequestObject();
            Dictionary<String, Object> data = null;

            try
            {
                request.cabinClass = comboSeat.Text;
                request.promoCodes = new List<string>() { ""};

                VNAPassengersObject passengers = new VNAPassengersObject();

                passengers.ADT = udPeopleNumber.Value.ToString();
                passengers.CHD = udChildren.Value.ToString();
                passengers.INF = udBabyNumber.Value.ToString();

                request.passengers = passengers;
                request.searchType = "BRANDED";

                List<VNAItineraryParts> itineraryParts = new List<VNAItineraryParts>();
                VNAItineraryParts itineraryPartItem = new VNAItineraryParts();
                VNAWhere from = new VNAWhere();
                VNAWhere to = new VNAWhere();

                from.useNearbyLocations = false;
                from.code = comboSourcePlace.Text.Split('-')[0];

                to.useNearbyLocations = false;
                to.code = comboDesPlace.Text.Split('-')[0];

                itineraryPartItem.from = from;
                itineraryPartItem.to = to;

                VNADateInfo when = new VNADateInfo();

                when.date = dtStartDate.Value.ToString("yyyy-MM-dd");
                itineraryPartItem.when = when;
                itineraryParts.Add(itineraryPartItem);
                request.itineraryParts = itineraryParts;
                data = vnaControll.loadDataOneWayFromVNA(request);

                List<JToken> jsonSearchResult = ((JArray)data["unbundledOffers"])[0].ToList<JToken>();

                Console.Write(jsonSearchResult.ToString());
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void callTraveloka()
        {
            try
            {
                if(udPeopleNumber.Value + udChildren.Value == 0)
                {
                    MessageBox.Show("Xin hãy chọn số người để mua vé.", "Thông báo");
                    return;
                }

                if(comboTicket.SelectedIndex == -1)
                {
                    MessageBox.Show("Xin hãy chọn số loại vé di chuyển (Một chiều/Hai chiều).","Thông báo");
                    return;
                }

                if (comboSourcePlace.SelectedIndex == -1)
                {
                    MessageBox.Show("Xin hãy chọn xuất phát.", "Thông báo");
                    return;
                }

                if (comboDesPlace.SelectedIndex == -1)
                {
                    MessageBox.Show("Xin hãy chọn điểm đến.", "Thông báo");
                    return;
                }

                ATKRequestObject request = new ATKRequestObject();

                request.clientInterface = "desktop";
                request.fields = new List<string>();
                
                ATKDataObject data = new ATKDataObject();

                data.currency = "VND";
                data.destinationAirportOrArea = comboDesPlace.Text.Split('-')[0];

                ATKFlightDate flightDate = new ATKFlightDate();

                flightDate.day = dtStartDate.Value.Day.ToString();
                flightDate.month = dtStartDate.Value.Month.ToString();
                flightDate.year = dtStartDate.Value.Year.ToString();

                data.flightDate = flightDate;
                data.isReschedule = false;
                data.locale = "vi_VN";
                data.newResult = true;

                NumSeats numSeats = new NumSeats();

                numSeats.numAdults = udPeopleNumber.Text;
                numSeats.numChildren = udChildren.Text;
                numSeats.numInfants = udBabyNumber.Text;

                data.numSeats = numSeats;
                data.seatPublishedClass = comboSeat.Text.ToUpper();

                SortFilter sortFilter = new SortFilter();

                sortFilter.filterAirlines = new List<string>();
                sortFilter.filterArrive = new List<string>();
                sortFilter.filterDepart = new List<string>();
                sortFilter.filterTransit = new List<string>();
                sortFilter.selectedDeparture = "";

                data.sortFilter = sortFilter;
                data.sourceAirportOrArea = comboSourcePlace.Text.Split('-')[0];
                data.usePromoFinder = false;

                AirTicketControll ticketControl = new AirTicketControll();
                WebHeaderCollection webHeader = new WebHeaderCollection();

                webHeader.Add("origin", "https://www.traveloka.com");
                webHeader.Add("x-domain", "flight");
                webHeader.Add("x-route-prefix", "vi-vn");
                

                String url = "";

                if (comboTicket.SelectedIndex == 0)
                {
                    webHeader.Add("Cookie", "__flash={}; _ga=GA1.2.932927324.1520040064; _gid=GA1.2.1732572559.1520040064; tv-repeat-visit=true; G_ENABLED_IDPS=google; smartlock-login=1; ajs_user_id=null; ajs_group_id=null; ajs_anonymous_id=%22d486c849-3bdd-47ac-ac45-08f498e8d791%22; cto_lwid=089dc1ee-2bc0-462a-926a-c7b268f0568b; __zlcmid=lFhA7B3G6c3dki; __ssid=6feafe47-4261-4b22-b7ee-64a51e03cb04; bannerMessage=null; ab-testingGroup.testingWebTreatmentA=testingWebControlA; ab-testingGroup.testingWebTreatmentB=testingWebControlB; ab-testingGroup.testingMWebTreatmentA=testingMWebDefaultA; ab-testingGroup.testingMWebTreatmentB=testingMWebDefaultB; ab-flight.international-roundtrip=existing; ab-payment.paymentflow=existing; ab-promoBanner.promoNewExperience=promoNewExperience1; isPriceFinderActive=null; dateIndicator=null; displayPrice=null; tvs=3XL5Gyq/zs8YRbSAew0nhzRK2evJ+5aGgvgVLKkXZuMDuqK2m0b3376NU86IvO931JJnWF3Y9oETnFuSeHhawRws3r5fKxPj62n1bJ+Nck309g3Rkogk+dtxsoMRpFHbkVkEJbYuNFbd9Ckp9iEBGg==; _gac_UA-29776811-1=1.1520044257.Cj0KCQiAieTUBRCaARIsAHeLDCTbTioXLme4pJtN5V1rps7dbgecIbLcMKlWacGBZ7fCmJRDLi_TAtsaAk_yEALw_wcB; usePromoFinder=null; flightSourceAirport=HAN; flightDestinationAirport=DAD; flightFlightType=ONE_WAY; flightNumOfAdults=2; flightNumChildren=0; flightNumInfants=1; flightSeatClassType=ECONOMY; useDateFlow=true; flightDepartureDate=05-03-2018; lux_uid=152005001724069055; _uetsid=_uetab59fdfb; _gat_UA-29776811-1=1; _ceg.s=p4zymd; _ceg.u=p4zymd; tvl=f3wCB3cKgUze5BpspQzAL+mnbaBIfEBR1bZE25xsOsUHUhJKz+1BoXpjQ8ko3dXyMPnI/qv+kTSWIGTa6QZ6ieGmx/pO9MJ6JYp16Im3tLPG73yaxePN4oY9LstiXVmH556o/4HaBfKKupVITYOshQCMk6oOaLdxHOMRqTQva54Q9vR7PG0TFlUgabNp7yEsyjDKZfnBFQySog//2+De71Rdyq6rhcCSa1qy2WTRug0StB0tiQB5rYa76tq+9shbRlv3hvKL2CDJjjw/ZIlNpQ==");
                    url = "https://www.traveloka.com/api/v2/flight/search/oneway";
                }else if (comboTicket.SelectedIndex == 1)
                {
                    List<ATKFlightDate> lsDates = new List<ATKFlightDate>();
                    ATKFlightDate fromDate = new ATKFlightDate();
                    ATKFlightDate endDate = new ATKFlightDate();
                    List<String> airportOrAreaCodes = new List<string>();

                    airportOrAreaCodes.Add(data.sourceAirportOrArea);
                    airportOrAreaCodes.Add(data.destinationAirportOrArea);
                    data.airportOrAreaCodes = airportOrAreaCodes;

                    webHeader.Add("Cookie", "__flash={}; _ga=GA1.2.932927324.1520040064; G_ENABLED_IDPS=google; ajs_user_id=null; ajs_group_id=null; ajs_anonymous_id=%22d486c849-3bdd-47ac-ac45-08f498e8d791%22; cto_lwid=089dc1ee-2bc0-462a-926a-c7b268f0568b; __zlcmid=lFhA7B3G6c3dki; __ssid=6feafe47-4261-4b22-b7ee-64a51e03cb04; ab-testingGroup.testingWebTreatmentA=testingWebControlA; ab-testingGroup.testingWebTreatmentB=testingWebControlB; ab-testingGroup.testingMWebTreatmentA=testingMWebDefaultA; ab-testingGroup.testingMWebTreatmentB=testingMWebDefaultB; ab-flight.international-roundtrip=existing; ab-payment.paymentflow=existing; ab-promoBanner.promoNewExperience=promoNewExperience1; _gid=GA1.2.1426010023.1520259895; smartlock-login=1; tv-repeat-visit=true; _gac_UA-29776811-1=1.1520303919.CjwKCAiA8vPUBRAyEiwA8F1oDFAr0r7iAOPOJhvEjuVJeGW3AEN6dV6Zk-MGrXLFNv2E21CWUZ8LHxoCLD4QAvD_BwE; useDateFlow=false; usePromoFinder=null; lux_uid=152031671397333316; flightSourceAirport=HAN; flightDestinationAirport=SGN; flightFlightType=ROUNDTRIP; flightSeatClassType=ECONOMY; tripDurationPromoFinder=26; flightDepartureDate=10-04-2018; flightReturnDate=06-05-2018; _uetsid=_uetc43c9264; tvs=3XL5Gyq/zs8YRbSAew0nhzRK2evJ+5aGgvgVLKkXZuMDuqK2m0b3376NU86IvO931JJnWF3Y9oETnFuSeHhawRws3r5fKxPj62n1bJ+Nck309g3Rkogk+dtxsoMRpFHbkVkEJbYuNFbd9Ckp9iEBGg==; _gat_UA-29776811-1=1; flightNumOfAdults=2; flightNumChildren=0; flightNumInfants=0; _ceg.s=p55osx; _ceg.u=p55osx; tvl=f3wCB3cKgUze5BpspQzAL+mnbaBIfEBR1bZE25xsOsUHUhJKz+1BoXpjQ8ko3dXyx1H9zS2r3tClyNNaIAJvASYxrk4+3Fd1EeiF4nr50wwggIZXOzld30I2eDCTL0ejx7TZdMVrY3JC+jnOu/g8JmuJlTPIoD9abqH+9elXCiTYfe8wVkLTO+2MDDqUgSZcx7ED+JRciHNY/tnGBlozjkqkZXAVkE8MdQdphl5JgTtlvpEAEL7Pma3QLlxG+dGGRlv3hvKL2CDJjjw/ZIlNpQ==");
                    fromDate.day = dtStartDate.Value.Day.ToString();
                    fromDate.month = dtStartDate.Value.Month.ToString();
                    fromDate.year = dtStartDate.Value.Year.ToString();

                    endDate.day = dtEndDate.Value.Day.ToString();
                    endDate.month = dtEndDate.Value.Month.ToString();
                    endDate.year = dtEndDate.Value.Year.ToString();

                    lsDates.Add(fromDate);
                    lsDates.Add(endDate);
                    data.dates = lsDates;
                    url = "https://www.traveloka.com/api/v2/flight/search/depart2w";
                }
                request.data = data;
                String dataResponse = ticketControl.post(url, request, webHeader);

                this.mqResponseQueue.Enqueue(JsonConvert.DeserializeObject<Dictionary<String, Object>>(dataResponse));
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message,"Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private String getTicketTraveloka(EmailObject emailObject)
        {
            try
            {
                ATKRequestObject request = new ATKRequestObject();

                request.clientInterface = "desktop";
                request.fields = new List<string>();

                ATKDataObject data = new ATKDataObject();

                data.currency = "VND";
                data.destinationAirportOrArea = emailObject.ticketDestination;

                ATKFlightDate flightDate = emailObject.scanFromDate;

                data.flightDate = flightDate;
                data.isReschedule = false;
                data.locale = "vi_VN";
                data.newResult = true;

                NumSeats numSeats = new NumSeats();

                numSeats.numAdults = emailObject.numAdult;
                numSeats.numChildren = emailObject.numChild;
                numSeats.numInfants = emailObject.numInfant;

                data.numSeats = numSeats;
                data.seatPublishedClass = emailObject.seatPublishedClass;

                SortFilter sortFilter = new SortFilter();

                sortFilter.filterAirlines = new List<string>();
                sortFilter.filterArrive = new List<string>();
                sortFilter.filterDepart = new List<string>();
                sortFilter.filterTransit = new List<string>();
                sortFilter.selectedDeparture = "";

                data.sortFilter = sortFilter;
                data.sourceAirportOrArea = emailObject.ticketSource;
                data.usePromoFinder = false;

                AirTicketControll ticketControl = new AirTicketControll();
                WebHeaderCollection webHeader = new WebHeaderCollection();

                webHeader.Add("origin", "https://www.traveloka.com");
                webHeader.Add("x-domain", "flight");
                webHeader.Add("x-route-prefix", "vi-vn");


                String url = "";

                //if (comboTicket.SelectedIndex == 0)
                //{
                    webHeader.Add("Cookie", "__flash={}; _ga=GA1.2.932927324.1520040064; _gid=GA1.2.1732572559.1520040064; tv-repeat-visit=true; G_ENABLED_IDPS=google; smartlock-login=1; ajs_user_id=null; ajs_group_id=null; ajs_anonymous_id=%22d486c849-3bdd-47ac-ac45-08f498e8d791%22; cto_lwid=089dc1ee-2bc0-462a-926a-c7b268f0568b; __zlcmid=lFhA7B3G6c3dki; __ssid=6feafe47-4261-4b22-b7ee-64a51e03cb04; bannerMessage=null; ab-testingGroup.testingWebTreatmentA=testingWebControlA; ab-testingGroup.testingWebTreatmentB=testingWebControlB; ab-testingGroup.testingMWebTreatmentA=testingMWebDefaultA; ab-testingGroup.testingMWebTreatmentB=testingMWebDefaultB; ab-flight.international-roundtrip=existing; ab-payment.paymentflow=existing; ab-promoBanner.promoNewExperience=promoNewExperience1; isPriceFinderActive=null; dateIndicator=null; displayPrice=null; tvs=3XL5Gyq/zs8YRbSAew0nhzRK2evJ+5aGgvgVLKkXZuMDuqK2m0b3376NU86IvO931JJnWF3Y9oETnFuSeHhawRws3r5fKxPj62n1bJ+Nck309g3Rkogk+dtxsoMRpFHbkVkEJbYuNFbd9Ckp9iEBGg==; _gac_UA-29776811-1=1.1520044257.Cj0KCQiAieTUBRCaARIsAHeLDCTbTioXLme4pJtN5V1rps7dbgecIbLcMKlWacGBZ7fCmJRDLi_TAtsaAk_yEALw_wcB; usePromoFinder=null; flightSourceAirport=HAN; flightDestinationAirport=DAD; flightFlightType=ONE_WAY; flightNumOfAdults=2; flightNumChildren=0; flightNumInfants=1; flightSeatClassType=ECONOMY; useDateFlow=true; flightDepartureDate=05-03-2018; lux_uid=152005001724069055; _uetsid=_uetab59fdfb; _gat_UA-29776811-1=1; _ceg.s=p4zymd; _ceg.u=p4zymd; tvl=f3wCB3cKgUze5BpspQzAL+mnbaBIfEBR1bZE25xsOsUHUhJKz+1BoXpjQ8ko3dXyMPnI/qv+kTSWIGTa6QZ6ieGmx/pO9MJ6JYp16Im3tLPG73yaxePN4oY9LstiXVmH556o/4HaBfKKupVITYOshQCMk6oOaLdxHOMRqTQva54Q9vR7PG0TFlUgabNp7yEsyjDKZfnBFQySog//2+De71Rdyq6rhcCSa1qy2WTRug0StB0tiQB5rYa76tq+9shbRlv3hvKL2CDJjjw/ZIlNpQ==");
                    url = "https://www.traveloka.com/api/v2/flight/search/oneway";
                //}
                //else if (comboTicket.SelectedIndex == 1)
                //{
                //    List<ATKFlightDate> lsDates = new List<ATKFlightDate>();
                //    ATKFlightDate fromDate = new ATKFlightDate();
                //    ATKFlightDate endDate = new ATKFlightDate();
                //    List<String> airportOrAreaCodes = new List<string>();

                //    airportOrAreaCodes.Add(data.sourceAirportOrArea);
                //    airportOrAreaCodes.Add(data.destinationAirportOrArea);
                //    data.airportOrAreaCodes = airportOrAreaCodes;

                //    webHeader.Add("Cookie", "__flash={}; _ga=GA1.2.932927324.1520040064; G_ENABLED_IDPS=google; ajs_user_id=null; ajs_group_id=null; ajs_anonymous_id=%22d486c849-3bdd-47ac-ac45-08f498e8d791%22; cto_lwid=089dc1ee-2bc0-462a-926a-c7b268f0568b; __zlcmid=lFhA7B3G6c3dki; __ssid=6feafe47-4261-4b22-b7ee-64a51e03cb04; ab-testingGroup.testingWebTreatmentA=testingWebControlA; ab-testingGroup.testingWebTreatmentB=testingWebControlB; ab-testingGroup.testingMWebTreatmentA=testingMWebDefaultA; ab-testingGroup.testingMWebTreatmentB=testingMWebDefaultB; ab-flight.international-roundtrip=existing; ab-payment.paymentflow=existing; ab-promoBanner.promoNewExperience=promoNewExperience1; _gid=GA1.2.1426010023.1520259895; smartlock-login=1; tv-repeat-visit=true; _gac_UA-29776811-1=1.1520303919.CjwKCAiA8vPUBRAyEiwA8F1oDFAr0r7iAOPOJhvEjuVJeGW3AEN6dV6Zk-MGrXLFNv2E21CWUZ8LHxoCLD4QAvD_BwE; useDateFlow=false; usePromoFinder=null; lux_uid=152031671397333316; flightSourceAirport=HAN; flightDestinationAirport=SGN; flightFlightType=ROUNDTRIP; flightSeatClassType=ECONOMY; tripDurationPromoFinder=26; flightDepartureDate=10-04-2018; flightReturnDate=06-05-2018; _uetsid=_uetc43c9264; tvs=3XL5Gyq/zs8YRbSAew0nhzRK2evJ+5aGgvgVLKkXZuMDuqK2m0b3376NU86IvO931JJnWF3Y9oETnFuSeHhawRws3r5fKxPj62n1bJ+Nck309g3Rkogk+dtxsoMRpFHbkVkEJbYuNFbd9Ckp9iEBGg==; _gat_UA-29776811-1=1; flightNumOfAdults=2; flightNumChildren=0; flightNumInfants=0; _ceg.s=p55osx; _ceg.u=p55osx; tvl=f3wCB3cKgUze5BpspQzAL+mnbaBIfEBR1bZE25xsOsUHUhJKz+1BoXpjQ8ko3dXyx1H9zS2r3tClyNNaIAJvASYxrk4+3Fd1EeiF4nr50wwggIZXOzld30I2eDCTL0ejx7TZdMVrY3JC+jnOu/g8JmuJlTPIoD9abqH+9elXCiTYfe8wVkLTO+2MDDqUgSZcx7ED+JRciHNY/tnGBlozjkqkZXAVkE8MdQdphl5JgTtlvpEAEL7Pma3QLlxG+dGGRlv3hvKL2CDJjjw/ZIlNpQ==");
                //    fromDate.day = dtStartDate.Value.Day.ToString();
                //    fromDate.month = dtStartDate.Value.Month.ToString();
                //    fromDate.year = dtStartDate.Value.Year.ToString();

                //    endDate.day = dtEndDate.Value.Day.ToString();
                //    endDate.month = dtEndDate.Value.Month.ToString();
                //    endDate.year = dtEndDate.Value.Year.ToString();

                //    lsDates.Add(fromDate);
                //    lsDates.Add(endDate);
                //    data.dates = lsDates;
                //    url = "https://www.traveloka.com/api/v2/flight/search/depart2w";
                //}
                request.data = data;
                String dataResponse = ticketControl.post(url, request, webHeader);

                return dataResponse;
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
            return null;
        }

        private void threadAnylizeData()
        {
            while(this.miThreadState != 0)
            {
                try
                {
                    if (this.mqResponseQueue.Count > 0)
                    {
                        Object o = this.mqResponseQueue.Dequeue();

                        if (o != null && o.GetType().IsAssignableFrom(typeof(Dictionary<String, Object>)))
                        {
                            invokeControlText(this.lbLoadingStatus,"Trạng thái: Đang tải dữ liệu từ website");
                            Dictionary<String, Object> data = (Dictionary<String, Object>)o;
                            JToken jsonSearchResult = ((JObject)data["data"])["searchResults"];

                            if (jsonSearchResult != null && jsonSearchResult.Count() > 0)
                            {
                                decimal minData = 0;
                                List<ATKAirTicketInfoObject> atkFlightInfo = JsonConvert.DeserializeObject<List<ATKAirTicketInfoObject>>(jsonSearchResult.ToString());

                                foreach(ATKAirTicketInfoObject atk in atkFlightInfo)
                                {
                                    decimal ticketPrice = Convert.ToDecimal(atk.desktopPrice.amount);
                                    if (minData == 0 || minData > ticketPrice)
                                    {
                                        minData = ticketPrice;
                                    }
                                    invokeDataGrid(this.dataTicket, atk);
                                }
                                //Console.Write(atkFlightInfo.ToString());
                                invokeControlText(this.lbLoadingStatus, "Trạng thái: Tải dữ liệu hoàn tất. giá vé thấp nhất là " + String.Format("{0:c}", minData));
                                continue;
                            }
                        }else if (o != null && o.GetType().IsAssignableFrom(typeof(List<JToken>)))
                        {

                        }
                    }
                }
                catch(Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
                Thread.Sleep(200);
            }
        }

        private void threadScheduler()
        {
            invokeControlEnable(this.groupSearch, false);
            invokeControlEnable(this.btnSetting, false);
            invokeControlText(this.lbScanTicketState, "Quét vé rẻ: Đang chạy");
            this.mblIsSchedulerRunning = true;
            int iTimeDelay = this.emailObject.ticketTimeDelayLoad;
            AirTicketControll airTicketControll = new AirTicketControll();

            DateTime dtScanToDate = DateTime.ParseExact(emailObject.scanToDate.day + "/" + emailObject.scanToDate.month + "/" + emailObject.scanToDate.year, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtScanFromDate = DateTime.ParseExact(emailObject.scanFromDate.day + "/" + emailObject.scanFromDate.month + "/" + emailObject.scanFromDate.year, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if(iTimeDelay > 10000)
            {
                iTimeDelay = 100;
            }
            while (this.miThreadState != 0 && dtScanFromDate <= dtScanToDate)
            {
                try
                {
                    emailObject.scanFromDate.day = Convert.ToString( dtScanFromDate.Day);
                    emailObject.scanFromDate.month = Convert.ToString(dtScanFromDate.Month);

                    String dataResponse = getTicketTraveloka(emailObject);
                    Dictionary<String, Object> data = JsonConvert.DeserializeObject<Dictionary<String, Object>>(dataResponse);

                    this.mqResponseMinTicketQueue.Enqueue(data);
                    dtScanFromDate = dtScanFromDate.AddDays(1);
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
                //for (int i = 0; i < iTimeDelay && this.miThreadState != 0 && dtScanFromDate <= dtScanToDate; i++)
                //{
                //    Thread.Sleep(1000);
                //}
                Thread.Sleep(iTimeDelay);
            }
            this.mblIsSchedulerRunning = false;
            invokeControlEnable(this.btnSetting, true);
            invokeControlText(this.lbScanTicketState, "Quét vé rẻ: Đã dừng");
            invokeControlEnable(this.groupSearch, true);
        }

        private void threadPutTicketInfo()
        {
            while (this.miThreadState != 0 )
            {
                try
                {
                    Object o = this.mqResponseMinTicketQueue.Dequeue();

                    if (o != null)
                    {
                        Dictionary<String, Object> data = (Dictionary<String, Object>)o;
                        JToken jsonSearchResult = (JToken)((JObject)data["data"])["searchResults"];
                        String jsonSearchId = ((JObject)data["data"])["searchId"].ToString();

                        if (jsonSearchResult != null && jsonSearchResult.Count() > 0)
                        {
                            decimal minData = 0;
                            List<ATKAirTicketInfoObject> atkFlightInfo = JsonConvert.DeserializeObject<List<ATKAirTicketInfoObject>>(jsonSearchResult.ToString());
                            ATKAirTicketInfoObject atkMin = null;

                            foreach (ATKAirTicketInfoObject atk in atkFlightInfo)
                            {
                                decimal ticketPrice = Convert.ToDecimal(atk.desktopPrice.amount);
                                if (minData == 0 || minData > ticketPrice)
                                {
                                    minData = ticketPrice;
                                    atkMin = atk;
                                }
                            }
                            if (minData > 0)
                            {
                                //airTicketControll.sendEmail(emailObject);
                                //atkMin.tripLink =  tripTicket(atkMin.flightId, jsonSearchId);
                                atkMin.searchId = jsonSearchId;
                                invokeDataGrid(this.dataTicket, atkMin);
                                this.mqTripRequestQueue.Enqueue(atkMin);

                            }
                            continue;
                        }
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
                //for (int i = 0; i < iTimeDelay && this.miThreadState != 0 && dtScanFromDate <= dtScanToDate; i++)
                //{
                //    Thread.Sleep(1000);
                //}
                Thread.Sleep(500);
            }
        }

        private void invokeDataGrid(DataGridView dgv, ATKAirTicketInfoObject atkTicketInfo )
        {
            if(dgv.InvokeRequired)
            {
                dgv.Invoke(new Action<DataGridView, ATKAirTicketInfoObject>(invokeDataGrid), new Object[] { dgv, atkTicketInfo });
            }else
            {
                List<ATKConnectingFlightRoutes> atkConnectingFightRoutesList = atkTicketInfo.connectingFlightRoutes;

                foreach (ATKConnectingFlightRoutes atkRoute in atkConnectingFightRoutesList)
                {
                    // if (this.comboSourcePlace.Text.Equals(atkRoute.departureAirport) && this.comboDesPlace.Text.Equals(atkRoute.arrivalAirport))
                    //{
                    String providerId = atkRoute.providerId;

                    if ("EV".Equals(providerId))
                    {
                        providerId = "Vietam Airline";
                    }
                    else if ("BL_c".Equals(providerId))
                    {
                        providerId = "Jet star";
                    }
                    else if ("VJ_c".Equals(providerId))
                    {
                        providerId = "Viet jet";
                    }

                    String amount = atkTicketInfo.desktopPrice.amount;
                    ATKFlightDate atkStartDate = atkTicketInfo.connectingFlightRoutes[0].segments[0].departureDate;
                    ATKHourDetails atkStartTime = atkTicketInfo.connectingFlightRoutes[0].segments[0].departureTime;
                    ATKFlightDate atkArriverDate = atkTicketInfo.connectingFlightRoutes[0].segments[0].arrivalDate;
                    ATKHourDetails atkArriverTime = atkTicketInfo.connectingFlightRoutes[0].segments[0].arrivalTime;
                    String startTime = atkStartTime.hour + ":" + atkStartTime.minute + " " + atkStartDate.day + "/" + atkStartDate.month + "/" + atkStartDate.year;
                    String arriverTime = atkArriverTime.hour + ":" + atkArriverTime.minute + " " + atkArriverDate.day + "/" + atkArriverDate.month + "/" + atkArriverDate.year;
                    int iRowNumber = dgv.Rows.Count + 1;

                    dgv.Rows.Add(new Object[] { iRowNumber, atkTicketInfo.searchId, providerId, atkRoute.departureAirport + " " + startTime, atkRoute.arrivalAirport + " " + arriverTime, Convert.ToDecimal(amount), atkTicketInfo.tripLink });
                    invokeControlText(this.lbScanTicketState, "Trạng thái: " + iRowNumber + " vé được tìm thấy");
                    //}
                }
            }
        }

        private void invokeFillDataGrid(DataGridView dgv, ATKAirTicketInfoObject atkTicketInfo)
        {
            if (dgv.InvokeRequired)
            {
                dgv.Invoke(new Action<DataGridView, ATKAirTicketInfoObject>(invokeFillDataGrid), new Object[] { dgv, atkTicketInfo });
            }
            else
            {
                int iRowNumber = dgv.Rows.Count;

                for (int i = 0; i < iRowNumber ; i++)
                {
                    String searchId = dgv.Rows[i].Cells[1].Value.ToString();

                    if(searchId.Equals(atkTicketInfo.searchId))
                    {
                        dgv.Rows[i].Cells[6].Value = atkTicketInfo.tripLink;
                        break;
                    }
                }
            }
        }


        private void invokeControlText(Control c, String s)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new Action<Control, String>(invokeControlText), new Object[] { c, s });
            }
            else
            {
                c.Text = s;
            }
        }

        private void invokeControlEnable(Control c, Boolean b)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new Action<Control, Boolean>(invokeControlEnable), new Object[] { c, b });
            }
            else
            {
                c.Enabled = b;
            }
        }

        private void FormAirTicket_Load(object sender, EventArgs e)
        {

        }

        private void initFileConfig()
        {
            try
            {
                var data = new Dictionary<string, string>();
                foreach (var row in File.ReadAllLines(Program.PATH_TO_FILE))
                {
                    if("".Equals(row.Trim()))
                    {
                        continue;
                    }
                    String key = row.Split('=')[0];
                    String value = string.Join("=", row.Split('=').Skip(1).ToArray());

                    data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
                }

                emailObject = new EmailObject();

                emailObject.smtpServer = data[Program.EMAIL_SERVER_PROP].Trim();
                emailObject.emailPort = Convert.ToInt32(data[Program.EMAIL_PORT_PROP].Trim());
                emailObject.emailUserName = data[Program.EMAIL_USER_NAME_PROP].Trim();
                emailObject.emailPassword = data[Program.EMAIL_PASSWORD_PROP].Trim();
                emailObject.emailTo = data[Program.EMAIL_TO_PROP].Trim();
                emailObject.ticketPriceFrom = Convert.ToInt32(data[Program.TICKET_PRICE_FROM_PROP].Trim());
                emailObject.ticketPriceTo = Convert.ToInt32(data[Program.TICKET_PRICE_TO_PROP].Trim());
                emailObject.ticketTimeDelayLoad = Convert.ToInt32(data[Program.TICKET_TIME_DELAY_LOAD_PROP].Trim());

                emailObject.ticketSource = data["ticket.source-place"].Trim();
                emailObject.ticketDestination = data["ticket.destination-place"].Trim();
                emailObject.numAdult = data["ticket.num-adults"].Trim();
                emailObject.numChild = data["ticket.num-children"].Trim();
                emailObject.numInfant = data["ticket.num-fants"].Trim();
                emailObject.seatPublishedClass = data["ticket.seat-published-class"].Trim();
                this.jsonPostData = data["ticket.json-trip"].Trim();

                String[] scanFromDate = data["ticket.scan-from-date"].Trim().Split('-');
                String[] scanToDate = data["ticket.scan-to-date"].Trim().Split('-');
                ATKFlightDate fromDate = new ATKFlightDate();
                ATKFlightDate toDate = new ATKFlightDate();

                fromDate.day = scanFromDate[0];
                fromDate.month = scanFromDate[1];
                fromDate.year = scanFromDate[2];

                toDate.day = scanToDate[0];
                toDate.month = scanToDate[1];
                toDate.year = scanToDate[2];

                emailObject.scanFromDate = fromDate;
                emailObject.scanToDate = toDate;
                emailObject.emailSendTimeout = 240000;
                emailObject.emailSubject = "Giá vé máy bay";
                emailObject.emailContent = "Vé giá rẻ";
                data.Clear();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void udPeopleNumber_ValueChanged(object sender, EventArgs e)
        {
            int iPeople = Convert.ToInt32(udPeopleNumber.Text);
            int iChildren = Convert.ToInt32(udChildren.Text);

            if (iPeople + iChildren > 7)
            {
                udPeopleNumber.Maximum = 7 - udChildren.Value;
                MessageBox.Show("Số người lớn và trẻ em không được lớn hơn 7", "Thông báo");
            }
            else
            {
                udPeopleNumber.Maximum = 7 - udChildren.Value;
                udChildren.Maximum = 7 - udPeopleNumber.Value;
            }
        }

        private void udChildren_ValueChanged(object sender, EventArgs e)
        {
            int iPeople = Convert.ToInt32(udPeopleNumber.Text);
            int iChildren = Convert.ToInt32(udChildren.Text);

            if (iPeople + iChildren > 7)
            {
                udChildren.Maximum = 7 - udPeopleNumber.Value;
                MessageBox.Show("Số người lớn và trẻ em không được lớn hơn 7", "Thông báo");
            }
            else
            {
                udChildren.Maximum = 7 - udPeopleNumber.Value;
            }
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtStartDate.Value < DateTime.Today)
            {
                MessageBox.Show("Thời gian bắt đầu di chuyển phải là hôm nay hoặc trong tương lai.", "Thông báo");
                this.dtStartDate.Value = DateTime.Today;
            }
            else
            {
                dateChanged();
            }
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtEndDate.Value < DateTime.Today || this.dtEndDate.Value <  this.dtStartDate.Value)
            {
                MessageBox.Show("Thời gian Kết thúc di chuyển phải là hôm nay hoặc trong tương lai không được nhỏ hơn thời gian bắt đầu.", "Thông báo");
                dateChanged();
            }
        }

        private void dateChanged()
        {
            this.dtEndDate.Value = this.dtStartDate.Value;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            //FormSchedulerSetting formSchedulerSetting = new FormSchedulerSetting();

            //formSchedulerSetting.ShowDialog();

            if (this.mblIsSchedulerRunning)
            {
                MessageBox.Show("Tiến trình quét lịch chọn vé máy bay rẻ nhất trong ngày đang chạy xin hãy đợi");
            }
            else
            {
                initFileConfig();
                ThreadStart threadStart = new ThreadStart(threadScheduler);
                Thread thread = new Thread(threadStart);

                thread.IsBackground = true;
                thread.Start();
            }
        }

        private String tripTicket(String flightIds, String searchId)
        {
            String tripLink = "";
            try
            {
                AirTicketControll ticketControl = new AirTicketControll();
                WebHeaderCollection webHeader = new WebHeaderCollection();

                webHeader.Add("origin", "https://www.traveloka.com");
                webHeader.Add("x-domain", "trip");
                webHeader.Add("x-route-prefix", "vi-vn");

                String url = "https://www.traveloka.com/api/v2/trip/booking/createBooking";
                String jsonPost = this.jsonPostData.Replace("%flightIds%", flightIds);

                jsonPost = jsonPost.Replace("%searchId%", searchId);
                webHeader.Add("Cookie", "__flash={}; _ga=GA1.2.932927324.1520040064; G_ENABLED_IDPS=google; ajs_group_id=null; ajs_anonymous_id=%22d486c849-3bdd-47ac-ac45-08f498e8d791%22; cto_lwid=089dc1ee-2bc0-462a-926a-c7b268f0568b; __zlcmid=lFhA7B3G6c3dki; __ssid=6feafe47-4261-4b22-b7ee-64a51e03cb04; ab-testingGroup.testingWebTreatmentA=testingWebControlA; ab-testingGroup.testingWebTreatmentB=testingWebControlB; ab-testingGroup.testingMWebTreatmentA=testingMWebDefaultA; ab-testingGroup.testingMWebTreatmentB=testingMWebDefaultB; ab-flight.international-roundtrip=existing; ab-payment.paymentflow=existing; ab-promoBanner.promoNewExperience=promoNewExperience1; _gid=GA1.2.1426010023.1520259895; tvs=3XL5Gyq/zs8YRbSAew0nhzRK2evJ+5aGgvgVLKkXZuMDuqK2m0b3376NU86IvO931JJnWF3Y9oETnFuSeHhawRws3r5fKxPj62n1bJ+Nck309g3Rkogk+dtxsoMRpFHbkVkEJbYuNFbd9Ckp9iEBGg==; lux_uid=152039431443311479; tv-repeat-visit=true; smartlock-login=1; useDateFlow=false; usePromoFinder=null; flightSourceAirport=HAN; flightDestinationAirport=DAD; flightDepartureDate=08-03-2018; flightFlightType=ONE_WAY; flightNumOfAdults=1; flightNumChildren=0; flightNumInfants=0; flightSeatClassType=ECONOMY; state-auth=auth-78f45d0d-7b35-456d-9347-87a8eb1fb39f; ContactData={\"LAST_FIRST_NAME\":{\"isCollapse\":false,\"refill\":false,\"value\":{\"travelerForm\":{\"formInput\":{\"title\":\"\",\"name.last\":\"Nguyen\",\"name.first\":\"Xuan Tuan\",\"phoneNumber\":{\"phoneNumber\":\"929540426\",\"countryCode\":\" + 84\"},\"emailAddress\":\"tieuthiendoan.cntt@gmail.com\",\"birthDate\":\"\"},\"isValid\":true}}}}; ajs_user_id=%2242861351%22; _gac_UA-29776811-1=1.1520395990.CjwKCAiAlfnUBRBQEiwAWpPA6TZgKjk6ZdJuSqXRGWkgv3hmUO4cVpXDrR6gk5kOg6SrEU3X-eJxvRoC58sQAvD_BwE; _gat_UA-29776811-1=1; _ceg.s=p57d2j; _ceg.u=p57d2j; tvl=f3wCB3cKgUze5BpspQzAL+mnbaBIfEBR1bZE25xsOsWsPPWszMeAHkdo2XfCHTXMvU7UKnleeYKZhIdm/y7tg8DISWhSiWHJLcgfyUw/F/jFCtAJafaLukW3Dk3e/MdVsxlGJ5c1xaiqlZf4sYlJoLc+x0bsKpyv/hSD8kwGuv/jq+/45jtiOk65SvLIsLujDMOYgLFZcPtnR0EAW6WkwvLisRJheKrjuY8z7x1kqvtUXGXXY+wZPDX8IV5JxnNDCyS8tcROxPpCLTntnwa6TVdrhNK/XI55frdH1RDzjUc=; _uetsid=_uet12319eae");
                
                String dataResponse = ticketControl.postJson(url, jsonPost, webHeader);
                Dictionary<String, Object> data = JsonConvert.DeserializeObject<Dictionary<String, Object>>(dataResponse);
                String invoiceId = ((JObject)data["data"])["invoiceId"].ToString();
                String auth = ((JObject)data["data"])["auth"].ToString();

                tripLink = "https://www.traveloka.com/vi-vn/partner/trinusa/selectPayment?auth="+auth+"&iid=" + invoiceId;
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
            return tripLink;
        }

        private void threadTripTicket()
        {
            while (this.miThreadState != 0)
            {
                try
                {
                    Object o = this.mqTripRequestQueue.Dequeue();

                    if (o != null)
                    {
                        ATKAirTicketInfoObject atkMin = (ATKAirTicketInfoObject)o;

                        atkMin.tripLink =  tripTicket(atkMin.flightId, atkMin.searchId);
                        invokeFillDataGrid(dataTicket,atkMin);
                        continue;
                    }
                            
                }
                catch (Exception exp)
                {
                    //Console.WriteLine(exp.Message);
                }
                Thread.Sleep(100);
            }
        }
    }
}
