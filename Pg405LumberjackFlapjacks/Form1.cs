using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pg405LumberjackFlapjacks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Queue<Lumberjack> breakfastLine = new Queue<Lumberjack>();

        private void addLumberjack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(name.Text))
            {
                breakfastLine.Enqueue(new Lumberjack(name.Text));
                name.Text = "";
                line.Items.Clear();
                RedrawList();
            }
        }

        private void RedrawList()
        {
            line.Items.Clear();
            int index = 1;
            foreach (Lumberjack lumberjack in breakfastLine)
            {
                line.Items.Add($"{index}. {lumberjack.Name}");
                index++;
            }

            if (breakfastLine.Count == 0)
            {
                groupBox1.Enabled = false;
                nextInLine.Text = "";
            }
            else
            {
                groupBox1.Enabled = true;
                Lumberjack currentLumberjack = breakfastLine.Peek();
                nextInLine.Text = $"{currentLumberjack.Name} has {currentLumberjack.FlapjackCount} flapjacks.";
            }
        }

        private void addFlapjacks_Click(object sender, EventArgs e)
        {
            if (breakfastLine.Count == 0)
            {
                return;
            }
            Flapjack food;
            if (crispy.Checked)
            {
                food = Flapjack.Crispy;
            }
            else if (soggy.Checked)
            {
                food = Flapjack.Soggy;
            }
            else if (browned.Checked)
            {
                food = Flapjack.Browned;
            }
            else
            {
                food = Flapjack.Banana;
            }
            Lumberjack currentLumberjack = breakfastLine.Peek();
            currentLumberjack.TakeFlapjacks(food, (int)howMany.Value);
            RedrawList();
        }

        private void next_Click(object sender, EventArgs e)
        {
            Lumberjack currentLumberjack;
            currentLumberjack = breakfastLine.Dequeue();
            currentLumberjack.EatFlapjacks();
            RedrawList();
        }
    }
}