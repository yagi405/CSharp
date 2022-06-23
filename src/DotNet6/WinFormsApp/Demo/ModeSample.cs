using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class ModeSample : Form
    {
        public ModeSample()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var sub = new ModeSampleSub();
            sub.Show();
        }

        private void btnShowDialog_Click(object sender, EventArgs e)
        {
            var sub = new ModeSampleSub();
            sub.ShowDialog();
        }
    }
}
