namespace ZenoBook.Forms
{
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

    }
}