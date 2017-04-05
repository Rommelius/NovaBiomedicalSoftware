using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace NovaBiomedicalSoftware
{
    public partial class QASEquipmentDetails : MetroForm
    {

        public static string station, location,  vehiclenumber, registrationnumber;


        public QASEquipmentDetails()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            validation();

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
                    
            _stationBox.Text = "";
            _locationBox.Text = "";
            _vehicleNumberBox.Text = "";
            _registrationNumberBox.Text = "";

            _stationBox.Focus();
        }


        private void validation()
        {
            if (_stationBox.Text == "" || _locationBox.Text == "" || _registrationNumberBox.Text == "" ||
                _vehicleNumberBox.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "", "Please fill all the details required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                station = _stationBox.Text;
                location = _locationBox.Text;
                vehiclenumber = _vehicleNumberBox.Text;
                registrationnumber = _registrationNumberBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
