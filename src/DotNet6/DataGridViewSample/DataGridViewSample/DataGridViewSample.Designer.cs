namespace DataGridViewSample
{
    partial class DataGridViewSample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSample = new System.Windows.Forms.DataGridView();
            this.社員番号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.社員名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.編集 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.削除 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRowFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSample)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSample
            // 
            this.dgvSample.AllowUserToAddRows = false;
            this.dgvSample.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSample.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSample.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSample.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.社員番号,
            this.社員名,
            this.編集,
            this.削除});
            this.dgvSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSample.Location = new System.Drawing.Point(0, 45);
            this.dgvSample.Name = "dgvSample";
            this.dgvSample.ReadOnly = true;
            this.dgvSample.RowHeadersWidth = 20;
            this.dgvSample.RowTemplate.Height = 29;
            this.dgvSample.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSample.Size = new System.Drawing.Size(800, 405);
            this.dgvSample.TabIndex = 0;
            this.dgvSample.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSample_CellContentClick);
            // 
            // 社員番号
            // 
            this.社員番号.DataPropertyName = "社員番号";
            this.社員番号.HeaderText = "社員番号";
            this.社員番号.MinimumWidth = 6;
            this.社員番号.Name = "社員番号";
            this.社員番号.ReadOnly = true;
            this.社員番号.Width = 125;
            // 
            // 社員名
            // 
            this.社員名.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.社員名.DataPropertyName = "氏名";
            this.社員名.HeaderText = "社員名";
            this.社員名.MinimumWidth = 6;
            this.社員名.Name = "社員名";
            this.社員名.ReadOnly = true;
            // 
            // 編集
            // 
            this.編集.HeaderText = "";
            this.編集.MinimumWidth = 6;
            this.編集.Name = "編集";
            this.編集.ReadOnly = true;
            this.編集.Text = "編集";
            this.編集.UseColumnTextForButtonValue = true;
            this.編集.Width = 50;
            // 
            // 削除
            // 
            this.削除.HeaderText = "";
            this.削除.MinimumWidth = 6;
            this.削除.Name = "削除";
            this.削除.ReadOnly = true;
            this.削除.Text = "削除";
            this.削除.UseColumnTextForButtonValue = true;
            this.削除.Width = 50;
            // 
            // btnRowFilter
            // 
            this.btnRowFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRowFilter.Location = new System.Drawing.Point(0, 0);
            this.btnRowFilter.Name = "btnRowFilter";
            this.btnRowFilter.Size = new System.Drawing.Size(800, 45);
            this.btnRowFilter.TabIndex = 1;
            this.btnRowFilter.Text = "RowFilter";
            this.btnRowFilter.UseVisualStyleBackColor = true;
            this.btnRowFilter.Click += new System.EventHandler(this.btnRowFilter_Click);
            // 
            // DataGridViewSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvSample);
            this.Controls.Add(this.btnRowFilter);
            this.Name = "DataGridViewSample";
            this.Text = "DataGridViewSample";
            this.Load += new System.EventHandler(this.DataGridViewSample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSample)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvSample;
        private DataGridViewTextBoxColumn 社員番号;
        private DataGridViewTextBoxColumn 社員名;
        private DataGridViewButtonColumn 編集;
        private DataGridViewButtonColumn 削除;
        private Button btnRowFilter;
    }
}