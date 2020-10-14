using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using Hatodikgyak.MnbServiceReference;

namespace Hatodikgyak
{
    public partial class Form1 : Form
    {
        BindingList<RateData> rates = new BindingList<RateData>();

        public Form1()
        {
            InitializeComponent();
            RefreshData();

            }
            void RefreshData()
            {
                rates.Clear();
            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-09-30"
            };

        
            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
           
            dataGridView1.DataSource = rates;
            var xml = new XmlDocument();
            xml.LoadXml(result);
            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new RateData();
                rates.Add(rate);

                rate.Date = DateTime.Parse(element.GetAttribute("date"));

                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childElement.GetAttribute("curr");

                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;


                chart1.DataSource = rates;

                var series = chart1.Series[0];
                series.ChartType = SeriesChartType.Line;
                series.XValueMember = "Date";
                series.YValueMembers = "Value";
                series.BorderWidth = 2;

                var legend = chart1.Legends[0];
                legend.Enabled = false;

                var chartArea = chart1.ChartAreas[0];
                chartArea.AxisX.MajorGrid.Enabled = false;
                chartArea.AxisY.MajorGrid.Enabled = false;
                chartArea.AxisY.IsStartedFromZero = false;



            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
