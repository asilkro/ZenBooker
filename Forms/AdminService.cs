using log4net;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms
{
    public partial class AdminService : Form
    {
        public AdminService()
        {
            InitializeComponent();
        }

        public AdminService(Service svc)
        {
            InitializeComponent();
            serviceIdTB.Text = svc.service_id.ToString();
            serviceNameTB.Text = svc.service_name;
            serviceDescTB.Text = svc.service_description;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var svc = new Service
            {
                service_name = serviceNameTB.Text,
                service_description = serviceDescTB.Text,
            };
            try
            {
                if (Helpers.DoesThisServiceExist(svc))
                {
                    svc.service_id = int.Parse(serviceIdTB.Text);
                    Helpers.UpdateService(svc);
                    Close();
                }
                else
                {
                    Helpers.InsertService(svc);
                    Close();
                }
            }
            catch (Exception ex)
            {

                LogManager.GetLogger("LoggingRepo").Warn(e, ex);

            }
        }
    }
}
