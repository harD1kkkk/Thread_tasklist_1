using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp_Task_6_7
{
    public partial class Form2 : Form
    {
        private Calculation calculation = new Calculation();
        private List<int> list = new List<int>();
        private int maxNum = 0;
        private int minNum = 0;
        private double averageNum = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            maxNum = 0;
            minNum = Int32.MaxValue;
            averageNum = 0;
            calculation.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            list.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
            int count = Int32.Parse(textBox1.Text);
            Task7(count);
        }

        public void Task7(int count)
        {
            list = calculation.generateNums(count);
            listBox1.Items.Add("All numbers:");
            foreach (int item in list)
            {
                listBox1.Items.Add(item);
            }

            maxNum = calculation.maxNumber();
            minNum = calculation.minNumber();
            averageNum = calculation.averageNumber();


            listBox2.Items.Add("Max number: " + maxNum);
            listBox2.Items.Add("Min number: " + minNum);
            listBox2.Items.Add("Average number: " + averageNum);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
