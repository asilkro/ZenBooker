using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class AdminPw : Form
{
    public AdminPw()
    {
        InitializeComponent();
    }


    private void BackBtn_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void SaveBtn_Click(object sender, EventArgs e)
    {
        if (!Helpers.ValidateLogin(userTb.Text, oldPwTB.Text)) return;
        if (!Helpers.DoTheyMatch(newPwTB1.Text, newPwTB2.Text))
        {
            MessageBox.Show("New passwords don't match.");
            return;
        }
        var result = Helpers.PasswordUpdated(userTb.Text, Helpers.HashedString(newPwTB1.Text));
        if (!result) return;
        MessageBox.Show("Password updated.");
        Close();
    }
}