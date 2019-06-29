using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Chart-test
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            chart1.Series[0].Points.Clear();

            string[] server_ip_adresses = new string[] {
                "104.160.141.3",
                "104.160.142.3",
                "104.160.131.3"
            };

            string activeIp;
            int repetitions = Convert.ToInt32(numericUpDown1.Value);
            string lbValue = listBox1.GetItemText(listBox1.SelectedItem);

            progressBar1.Maximum = repetitions;

            if (lbValue == "EUW") {

                activeIp = server_ip_adresses[0];
                label3.Text = "Selected IP: 104.160.141.3";

                for (int i = 0; i <= repetitions; i++) {

                    progressBar1.Value = i;

                    using (Ping p = new Ping())
                    {
                        string ms = p.Send(activeIp, 1000).RoundtripTime.ToString();
                        chart1.Series[0].Points.AddXY(ms, ms);
                    }
                }

            } else if (lbValue == "EUNE") {

                activeIp = server_ip_adresses[1];
                label3.Text = "Selected IP: 104.160.142.3";

                for (int i = 0; i <= repetitions; i++) {
                    progressBar1.Value = i;
                    using (Ping p = new Ping()) {
                        string ms = p.Send(activeIp, 1000).RoundtripTime.ToString();
                        chart1.Series[0].Points.AddXY(ms, ms);
                    }
                }

            } else if (lbValue == "NA") {

                activeIp = server_ip_adresses[2];
                label3.Text = "Selected IP: 104.160.131.3";

                for (int i = 0; i <= repetitions; i++) {
                    progressBar1.Value = i;
                    using (Ping p = new Ping()) {
                        string ms = p.Send(activeIp, 1000).RoundtripTime.ToString();
                        chart1.Series[0].Points.AddXY(ms, ms);
                    }
                }

            } else {
                MessageBox.Show("Error selecting the IP of the Region");
            }

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
