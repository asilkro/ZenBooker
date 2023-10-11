namespace ZenoBook.Forms;

public partial class Main : Form
{

    public Main(Login login)
    {
        InitializeComponent();
    }

    private void logoutBtn_Click(object sender, EventArgs e)
    {
        var newLogin = new Login();
       newLogin.Activate();
        Close();
    }
}