namespace SmartWord
{
    partial class FormInfo
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
            this.buttonM = new System.Windows.Forms.Button();
            this.buttonO = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonM
            // 
            this.buttonM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.buttonM.Location = new System.Drawing.Point(0, 0);
            this.buttonM.Name = "buttonM";
            this.buttonM.Size = new System.Drawing.Size(150, 55);
            this.buttonM.TabIndex = 0;
            this.buttonM.Text = "The main functions";
            this.buttonM.UseVisualStyleBackColor = true;
            this.buttonM.Click += new System.EventHandler(this.buttonM_Click);
            // 
            // buttonO
            // 
            this.buttonO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.buttonO.Location = new System.Drawing.Point(150, 0);
            this.buttonO.Name = "buttonO";
            this.buttonO.Size = new System.Drawing.Size(149, 55);
            this.buttonO.TabIndex = 1;
            this.buttonO.Text = "Other functions";
            this.buttonO.UseVisualStyleBackColor = true;
            this.buttonO.Click += new System.EventHandler(this.buttonO_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel.Location = new System.Drawing.Point(0, 56);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(150, 5);
            this.panel.TabIndex = 2;
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 583);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.buttonO);
            this.Controls.Add(this.buttonM);
            this.MaximumSize = new System.Drawing.Size(316, 630);
            this.MinimumSize = new System.Drawing.Size(316, 630);
            this.Name = "FormInfo";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonM;
        private System.Windows.Forms.Button buttonO;
        private System.Windows.Forms.Panel panel;
    }
}