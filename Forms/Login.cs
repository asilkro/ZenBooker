using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class Login : Form
{
    public Login()
    {
        InitializeComponent();
    }


    #region Buttons

    private void exitBtn_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    #endregion

    private void loginBtn_Click(object sender, EventArgs e)
    {
        var pwe = Security.GenerateEncryptionPw();
        if (!new Helpers().LoginIsValid(loginTB.Text, pwTB.Text, pwe))
            MessageBox.Show("Username/password not correct. Check and try again.", "Login failed");

        var main = new Main();
        Hide();
        main.Show();
    }
}