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
    public partial class MessageBoxSample : Form
    {
        public MessageBoxSample()
        {
            InitializeComponent();
        }

        private void btnMessageBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
            MessageBox.Show("Hello World", "caption");

            MessageBox.Show("Hello World", "caption", MessageBoxButtons.YesNo);
            MessageBox.Show("Hello World", "caption", MessageBoxButtons.YesNoCancel);
            MessageBox.Show("Hello World", "caption", MessageBoxButtons.OKCancel);

            MessageBox.Show("Test", "caption", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            MessageBox.Show("Test", "caption", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            MessageBox.Show("Test", "caption", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

        }

        private void btnDialogResult_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("本当に実行しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (dialogResult)
            {
                case DialogResult.Yes:
                    MessageBox.Show("Yesが選択されました。");
                    break;
                case DialogResult.No:
                    MessageBox.Show("Noが選択されました。");
                    break;
            }
        }
    }
}
