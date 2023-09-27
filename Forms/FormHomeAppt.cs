using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZenoBook.Classes;

namespace ZenoBook.Forms
{
    public partial class FormHomeAppt : Form
    {
        public FormHomeAppt()
        {
            InitializeComponent();
        }

        public FormHomeAppt(FormAppointment senderForm, int? cxId)
        {
            InitializeComponent();
            
            //TODO: use cxId to tie to address
        }

        public FormHomeAppt(FormAppointment senderForm, Appointment appt)
        {
            InitializeComponent();
        }
    }
}
