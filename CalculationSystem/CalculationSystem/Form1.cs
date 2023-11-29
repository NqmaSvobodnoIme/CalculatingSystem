using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculationSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] inputNumbers = textBox1.Text.Split(' ');

            List<double> numbers = new List<double>();
            foreach (string input in inputNumbers)
            {
                if (double.TryParse(input, out double number))
                {
                    numbers.Add(number);
                }
            }

            double moda = Mode(numbers);
            double Average = numbers.Average();
            mode.Text = $"Mode: {moda}";
            average.Text = $"Average: {Average}";
        }
        private double Mode(List<double> numbers)
        {
            var mode = numbers.GroupBy(x => x)
                 .OrderByDescending(x => x.Count()).ThenBy(x => x.Key)
                 .Select(x => (int)x.Key)
                 .FirstOrDefault();

            return mode;
        }
    }
}
