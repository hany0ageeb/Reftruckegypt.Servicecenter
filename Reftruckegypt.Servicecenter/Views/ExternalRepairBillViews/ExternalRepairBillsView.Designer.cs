
namespace Reftruckegypt.Servicecenter.Views.ExternalRepairBillViews
{
    partial class ExternalRepairBillsView
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbillNumberTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbillNumberFrom = new System.Windows.Forms.TextBox();
            this.pickbillDateFrom = new System.Windows.Forms.DateTimePicker();
            this.pickbillDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbillAmountTo = new System.Windows.Forms.TextBox();
            this.txtbillAmountFrom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbovehicles = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboshops = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gridbills = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridbills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.46911F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.53089F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 307F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtbillNumberTo, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtbillNumberFrom, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pickbillDateFrom, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pickbillDateTo, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtbillAmountTo, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtbillAmountFrom, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbovehicles, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboshops, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 4, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(941, 136);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Vehicle";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(465, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 34);
            this.label4.TabIndex = 7;
            this.label4.Text = "--";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bill Date";
            // 
            // txtbillNumberTo
            // 
            this.txtbillNumberTo.Location = new System.Drawing.Point(550, 3);
            this.txtbillNumberTo.Name = "txtbillNumberTo";
            this.txtbillNumberTo.Size = new System.Drawing.Size(301, 23);
            this.txtbillNumberTo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bill Number";
            // 
            // txtbillNumberFrom
            // 
            this.txtbillNumberFrom.Location = new System.Drawing.Point(167, 3);
            this.txtbillNumberFrom.Name = "txtbillNumberFrom";
            this.txtbillNumberFrom.Size = new System.Drawing.Size(269, 23);
            this.txtbillNumberFrom.TabIndex = 1;
            // 
            // pickbillDateFrom
            // 
            this.pickbillDateFrom.Checked = false;
            this.pickbillDateFrom.Location = new System.Drawing.Point(167, 37);
            this.pickbillDateFrom.Name = "pickbillDateFrom";
            this.pickbillDateFrom.ShowCheckBox = true;
            this.pickbillDateFrom.Size = new System.Drawing.Size(269, 23);
            this.pickbillDateFrom.TabIndex = 3;
            // 
            // pickbillDateTo
            // 
            this.pickbillDateTo.Checked = false;
            this.pickbillDateTo.Location = new System.Drawing.Point(550, 37);
            this.pickbillDateTo.Name = "pickbillDateTo";
            this.pickbillDateTo.ShowCheckBox = true;
            this.pickbillDateTo.Size = new System.Drawing.Size(301, 23);
            this.pickbillDateTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(465, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 34);
            this.label2.TabIndex = 2;
            this.label2.Text = "--";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtbillAmountTo
            // 
            this.txtbillAmountTo.Location = new System.Drawing.Point(550, 71);
            this.txtbillAmountTo.Name = "txtbillAmountTo";
            this.txtbillAmountTo.Size = new System.Drawing.Size(301, 23);
            this.txtbillAmountTo.TabIndex = 6;
            // 
            // txtbillAmountFrom
            // 
            this.txtbillAmountFrom.Location = new System.Drawing.Point(167, 71);
            this.txtbillAmountFrom.Name = "txtbillAmountFrom";
            this.txtbillAmountFrom.Size = new System.Drawing.Size(269, 23);
            this.txtbillAmountFrom.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(465, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 34);
            this.label6.TabIndex = 11;
            this.label6.Text = "--";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Bill Total Amount (EGP)";
            // 
            // cbovehicles
            // 
            this.cbovehicles.FormattingEnabled = true;
            this.cbovehicles.Location = new System.Drawing.Point(167, 105);
            this.cbovehicles.Name = "cbovehicles";
            this.cbovehicles.Size = new System.Drawing.Size(269, 23);
            this.cbovehicles.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(465, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Repair Shop";
            // 
            // cboshops
            // 
            this.cboshops.FormattingEnabled = true;
            this.cboshops.Location = new System.Drawing.Point(550, 105);
            this.cboshops.Name = "cboshops";
            this.cboshops.Size = new System.Drawing.Size(301, 23);
            this.cboshops.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(857, 105);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // gridbills
            // 
            this.gridbills.AllowUserToAddRows = false;
            this.gridbills.AllowUserToDeleteRows = false;
            this.gridbills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridbills.Location = new System.Drawing.Point(12, 156);
            this.gridbills.Name = "gridbills";
            this.gridbills.ReadOnly = true;
            this.gridbills.Size = new System.Drawing.Size(941, 431);
            this.gridbills.TabIndex = 10;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(857, 609);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 30);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(233, 609);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 30);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(122, 609);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(96, 30);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "Edit ...";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(13, 609);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(96, 30);
            this.btnCreate.TabIndex = 12;
            this.btnCreate.Text = "Create ..";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // ExternalRepairBillsView
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 651);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.gridbills);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ExternalRepairBillsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "External Vehicle Repair Bills";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridbills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbillNumberFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbillNumberTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker pickbillDateFrom;
        private System.Windows.Forms.DateTimePicker pickbillDateTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbillAmountFrom;
        private System.Windows.Forms.TextBox txtbillAmountTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbovehicles;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboshops;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView gridbills;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCreate;
    }
}