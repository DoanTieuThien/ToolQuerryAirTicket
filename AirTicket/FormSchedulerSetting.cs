using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirTicket
{
    public partial class FormSchedulerSetting : Form
    {
        public FormSchedulerSetting()
        {
            InitializeComponent();
        }

        private void numericEmailPort_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FormSchedulerSetting_Load(object sender, EventArgs e)
        {
            initForm();
        }

        private void initForm()
        {
            try
            {
                var data = new Dictionary<string, string>();
                foreach (var row in File.ReadAllLines(Program.PATH_TO_FILE))
                {
                    String key = row.Split('=')[0];
                    String value = string.Join("=", row.Split('=').Skip(1).ToArray());

                    data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
                }

                txtEmailServer.Text = data[Program.EMAIL_SERVER_PROP].Trim();
                numericEmailPort.Value  = Convert.ToDecimal (data[Program.EMAIL_PORT_PROP].Trim());
                txtEmailUserName.Text = data[Program.EMAIL_USER_NAME_PROP].Trim();
                txtEmailPassword.Text = data[Program.EMAIL_PASSWORD_PROP].Trim();
                txtEmailTo.Text = data[Program.EMAIL_TO_PROP].Trim();
                txtTicketPriceFrom.Text = data[Program.TICKET_PRICE_FROM_PROP].Trim();
                txtTicketPriceTo.Text = data[Program.TICKET_PRICE_TO_PROP].Trim();
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
