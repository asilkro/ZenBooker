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
        using var connection = new Builder().Connect();

        var result = new Helpers().LoginIsValid(loginTB.Text, pwTB.Text);
        switch (result)
        {
            case true:
                var main = new Main();
                ActiveForm?.Hide();
                main.Show();
                break;
            case false:
                MessageBox.Show("Username/password not correct. Check and try again.");
                break;
        }
    }

    private void exitBtn_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    #endregion
}