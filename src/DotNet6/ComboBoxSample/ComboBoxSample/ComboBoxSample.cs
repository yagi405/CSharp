using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboBoxSample
{
    public partial class ComboBoxSample : Form
    {
        public ComboBoxSample()
        {
            InitializeComponent();
        }

        private void ComboBoxSample_Load(object sender, EventArgs e)
        {
            //コンボボックスは、デフォルトでは文字の直接入力もできます。
            //選択肢からの選択のみとする場合、下記のプロパティを変更します。
            cboSample.DropDownStyle = ComboBoxStyle.DropDownList;

            //コンボボックスの選択肢とするクラスのインスタンスを生成します。
            var itm1 = new SampleItem { SampleItemId = 10, SampleItemName = "選択肢1" };
            var itm2 = new SampleItem { SampleItemId = 20, SampleItemName = "選択肢2" };
            var itm3 = new SampleItem { SampleItemId = 30, SampleItemName = "選択肢3" };
            var itm4 = new SampleItem { SampleItemId = 40, SampleItemName = "選択肢4" };

            //生成したインスタンスをコンボボックスの選択肢として登録します。
            cboSample.Items.Add(itm1);
            cboSample.Items.Add(itm2);
            cboSample.Items.Add(itm3);
            cboSample.Items.Add(itm4);

            //コンボボックスの選択として表示するプロパティを設定します。
            cboSample.DisplayMember = "SampleItemName";

            //最初から、先頭の項目を選択した状態にしたい場合は、下記をコメントインします。
            //cboSample.SelectedIndex = 0;
        }

        private void cboSample_SelectedIndexChanged(object sender, EventArgs e)
        {
            //コンボボックスの選択状態が変わった時に処理をおこなうには、
            //SelectedIndexChanged イベントを使用します。

            //選択された内容を取得します。
            //SelectedItem は object型 なので SampleItem型(選択肢の型) にキャスト
            var selItm = (SampleItem)cboSample.SelectedItem;

            //選択された内容を表示します。
            MessageBox.Show(selItm.SampleItemId + " - " + selItm.SampleItemName,
                    "選択した内容", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //コンボボックスで選択がされていないことを調べる
            if (cboSample.SelectedIndex < 0)
            {
                /*
                SelectedIndexには、選択されている選択肢のIndexが格納されています。
                選択されていない場合は-1、先頭の項目が選択されている場合は0、
                2番目の項目が選択されている場合は1...といった仕様です。
                */
                MessageBox.Show("選択されていません。", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MessageBox.Show("選択肢の値 = " + ((SampleItem)cboSample.SelectedItem).SampleItemId,
                "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
