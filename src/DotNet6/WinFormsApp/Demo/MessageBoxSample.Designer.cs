namespace Demo
{
    partial class MessageBoxSample
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
            this.btnMessageBox = new System.Windows.Forms.Button();
            this.btnDialogResult = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMessageBox
            // 
            this.btnMessageBox.Location = new System.Drawing.Point(135, 58);
            this.btnMessageBox.Name = "btnMessageBox";
            this.btnMessageBox.Size = new System.Drawing.Size(258, 102);
            this.btnMessageBox.TabIndex = 0;
            this.btnMessageBox.Text = "MessageBox";
            this.btnMessageBox.UseVisualStyleBackColor = true;
            this.btnMessageBox.Click += new System.EventHandler(this.btnMessageBox_Click);
            // 
            // btnDialogResult
            // 
            this.btnDialogResult.Location = new System.Drawing.Point(135, 193);
            this.btnDialogResult.Name = "btnDialogResult";
            this.btnDialogResult.Size = new System.Drawing.Size(258, 102);
            this.btnDialogResult.TabIndex = 1;
            this.btnDialogResult.Text = "DialogResult";
            this.btnDialogResult.UseVisualStyleBackColor = true;
            this.btnDialogResult.Click += new System.EventHandler(this.btnDialogResult_Click);
            // 
            // MessageBoxSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 371);
            this.Controls.Add(this.btnDialogResult);
            this.Controls.Add(this.btnMessageBox);
            this.Name = "MessageBoxSample";
            this.Text = "MessageBoxSample";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnMessageBox;
        private Button btnDialogResult;
    }
}