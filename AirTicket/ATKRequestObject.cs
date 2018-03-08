using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTicket
{
    [Serializable]
    public class ATKRequestObject
    {
        public String clientInterface
        {
            get;
            set;
        }

        public ATKDataObject data
        {
            get;
            set;
        }

        public List<String> fields
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ATKDataObject
    {
        public String currency
        {
            get;
            set;
        }

        public String destinationAirportOrArea
        {
            get;
            set;
        }

        public Boolean isReschedule
        {
            get;
            set;
        }

        public String locale
        {
            get;
            set;
        }

        public Boolean newResult
        {
            get;
            set;
        }

        public String seatPublishedClass
        {
            get;
            set;
        }

        public String seqNo
        {
            get;
            set;
        }

        public String sourceAirportOrArea
        {
            get;
            set;
        }

        public String searchId
        {
            get;
            set;
        }

        public String affiliateId
        {
            get;
            set;
        }

        public Boolean usePromoFinder
        {
            get;
            set;
        }

        public Boolean useDateFlow
        {
            get;
            set;
        }

        public ATKFlightDate flightDate {
            get;
            set;
        }

        public NumSeats numSeats
        {
            get;
            set;
        }

        public SortFilter sortFilter
        {
            get;
            set;
        }

        public List<ATKFlightDate> dates
        {
            get;
            set;
        }

        public List<String> airportOrAreaCodes
        {
            get;
            set;
        }
    }
    [Serializable]
    public class ATKFlightDate
    {
        public String day
        {
            get;
            set;
        }

        public String month
        {
            get;
            set;
        }

        public String year
        {
            get;
            set;
        }
    }

    [Serializable]
    public class NumSeats
    {
        public String numAdults
        {
            get;
            set;
        }

        public String numChildren
        {
            get;
            set;
        }

        public String numInfants
        {
            get;
            set;
        }
    }

    [Serializable]
    public class SortFilter
    {
        public List<String> filterAirlines
        {
            get;
            set;
        }
        public List<String> filterArrive {
            get;
            set;
        }
        public List<String> filterDepart
        {
            get;
            set;
        }

        public List<String> filterTransit
        {
            get;
            set;
        }

        public String selectedDeparture
        {
            get;
            set;
        }
        
        public String sort
        {
            get; set;
        }
    }
}
