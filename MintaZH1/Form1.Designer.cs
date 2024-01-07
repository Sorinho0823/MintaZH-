
namespace ZH1_gyak
{
    partial class Form1
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
            this.comboBoxYears = new System.Windows.Forms.ComboBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxYears
            // 
            this.comboBoxYears.FormattingEnabled = true;
            this.comboBoxYears.Location = new System.Drawing.Point(71, 60);
            this.comboBoxYears.Name = "comboBoxYears";
            this.comboBoxYears.Size = new System.Drawing.Size(121, 24);
            this.comboBoxYears.TabIndex = 0;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(71, 153);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(121, 111);
            this.buttonExport.TabIndex = 1;
            this.buttonExport.Text = "button1";
            this.buttonExport.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 384);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.comboBoxYears);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxYears;
        private System.Windows.Forms.Button buttonExport;
    }
}

