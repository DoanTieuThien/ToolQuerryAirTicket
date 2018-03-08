using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirTicket
{
    static class Program
    {
        public static String PATH_TO_FILE = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString() + "\\App.ini";
        public static String EMAIL_SERVER_PROP = "email.server";
        public static String EMAIL_PORT_PROP = "email.port";
        public static String EMAIL_USER_NAME_PROP = "email.username";
        public static String EMAIL_PASSWORD_PROP = "email.password";
        public static String EMAIL_TO_PROP = "email.to";
        public static String TICKET_PRICE_FROM_PROP = "ticket.price-from";
        public static String TICKET_PRICE_TO_PROP = "ticket.price-to";
        public static String TICKET_TIME_DELAY_LOAD_PROP = "ticket.time.delay-load";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormAirTicket());
        }
    }
}
