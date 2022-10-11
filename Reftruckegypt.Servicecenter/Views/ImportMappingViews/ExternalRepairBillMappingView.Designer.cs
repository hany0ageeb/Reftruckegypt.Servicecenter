
namespace Reftruckegypt.Servicecenter.Views.ImportMappingViews
{
    partial class ExternalRepairBillMappingView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.cboReadingDate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboInternalCodes = new System.Windows.Forms.ComboBox();
            this.cboAmount = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboRepairs = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSupplierInvoiceNum = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboExternalRepaiShops = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.61863F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.38137F));
            this.tableLayoutPanel1.Controls.Add(this.cboExternalRepaiShops, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboInternalCodes, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cboSupplierInvoiceNum, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cboRepairs, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboAmount, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboReadingDate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(687, 195);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total Invoice Amount*";
            // 
            // cboReadingDate
            // 
            this.cboReadingDate.FormattingEnabled = true;
            this.cboReadingDate.Location = new System.Drawing.Point(178, 67);
            this.cboReadingDate.Name = "cboReadingDate";
            this.cboReadingDate.Size = new System.Drawing.Size(441, 23);
            this.cboReadingDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Invoice Date*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vehicle Internal Code*";
            // 
            // cboInternalCodes
            // 
            this.cboInternalCodes.FormattingEnabled = true;
            this.cboInternalCodes.Location = new System.Drawing.Point(178, 3);
            this.cboInternalCodes.Name = "cboInternalCodes";
            this.cboInternalCodes.Size = new System.Drawing.Size(441, 23);
            this.cboInternalCodes.TabIndex = 1;
            // 
            // cboAmount
            // 
            this.cboAmount.FormattingEnabled = true;
            this.cboAmount.Location = new System.Drawing.Point(178, 99);
            this.cboAmount.Name = "cboAmount";
            this.cboAmount.Size = new System.Drawing.Size(441, 23);
            this.cboAmount.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Repairs";
            // 
            // cboRepairs
            // 
            this.cboRepairs.FormattingEnabled = true;
            this.cboRepairs.Location = new System.Drawing.Point(178, 131);
            this.cboRepairs.Name = "cboRepairs";
            this.cboRepairs.Size = new System.Drawing.Size(441, 23);
            this.cboRepairs.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(623, 237);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 27);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(538, 237);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(79, 27);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Supplier Invoice Number";
            // 
            // cboSupplierInvoiceNum
            // 
            this.cboSupplierInvoiceNum.FormattingEnabled = true;
            this.cboSupplierInvoiceNum.Location = new System.Drawing.Point(178, 162);
            this.cboSupplierInvoiceNum.Name = "cboSupplierInvoiceNum";
            this.cboSupplierInvoiceNum.Size = new System.Drawing.Size(441, 23);
            this.cboSupplierInvoiceNum.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "External Repair Shop*";
            // 
            // cboExternalRepaiShops
            // 
            this.cboExternalRepaiShops.FormattingEnabled = true;
            this.cboExternalRepaiShops.Location = new System.Drawing.Point(178, 35);
            this.cboExternalRepaiShops.Name = "cboExternalRepaiShops";
            this.cboExternalRepaiShops.Size = new System.Drawing.Size(441, 23);
            this.cboExternalRepaiShops.TabIndex = 17;
            // 
            // ExternalRepairBillMappingView
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(714, 276);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExternalRepairBillMappingView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "External Repair Invoice Mapping";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboReadingDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboInternalCodes;
        private System.Windows.Forms.ComboBox cboAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboRepairs;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSupplierInvoiceNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboExternalRepaiShops;
    }
}