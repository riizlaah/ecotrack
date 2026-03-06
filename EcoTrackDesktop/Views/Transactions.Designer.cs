namespace EcoTrackDesktop.Views
{
    partial class Transactions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.table1 = new System.Windows.Forms.DataGridView();
            this.search = new System.Windows.Forms.TextBox();
            this.todayOpt = new System.Windows.Forms.RadioButton();
            this.dateRangeOpt = new System.Windows.Forms.RadioButton();
            this.dateRangeInput = new System.Windows.Forms.Panel();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            this.dateRangeInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transactions";
            // 
            // table1
            // 
            this.table1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.table1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table1.Location = new System.Drawing.Point(3, 38);
            this.table1.Name = "table1";
            this.table1.RowHeadersWidth = 51;
            this.table1.RowTemplate.Height = 24;
            this.table1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table1.Size = new System.Drawing.Size(1055, 301);
            this.table1.TabIndex = 1;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(830, 10);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(222, 22);
            this.search.TabIndex = 8;
            this.search.TextChanged += new System.EventHandler(this.onTrySearch);
            // 
            // todayOpt
            // 
            this.todayOpt.AutoSize = true;
            this.todayOpt.Checked = true;
            this.todayOpt.Location = new System.Drawing.Point(8, 346);
            this.todayOpt.Name = "todayOpt";
            this.todayOpt.Size = new System.Drawing.Size(68, 20);
            this.todayOpt.TabIndex = 9;
            this.todayOpt.TabStop = true;
            this.todayOpt.Text = "Today";
            this.todayOpt.UseVisualStyleBackColor = true;
            this.todayOpt.CheckedChanged += new System.EventHandler(this.onTodayCheckedChanged);
            // 
            // dateRangeOpt
            // 
            this.dateRangeOpt.AutoSize = true;
            this.dateRangeOpt.Location = new System.Drawing.Point(8, 384);
            this.dateRangeOpt.Name = "dateRangeOpt";
            this.dateRangeOpt.Size = new System.Drawing.Size(101, 20);
            this.dateRangeOpt.TabIndex = 10;
            this.dateRangeOpt.Text = "Date Range";
            this.dateRangeOpt.UseVisualStyleBackColor = true;
            this.dateRangeOpt.CheckedChanged += new System.EventHandler(this.onDateRangeCheckedChanged);
            // 
            // dateRangeInput
            // 
            this.dateRangeInput.Controls.Add(this.label2);
            this.dateRangeInput.Controls.Add(this.endDate);
            this.dateRangeInput.Controls.Add(this.startDate);
            this.dateRangeInput.Location = new System.Drawing.Point(30, 410);
            this.dateRangeInput.Name = "dateRangeInput";
            this.dateRangeInput.Size = new System.Drawing.Size(468, 32);
            this.dateRangeInput.TabIndex = 11;
            this.dateRangeInput.Visible = false;
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(4, 4);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(200, 22);
            this.startDate.TabIndex = 0;
            this.startDate.ValueChanged += new System.EventHandler(this.onStartDateChanged);
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(239, 4);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(200, 22);
            this.endDate.TabIndex = 1;
            this.endDate.ValueChanged += new System.EventHandler(this.onEndDateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(210, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "to";
            // 
            // Transactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateRangeInput);
            this.Controls.Add(this.dateRangeOpt);
            this.Controls.Add(this.todayOpt);
            this.Controls.Add(this.search);
            this.Controls.Add(this.table1);
            this.Controls.Add(this.label1);
            this.Name = "Transactions";
            this.Size = new System.Drawing.Size(1062, 562);
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            this.dateRangeInput.ResumeLayout(false);
            this.dateRangeInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView table1;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.RadioButton todayOpt;
        private System.Windows.Forms.RadioButton dateRangeOpt;
        private System.Windows.Forms.Panel dateRangeInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DateTimePicker startDate;
    }
}
