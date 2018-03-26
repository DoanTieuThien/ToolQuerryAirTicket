using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTicket
{
    [Serializable]
    public class ATKAirTicketInfoObject
    {
        public String searchId
        {
            get;
            set;
        }

        public List<ATKConnectingFlightRoutes> connectingFlightRoutes
        {
            get;
            set;
        }

        public List<ATKFlightMetadata> flightMetadata
        {
            get;
            set;
        }

        public String totalNumStop
        {
            get;
            set;
        }

        public Boolean mobileAppDeal
        {
            get;
            set;
        }

        public String tripDuration
        {
            get;
            set;
        }

        public ATKAdditionalInfo additionalInfo
        {
            get;
            set;
        }

        public Boolean flexibleTicket
        {
            get;
            set;
        }

        public ATKAirlineFareInfo airlineFareInfo
        {
            get;
            set;
        }

        public ATKAgentFareInfo agentFareInfo
        {
            get;
            set;
        }

        public String flightId
        {
            get;
            set;
        }

        public ATKMAppsPrice desktopPrice
        {
            get;
            set;
        }

        public ATKMAppsPrice mAppsPrice
        {
            get;
            set;
        }

        public String deltaPrice
        {
            get;
            set;
        }
        public String bundleFareInfo
        {
            get;
            set;
        }
        public String loyaltyPoint
        {
            get;
            set;
        }

        public String tripLink
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKAgentFareInfo
    {
        public ATKMAppsPrice totalSearchFare
        {
            get;
            set;
        }

        public String totalAdditionalFare
        {
            get;
            set;
        }

        public List<ATKDetailedSearchFares> detailedSearchFares
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKAirlineFareInfo
    {
        public ATKMAppsPrice totalSearchFare
        {
            get;
            set;
        }

        public ATKMAppsPrice totalAdditionalFare
        {
            get;
            set;
        }

        public List<ATKDetailedSearchFares> detailedSearchFares
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKDetailedSearchFares
    {
        public ATKAncillaryFare ancillaryFare
        {
            get;
            set;
        }

        public ATKFlightRouteFares flightRouteFares
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKFlightRouteFares
    {
        public ATKMAppsPrice adultAirlineFare
        {
            get;
            set;
        }

        public ATKMAppsPrice adultBaseFare
        {
            get;
            set;
        }

        public ATKMAppsPrice childBaseFare
        {
            get;
            set;
        }

        public ATKMAppsPrice infantBaseFare
        {
            get;
            set;
        }

        public ATKMAppsPrice baseFareTotal
        {
            get;
            set;
        }

        public ATKMAppsPrice vatTotal
        {
            get;
            set;
        }

        public ATKMAppsPrice compulsoryInsuranceTotal
        {
            get;
            set;
        }

        public ATKMAppsPrice pscTotal
        {
            get;
            set;
        }

        public ATKMAppsPrice fuelSurchargeTotal
        {
            get;
            set;
        }

        public ATKMAppsPrice adminFeeTotal
        {
            get;
            set;
        }

        public ATKMAppsPrice totalAirlineFare
        {
            get;
            set;
        }

        public ATKMAppsPrice totalAdditionalFare
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKAncillaryFare
    {
        public List<String> addOnFares {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKAdditionalInfo
    {
        public String seatClassLabel
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKMAppsPrice
    {
        public String currency
        {
            get;
            set;
        }

        public String amount
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKConnectingFlightRoutes
    {
        public String departureAirport
        {
            get;
            set;
        }

        public String arrivalAirport
        {
            get;
            set;
        }

        public String providerId
        {
            get;
            set;
        }

        public String dateTimeStamp
        {
            get;
            set;
        }

        public String numDayOffset
        {
            get;
            set;
        }

        public String totalNumStop
        {
            get;
            set;
        }

        public ATKFlightRefundInfo flightRefundInfo
        {
            get;
            set;
        }

        public ATKFlightRescheduleInfo flightRescheduleInfo
        {
            get;
            set;
        }

        public List<ATKRouteInventories> routeInventories
        {
            get;
            set;
        }

        public List<ATKSegments> segments
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKFlightRescheduleInfo
    {
        public String rescheduleStatus
        {
            get;
            set;
        }

        public String rescheduleInfoSummary
        {
            get;
            set;
        }

        public List<String> policyDetails
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKRouteInventories
    {
        public String seatPublishedClass
        {
            get;
            set;
        }

        public String seatClass
        {
            get;
            set;
        }

        public String numSeatLeft
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKFlightRefundInfo
    {
        public String refundableStatus
        {
            get;
            set;
        }
        public String refundInfoSummary
        {
            get;
            set;
        }
        public List<String> policyDetails
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKFlightMetadata
    {
        public String currency
        {
            get;
            set;
        }

        public String airlineId
        {
            get;
            set;
        }

        public String sourceAirport
        {
            get;
            set;
        }

        public String destinationAirport
        {
            get;
            set;
        }

        public String numAdult
        {
            get;
            set;
        }

        public String numChild
        {
            get;
            set;
        }

        public String numInfant
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKSearchResultObject
    {
        public String userContext
        {
            get;
            set;
        }

        public ATKSearchDataObject data
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKSearchDataObject
    {
        public Boolean searchCompleted
        {
            get;
            set;
        }

        public String seqNo
        {
            get;
            set;
        }

        public String searchId
        {
            get;
            set;
        }

        public String currency
        {
            get;
            set;
        }

        public String currencyDecimalPlaces
        {
            get;
            set;
        }

        public String loyaltyPointEligibility
        {
            get;
            set;
        }

        public ATKAirlineDataMap airlineDataMap
        {
            get;
            set;
        }

        public ATKFlightSeoInfo flightSeoInfo
        {
            get;
            set;
        }

        public ATKAirlineDataMap airportDataMap
        {
            get;
            set;
        }

        public List<ATKSegments>  segments
        {
            get;
            set;
        }

        public List<String> promoLabels
        {
            get;
            set;
        }

        public String loyaltyPoint
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKAirlineDataMap
    {
        public ATKAirObject VN
        {
            get;
            set;
        }

        public ATKAirObject VJ
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKAirObject
    {
        public String airlineId
        {
            get;
            set;
        }

        public String name
        {
            get;
            set;
        }

        public String shortName
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKAirportDataMap
    {
        public ATKAirPortInfoObject SGN
        {
            get;
            set;
        }

        public ATKAirPortInfoObject DAD
        {
            get;
            set;
        }

        public ATKAirPortInfoObject HAN
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKAirPortInfoObject
    {
        public String airportId
        {
            get;
            set;
        }
        public String localName {
            get;
            set;
        }
        public String city
        {
            get;
            set;
        }
        public String country
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKFlightSeoInfo
    {
        public String url
        {
            get;
            set;
        }

        public String title
        {
            get;
            set;
        }

        public String description
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKSegments
    {
        public String departureAirport
        {
            get;
            set;
        }

        public String arrivalAirport
        {
            get;
            set;
        }

        public String flightNumber
        {
            get;
            set;
        }

        public String airlineCode
        {
            get;
            set;
        }

        public String brandCode
        {
            get;
            set;
        }

        public String operatingAirlineCode
        {
            get;
            set;
        }

        public String fareBasisCode
        {
            get;
            set;
        }

        public List<ATKSegmentInventories> segmentInventories
        {
            get;
            set;
        }

        public String aircraftType
        {
            get;
            set;
        }

        public Boolean hasMeal
        {
            get;
            set;
        }

        public ATKFreeBaggageInfo freeBaggageInfo
        {
            get;
            set;
        }

        public ATKFacilities facilities
        {
            get;
            set;
        }

        public List<String> flightLegInfoList
        {
            get;
            set;
        }


        public String numTransit
        {
            get;
            set;
        }
        public String durationMinute
        {
            get;
            set;
        }
        public String routeNumDaysOffset
        {
            get;
            set;
        }
        public String tzDepartureMinuteOffset
        {
            get;
            set;
        }
        public String tzArrivalMinuteOffset
        {
            get;
            set;
        }

        public ATKFlightDate departureDate
        {
            get;
            set;
        }

        public ATKFlightDate arrivalDate
        {
            get;
            set;
        }

        public ATKHourDetails departureTime
        {
            get;
            set;
        }

        public ATKHourDetails arrivalTime
        {
            get;
            set;
        }

        public Boolean visaRequired
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKSegmentInventories
    {
        public String seatClass
        {
            get;
            set;
        }
        public String numSeatsLeft
        {
            get;
            set;
        }
        public String publishedClass
        {
            get;
            set;
        }
        public String fareBasis
        {
            get;
            set;
        }
        public String refundable
        {
            get;
            set;
        }
        public String subclassInfo
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKFreeBaggageInfo
    {
        public String unitOfMeasure
        {
            get;
            set;
        }

        public String weight
        {
            get;
            set;
        }

        public String quantity
        {
            get;
            set;
        }

        public Boolean availableToBuy
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKHourDetails
    {
        public String hour
        {
            get;
            set;
        }

        public String minute
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKFacilities
    {
        public ATKWifi wifi
        {
            get;
            set;
        }

        public ATKEntertainment freeMeal
        {
            get;
            set;
        }

        public ATKEntertainment entertainment
        {
            get;
            set;
        }

        public ATKUsbAndPower usbAndPower
        {
            get;
            set;
        }

        public List<String> order
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKUsbAndPower
    {
        public Boolean usb
        {
            get;
            set;
        }

        public Boolean power
        {
            get;
            set;
        }

        public String chance
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKEntertainment
    {
        public Boolean available
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKWifi
    {
        public String code
        {
            get;
            set;
        }
        public String chance
        {
            get;
            set;
        }
    }

    public class EmailObject
    {
        public String smtpServer
        {
            get;
            set;
        }

        public int emailPort
        {
            get;
            set;
        }

        public int emailSendTimeout
        {
            get;
            set;
        }

        public String emailUserName
        {
            get;
            set;
        }

        public String emailPassword
        {
            get;
            set;
        }

        public String emailTo
        {
            get;
            set;
        }

        public String emailContent
        {
            get;
            set;
        }

        public String emailSubject
        {
            get;
            set;
        }

        public int ticketPriceFrom
        {
            get;
            set;
        }

        public int ticketPriceTo
        {
            get;
            set;
        }

        public int ticketTimeDelayLoad
        {
            get;
            set;
        }

        public String ticketSource
        {
            get;
            set;
        }

        public String ticketDestination
        {
            get;
            set;
        }
        public String numAdult
        {
            get;
            set;
        }

        public String numChild
        {
            get;
            set;
        }

        public String numInfant
        {
            get;
            set;
        }
        public String seatPublishedClass
        {
            get;
            set;
        }
        public ATKFlightDate scanFromDate
        {
            get;
            set;
        }
        public ATKFlightDate scanToDate
        {
            get;
            set;
        }
    }
}
