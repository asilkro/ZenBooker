using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class Login : Form
{
    public Login()
    {
        InitializeComponent();
        DebugLogin(); //TODO: REMOVE ME
    }

    public void DebugLogin() //TODO: REMOVE ME
    {
        loginTB.Text = "DarthVader";
        pwTB.Text = "DeathStar77";
    }

    #region Buttons

    private void LoginBtn_Click(object sender, EventArgs e)
    {
        if (!Helpers.NoProhibitedContent(loginTB.Text)) return;
        var result = LoginResult();
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

    private bool LoginResult()
    {
        using var connection = new Builder().Connect();
        var login = loginTB.Text;
        var password = pwTB.Text;
        var result = Helpers.ValidateLogin(login, password);
        return result;
    }

    private void ExitBtn_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    #endregion
}