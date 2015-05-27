using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PauseProgram
{
    public partial class Form1 : Form
    {

        BL bl = new BL();

        public Form1()
        {

            InitializeComponent();
            theDepartments();
            theStatus();

        }


        private void theStatus()
        {
            cmbBoxSchedule.ValueMember = "TypeId";
            cmbBoxSchedule.DisplayMember = "Text";
            cmbBoxSchedule.DataSource = bl.GetSchoolStatus();
        }

        private void theDepartments()
        {
            cmbDepartment.ValueMember = "LocationId";
            cmbDepartment.DisplayMember = "Location";
            cmbDepartment.DataSource = bl.GetDepartments();
           
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = bl.GetSchoolSystem((int)cmbDepartment.SelectedValue);
        }

        // Binding Navigatio - See https://msdn.microsoft.com/en-us/library/system.windows.forms.bindingnavigator.bindingsource(v=vs.110).aspx

        //Og https://www.youtube.com/watch?v=AVZPTzkQOcY

    }

}


