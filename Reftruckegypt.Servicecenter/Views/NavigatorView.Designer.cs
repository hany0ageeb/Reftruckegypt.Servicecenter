
namespace Reftruckegypt.Servicecenter.Views
{
    partial class NavigatorView
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
            this.lstUserCommands = new System.Windows.Forms.ListBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstUserCommands
            // 
            this.lstUserCommands.FormattingEnabled = true;
            this.lstUserCommands.ItemHeight = 15;
            this.lstUserCommands.Location = new System.Drawing.Point(13, 13);
            this.lstUserCommands.Name = "lstUserCommands";
            this.lstUserCommands.Size = new System.Drawing.Size(444, 514);
            this.lstUserCommands.TabIndex = 0;
            this.lstUserCommands.DoubleClick += new System.EventHandler(this.lstUserCommands_DoubleClick);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(369, 545);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(88, 34);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // NavigatorView
            // 
            this.AcceptButton = this.btnOpen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 589);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lstUserCommands);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "NavigatorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Navigator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NavigatorView_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NavigatorView_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstUserCommands;
        private System.Windows.Forms.Button btnOpen;
    }
}