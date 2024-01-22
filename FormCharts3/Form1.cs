using FormCharts;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LiveCharts;
using LiveCharts.Wpf;


namespace FormCharts3
{
    public partial class Form1 : Form
    {
        
       
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        

       





        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SeriesCollection series = new SeriesCollection();
            
            ChartValues<int> priceValues = new ChartValues<int>();

            List<string> name_products = new List<string>();

            foreach (var priceRow in database1DataSet3.Product_tbl)
            {
                priceValues.Add(priceRow.price_products);

                name_products.Add(priceRow.name_products.ToString());
            }

            cartesianChart1.AxisX.Clear();

            cartesianChart1.AxisX.Add(new Axis()
            {
                Title = "названия продуктов",
                Labels = name_products
            });

            LineSeries priceLine = new LineSeries();

            priceLine.Title = "цена";
            priceLine.Values = priceValues;

            series.Add(priceLine);

            cartesianChart1.Series = series;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3.Product_tbl". При необходимости она может быть перемещена или удалена.
            this.product_tblTableAdapter1.Fill(this.database1DataSet3.Product_tbl);
          
           cartesianChart1.LegendLocation = LegendLocation.Bottom;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
