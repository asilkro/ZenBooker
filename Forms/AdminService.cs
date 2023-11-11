using log4net;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class AdminService : Form
{
    private readonly bool _existing;
    public AdminService()
    {
        _existing = false;
        InitializeComponent();
        serviceIdTB.Text = Helpers.AutoIncrementId("service");
    }

    public AdminService(Service svc)
    {
        _existing = true;
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
        var svc = new Service
        {
            service_name = serviceNameTB.Text,
            service_description = serviceDescTB.Text
        };
        if (!IsThereAProblem())
        {
            try
            {
                switch (_existing)
                {
                    case true:
                        svc.service_id = int.Parse(serviceIdTB.Text);
                        if (Helpers.UpdateService(svc))
                        {
                            Close();
                        }

                        break;
                    case false:
                        if (Helpers.InsertService(svc))
                        {
                            Close();
                        }

                        break;
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