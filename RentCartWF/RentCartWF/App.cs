using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCartWF
{
    public partial class App : MaterialForm
    {
        public App()
        {
            InitializeComponent();
        }

        private void VehclesType_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rENTCARTDataSet.Inspections' table. You can move, or remove it, as needed.
            this.inspectionsTableAdapter.Fill(this.rENTCARTDataSet.Inspections);
            // TODO: This line of code loads data into the 'rENTCARTDataSet.Inspections' table. You can move, or remove it, as needed.
            this.inspectionsTableAdapter.Fill(this.rENTCARTDataSet.Inspections);
            // TODO: This line of code loads data into the 'rENTCARTDataSet.FuelTypes' table. You can move, or remove it, as needed.
            this.fuelTypesTableAdapter.Fill(this.rENTCARTDataSet.FuelTypes);
            // TODO: This line of code loads data into the 'rENTCARTDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.rENTCARTDataSet.Employees);
            // TODO: This line of code loads data into the 'rENTCARTDataSet.VehicleModels' table. You can move, or remove it, as needed.
            this.vehicleModelsTableAdapter.Fill(this.rENTCARTDataSet.VehicleModels);
            // TODO: This line of code loads data into the 'rENTCARTDataSet.Vehicles' table. You can move, or remove it, as needed.
            this.vehiclesTableAdapter.Fill(this.rENTCARTDataSet.Vehicles);
            // TODO: This line of code loads data into the 'rENTCARTDataSet.Brands' table. You can move, or remove it, as needed.
            this.brandsTableAdapter.Fill(this.rENTCARTDataSet.Brands);
            // TODO: This line of code loads data into the 'rENTCARTDataSet.Clients' table. You can move, or remove it, as needed.
            this.clientsTableAdapter.Fill(this.rENTCARTDataSet.Clients);
            // TODO: This line of code loads data into the 'rENTCARTDataSet.VehicleTypes' table. You can move, or remove it, as needed.
            this.vehicleTypesTableAdapter.Fill(this.rENTCARTDataSet.VehicleTypes);

            this.reportViewer1.RefreshReport();
        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialTabSelector2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialTabSelector3_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel4_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveBrands_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

       
    }
}
