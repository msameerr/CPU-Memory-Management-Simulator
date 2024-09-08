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
    public partial class BestFit : Form
    {
        public BestFit()
        {
            InitializeComponent();
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

        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            int[] blockSize = new int[5];
            int[] processSize = new int[5];
            int m = blockSize.Length;
            int n = processSize.Length;

            blockSize[0] = Convert.ToInt32(MB1.Text);
            blockSize[1] = Convert.ToInt32(MB2.Text);
            blockSize[2] = Convert.ToInt32(MB3.Text);
            blockSize[3] = Convert.ToInt32(MB4.Text);
            blockSize[4] = Convert.ToInt32(MB5.Text);

            processSize[0] = Convert.ToInt32(P1.Text);
            processSize[1] = Convert.ToInt32(P2.Text);
            processSize[2] = Convert.ToInt32(P3.Text);
            processSize[3] = Convert.ToInt32(P4.Text);
            processSize[4] = Convert.ToInt32(P5.Text);

            bestFit(blockSize, m, processSize, n);

			void bestFit(int[] BlockSize, int blockLen, int[] ProcessSize, int processLen) 
			{

				int[] allocation = new int[processLen];


				for (int i = 0; i < allocation.Length; i++)
						allocation[i] = -1;


				for (int i = 0; i < processLen; i++)
				{


					int bestIdx = -1;
					for (int j = 0; j < blockLen; j++)
					{
						if (ProcessSize[i] == 0)
							allocation[i] = -1;

						else if (BlockSize[j] >= ProcessSize[i])
						{
							if (bestIdx == -1)
								bestIdx = j;
							else if (BlockSize[bestIdx] > BlockSize[j])
								bestIdx = j;
						}

					}
					
					if (bestIdx != -1)
					{

						allocation[i] = bestIdx;

						BlockSize[bestIdx] -= ProcessSize[i];
					}

				}


				for (int i = 0; i < processLen; i++)
				{

					if (allocation[i] != -1)
						allocation[i] = allocation[i] + 1;
					else
						allocation[i] = -1;

				}

				ABp1.Text = Convert.ToString(allocation[0]);
				ABp2.Text = Convert.ToString(allocation[1]);
				ABp3.Text = Convert.ToString(allocation[2]);
				ABp4.Text = Convert.ToString(allocation[3]);
				ABp5.Text = Convert.ToString(allocation[4]);

            }
		}

        private void BestFit_Load(object sender, EventArgs e)
        {}
    }
}