using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySqlConnector;
using ZenoBook.Classes;
using ZenoBook.DataManipulation;

namespace ZenoBook.Forms;

public partial class Main : Form
{

    public Main()
    {
        InitializeComponent();
        populateDGV(dataGridView1, "appointment");
    }

    public void populateDGV(DataGridView dgv, string tableName)
    {
        {
            using var connection = new Builder().Connect();
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * from @TABLE");
                cmd.Parameters.AddWithValue("@TABLE", tableName);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = cmd;

                DataTable table = new DataTable();
                dataAdapter.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;
                
                dgv.DataSource = bSource;
            }
        }
    }

    #region Event Handlers
    private void logoutBtn_Click(object sender, EventArgs e)
    {
        var newLogin = new Login();
        newLogin.Activate();
        Close();
    }
    private void CreateApptBtn_Click(object sender, EventArgs e)
    {
        var apptForm = new FormAppointment();
        apptForm.ShowDialog();
    }

    private void UpdateApptBtn_Click(object sender, EventArgs e)
    {
        var selected = dataGridView1.CurrentRow;
        if (selected != null)
        {
            var apptForm = new FormAppointment((Appointment)selected.DataBoundItem);
        }


    }

    private void RemoveApptBtn_Click(object sender, EventArgs e)
    {
        var selected = dataGridView1.CurrentRow;
        switch (selected.DataBoundItem.GetType())
        {
            case null:
                break;
            case HomeAppointment:
                
        }
    }


    #endregion



}