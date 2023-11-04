using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class Login : Form
{
    public Login()
    {
        InitializeComponent();
        DebugLogin();
    }

    public void DebugLogin()
    {
        loginTB.Text = "DarthVader";
        pwTB.Text = "DeathStar77";
    }

    #region Buttons

    private void loginBtn_Click(object sender, EventArgs e)
    {
        var result = loginResult();
        switch (result)
        {
            case true:
                var main = new Main();
                main.Show();
                Hide();
                break;
            case false:
                MessageBox.Show("The login failed, check your credentials and try again.", "Login failed");
                break;
        }
    }

    private bool loginResult()
    {
        using var connection = new Builder().Connect();
        var login = loginTB.Text;
        var password = pwTB.Text;
        var result = Helpers.ValidateLogin(login, password);
        return result;
    }

    private void exitBtn_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    #endregion
}