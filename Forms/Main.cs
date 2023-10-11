namespace ZenoBook.Forms;

public partial class Main : Form
{
    private Login login;

    public Main(Login login)
    {
        InitializeComponent();
        this.login = login;
    }

    public Main()
    {
    }

    private void logoutBtn_Click(object sender, EventArgs e)
    {
        if (ActiveForm != null) ActiveForm.Close();
    }
}