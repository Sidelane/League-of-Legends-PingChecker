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

        public int Sum(params int[] num) {
            int result = 0;

            for (int i = 0; i < num.Length; i++) {
                result += num[i];
            }

            return result;
        }

        public decimal Average(params int[] num) {
            int sum = Sum(num);
            decimal result = (decimal)sum / num.Length;
            return result;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            chart1.Series[0].Points.Clear();

            string[] server_ip_adresses = new string[] {
                "104.160.141.3",
                "104.160.142.3",
                "104.160.131.3",
                "104.160.156.1",
                "104.160.136.3"
            };

            string activeIp = "";
            int repetitions = Convert.ToInt32(numericUpDown1.Value);
            string lbValue = listBox1.GetItemText(listBox1.SelectedItem);
            int[] pingResults = new int[repetitions + 1];

            progressBar1.Maximum = repetitions;

            switch (lbValue) {
                case "EUW":
                    activeIp = server_ip_adresses[0];
                    label3.Text = "Selected IP: 104.160.141.3";
                    break;
                case "EUNE":
                    activeIp = server_ip_adresses[1];
                    label3.Text = "Selected IP: 104.160.142.3";
                    break;
                case "NA":
                    activeIp = server_ip_adresses[2];
                    label3.Text = "Selected IP: 104.160.131.3";
                    break;
                case "OCE":
                    activeIp = server_ip_adresses[3];
                    label3.Text = "Selected IP: 104.160.156.1";
                    break;
                case "LAN":
                    activeIp = server_ip_adresses[4];
                    label3.Text = "Selected IP: 104.160.136.3";
                    break;
                //default:
                    //MessageBox.Show("No valid Server chosen");
                    //break;
            }

            try {
                for (int i = 0; i <= repetitions; i++) {

                    progressBar1.Value = i;

                    using (Ping p = new Ping()) {
                        string ms = p.Send(activeIp, 1000).RoundtripTime.ToString();
                        chart1.Series[0].Points.AddXY(ms, ms);
                        pingResults[i] = Convert.ToInt32(ms);
                    }
                }
            } catch (Exception) {
                MessageBox.Show("Please Select a Server");
            }


            decimal avgPing = Average(pingResults);
            avgPing = Convert.ToInt32(avgPing);

            label4.Text = ("Average Ping: " + Convert.ToString(avgPing));

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
