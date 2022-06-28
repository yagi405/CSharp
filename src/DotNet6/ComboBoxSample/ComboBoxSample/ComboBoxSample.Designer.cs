namespace ComboBoxSample
{
    partial class ComboBoxSample
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
            this.cboSample = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboSample
            // 
            this.cboSample.FormattingEnabled = true;
            this.cboSample.Location = new System.Drawing.Point(99, 52);
            this.cboSample.Name = "cboSample";
            this.cboSample.Size = new System.Drawing.Size(460, 28);
            this.cboSample.TabIndex = 0;
            this.cboSample.SelectedIndexChanged += new System.EventHandler(this.cboSample_SelectedIndexChanged);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(99, 110);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(201, 60);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "コンボボックスへのアクセス";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // ComboBoxSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 217);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.cboSample);
            this.Name = "ComboBoxSample";
            this.Text = "ComboBoxSample";
            this.Load += new System.EventHandler(this.ComboBoxSample_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cboSample;
        private Button btnTest;
    }
}