using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp_Task_6_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int start = Int32.Parse(textBox1.Text);

            int end = Int32.Parse(textBox2.Text);
            int num = Int32.Parse(textBox3.Text);
            Task6(start, end, num);
        }

        public void Task6(int start,int end,int num)
        {
            Thread[] threads = new Thread[num];


            for (int j = 0; j < num; j++)
            {
                Thread thread = new Thread(() =>
                {
                    for (int i = start; i <= end; i++)
                    {
                        Invoke(new Action(() =>
                        {
                            listBox1.Items.Add(i);
                        }));
                    }
                });
                thread.Start();
                
            }

            
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
