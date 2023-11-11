using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class AdminPW : Form
{
    public AdminPW()
    {
        InitializeComponent();
    }


    private void backBtn_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void saveBtn_Click(object sender, EventArgs e)
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