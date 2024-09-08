using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSProject
{
    public partial class RoundRobin : Form
    {
        public RoundRobin()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {}

        private void RoundRobin_Load(object sender, EventArgs e)
        {}

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            String[] name = { "p1", "p2", "p3", "p4", "p5" };

            int QT = Convert.ToInt32(QTtb.Text);

            int[] arrivaltime = new int[5];
            int[] bursttime = new int[5];

            arrivaltime[0] = Convert.ToInt32(ATp1.Text);
            arrivaltime[1] = Convert.ToInt32(ATp2.Text);
            arrivaltime[2] = Convert.ToInt32(ATp3.Text);
            arrivaltime[3] = Convert.ToInt32(ATp4.Text);
            arrivaltime[4] = Convert.ToInt32(ATp5.Text);

            bursttime[0] = Convert.ToInt32(BTp1.Text);
            bursttime[1] = Convert.ToInt32(BTp2.Text);
            bursttime[2] = Convert.ToInt32(BTp3.Text);
            bursttime[3] = Convert.ToInt32(BTp4.Text);
            bursttime[4] = Convert.ToInt32(BTp5.Text);

            roundRobin(name, arrivaltime, bursttime, QT);

            void roundRobin(String[] p, int[] a, int[] b, int n)
            {
                int AvgWT = 0;
                int AvgTAT = 0;
                
                String seq = "";

                int[] res_b = new int[b.Length];
                int[] res_a = new int[a.Length];

                for (int i = 0; i < res_b.Length; i++)
                {
                    res_b[i] = b[i];
                    res_a[i] = a[i];
                }


                int t = 0;

                int[] WT = new int[p.Length];

                int[] TAT = new int[p.Length];

                while (true)
                {
                    Boolean flag = true;
                    for (int i = 0; i < p.Length; i++)
                    {

                        if (res_a[i] <= t)
                        {
                            if (res_a[i] <= n)
                            {
                                if (res_b[i] > 0)
                                {
                                    flag = false;
                                    if (res_b[i] > n)
                                    {

                                        t = t + n;
                                        res_b[i] = res_b[i] - n;
                                        res_a[i] = res_a[i] + n;
                                        seq += "->" + p[i];
                                    }
                                    else
                                    {

                                        t = t + res_b[i];

                                        TAT[i] = t - a[i];

                                        WT[i] = t - b[i] - a[i];

                                        res_b[i] = 0;

                                        seq += "->" + p[i];
                                    }
                                }
                            }
                            else if (res_a[i] > n)
                            {

                                for (int j = 0; j < p.Length; j++)
                                {

                                    if (res_a[j] < res_a[i])
                                    {
                                        if (res_b[j] > 0)
                                        {
                                            flag = false;
                                            if (res_b[j] > n)
                                            {
                                                t = t + n;
                                                res_b[j] = res_b[j] - n;
                                                res_a[j] = res_a[j] + n;
                                                seq += "->" + p[j];
                                            }
                                            else
                                            {
                                                t = t + res_b[j];
                                                TAT[j] = t - a[j];
                                                WT[j] = t - b[j]- a[j];
                                                res_b[j] = 0;
                                                seq += "->" + p[j];
                                            }
                                        }
                                    }
                                }


                                if (res_b[i] > 0)
                                {
                                    flag = false;

                                    if (res_b[i] > n)
                                    {
                                        t = t + n;
                                        res_b[i] = res_b[i] - n;
                                        res_a[i] = res_a[i] + n;
                                        seq += "->" + p[i];
                                    }
                                    else
                                    {
                                        t = t + res_b[i];
                                        TAT[i] = t - a[i];
                                        WT[i] = t - b[i] - a[i];
                                        res_b[i] = 0;
                                        seq += "->" + p[i];
                                    }
                                }
                            }
                        }

                        else if (res_a[i] > t)
                        {
                            t++;
                            i--;
                        }
                    }

                    
                    if (flag)
                    {
                        break;
                    }
                }

                for (int i = 0; i < p.Length; i++)
                {
                    AvgWT = AvgWT + WT[i];
                    AvgTAT = AvgTAT + TAT[i];
                }


                TATp1.Text = Convert.ToString(TAT[0]);
                TATp2.Text = Convert.ToString(TAT[1]);
                TATp3.Text = Convert.ToString(TAT[2]);
                TATp4.Text = Convert.ToString(TAT[3]);
                TATp5.Text = Convert.ToString(TAT[4]);

                WTp1.Text = Convert.ToString(WT[0]);
                WTp2.Text = Convert.ToString(WT[1]);
                WTp3.Text = Convert.ToString(WT[2]);
                WTp4.Text = Convert.ToString(WT[3]);
                WTp5.Text = Convert.ToString(WT[4]);

                Sequencetb.Text = seq;

                TATavg.Text = Convert.ToString((float)AvgTAT/5);
                WTavg.Text = Convert.ToString((float)AvgWT/5);

            }            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 Obj = new Form2();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void ATp1_TextChanged(object sender, EventArgs e)
        {}

    }
}