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
    public partial class FIleDialogSample : Form
    {
        public FIleDialogSample()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "テキストファイル(*.txt)|*.txt|すべてのファイル（*.*）|*.*";
                dialog.DefaultExt = "txt";

                var dialogResult = dialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    txtFilePath.Text = dialog.FileName;
                }
            }
        }
    }
}
