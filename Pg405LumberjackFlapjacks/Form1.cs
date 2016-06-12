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

        Queue<string> queue = new Queue<string>();

        private void addLumberjack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(name.Text))
            {
                queue.Enqueue(name.Text);
                name.Text = "";
                line.Items.Clear();
                foreach (string name in queue)
                {
                    line.Items.Add(name);
                }
            }
        }
    }
}