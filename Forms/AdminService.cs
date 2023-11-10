using log4net;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class AdminService : Form
{
    public AdminService()
    {
        InitializeComponent();
        serviceIdTB.Text = Helpers.AutoIncrementId("service");
    }

    public AdminService(Service svc)
    {
        InitializeComponent();
        PopulateServiceFields(svc);
    }

    #region Methods
    private void PopulateServiceFields(Service svc)
    {
        serviceIdTB.Text = svc.service_id.ToString();
        serviceNameTB.Text = svc.service_name;
        serviceDescTB.Text = svc.service_description;
    }

    private bool IsThereAProblem()
    {
        var problem = true;
        for (var index = 0; index < Controls.Count; index++)
        {
            var c = Controls[index];
            if (c is TextBox)
                if (!string.IsNullOrWhiteSpace(c.Text) &&
                    !string.IsNullOrEmpty(c.Text))
                {
                    problem = false;
                    break;
                }
        }

        if (int.TryParse(serviceIdTB.Text, out _))
        {
            problem = false;
        }

        return problem;
    }


    #endregion

    #region Event Handlers

    private void BackBtn_Click(object sender, EventArgs e) => Close();

    private void SaveBtn_Click(object sender, EventArgs e)
    {
        if (!IsThereAProblem())
        {
            var svc = new Service
            {
                service_name = serviceNameTB.Text,
                service_description = serviceDescTB.Text
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

    #endregion

}