using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverWatch
{
    public partial class Form1 : Form
    {
        Random RNG = new Random();

        public Form1()
        {
            InitializeComponent();
        }




        private void PopulateDataGridView(DataGridView dataGrid)
        {
            List<string[]> rows = new List<string[]>();

            string[] row0 = GenerateRow("Arduino Uno R3");
            rows.Add(row0);
            row0 = GenerateRow("Arduino Mega 2560");
            rows.Add(row0);
            row0 = GenerateRow("Arduino Esplora");
            rows.Add(row0);
            row0 = GenerateRow("Arduino Wifi Shield");
            rows.Add(row0);
            row0 = GenerateRow("Arduino Ethernet Shield");
            rows.Add(row0);
            row0 = GenerateRow("MSP-430 Launchpad");
            rows.Add(row0);
            row0 = GenerateRow("Android IOIO");
            rows.Add(row0);
            row0 = GenerateRow("Phidget Servo Controller");
            rows.Add(row0);
            row0 = GenerateRow("Phidget RFID Kit");
            rows.Add(row0);
            row0 = GenerateRow("USB Wifi/Bluetooth Adapter");
            rows.Add(row0);
            row0 = GenerateRow("USB-A Cable");
            rows.Add(row0);
            row0 = GenerateRow("USB-B Cable");
            rows.Add(row0);
            row0 = GenerateRow("USB-C Cable");
            rows.Add(row0);
            row0 = GenerateRow("Basic Stamp 2");
            rows.Add(row0);
            row0 = GenerateRow("8-bit DAC");
            rows.Add(row0);
            row0 = GenerateRow("16-bit ADC");
            rows.Add(row0);
            row0 = GenerateRow("Flux Capacitor");
            rows.Add(row0);
            row0 = GenerateRow("Vortex Manipulator");
            rows.Add(row0);
            row0 = GenerateRow("Sonic Screwdriver");
            rows.Add(row0);
            row0 = GenerateRow("16Mhz Oscillator");
            rows.Add(row0);
            row0 = GenerateRow("1 Amp H-bridge");
            rows.Add(row0);
            row0 = GenerateRow("Ilum Crystal");
            rows.Add(row0);

            foreach (string[] row in rows)
            {
                dataGrid.Rows.Add(row);
            }

            dataGrid.Sort(ItemName, ListSortDirection.Ascending);
        }

        private string[] GenerateRow(string itemName)
        {
            string[] row = { itemName, "QTY", "STAT", "STOCK" };

            int qty = RNG.Next(2, 20);
            int stock = qty - RNG.Next(qty);
            row[2] = "-";

            if (((float)stock/(float)qty) < 0.33f)
            { row[2] = "LOW"; }

            if (stock == 0)
            { row[2] = "EMPTY"; }

            if (RNG.Next(20) <= 1)
            { row[2] = "DENIED"; }

            row[1] = Convert.ToString(qty);
            row[3] = Convert.ToString(stock);

            return row;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateDataGridView(dataGridView1);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                textBox1.Text = Convert.ToString(selectedRow.Cells["ItemName"].Value);
                textBox2.Text = Convert.ToString(selectedRow.Cells["Quantity"].Value);
                textBox3.Text = Convert.ToString(selectedRow.Cells["Status"].Value);
                textBox4.Text = Convert.ToString(selectedRow.Cells["InStock"].Value);
            }
        }
    }
}
