namespace EcoTrackDesktop.Views
{
    partial class SellRecyclables
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
            this.insert = new System.Windows.Forms.Button();
            this.weight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.phoneNum = new System.Windows.Forms.TextBox();
            this.categories = new System.Windows.Forms.ComboBox();
            this.addNew = new System.Windows.Forms.Button();
            this.extraInfo = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.previewPrice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sell Recyclables";
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(22, 234);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(129, 24);
            this.insert.TabIndex = 2;
            this.insert.Text = "Sell";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.onTrySell);
            // 
            // weight
            // 
            this.weight.Location = new System.Drawing.Point(131, 45);
            this.weight.Name = "weight";
            this.weight.Size = new System.Drawing.Size(187, 22);
            this.weight.TabIndex = 10;
            this.weight.TextChanged += new System.EventHandler(this.onWeightChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Weight";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Phone Number";
            // 
            // phoneNum
            // 
            this.phoneNum.Location = new System.Drawing.Point(131, 117);
            this.phoneNum.Name = "phoneNum";
            this.phoneNum.Size = new System.Drawing.Size(187, 22);
            this.phoneNum.TabIndex = 18;
            this.phoneNum.TextChanged += new System.EventHandler(this.onPhoneNumberChanged);
            this.phoneNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.onPhoneNumKeyUp);
            // 
            // categories
            // 
            this.categories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categories.FormattingEnabled = true;
            this.categories.Location = new System.Drawing.Point(131, 78);
            this.categories.Name = "categories";
            this.categories.Size = new System.Drawing.Size(187, 24);
            this.categories.TabIndex = 20;
            this.categories.SelectedValueChanged += new System.EventHandler(this.onCategoryChanged);
            // 
            // addNew
            // 
            this.addNew.Location = new System.Drawing.Point(324, 117);
            this.addNew.Name = "addNew";
            this.addNew.Size = new System.Drawing.Size(149, 23);
            this.addNew.TabIndex = 22;
            this.addNew.Text = "Add New Customer";
            this.addNew.UseVisualStyleBackColor = true;
            this.addNew.Click += new System.EventHandler(this.onAddNewCust);
            // 
            // extraInfo
            // 
            this.extraInfo.Location = new System.Drawing.Point(19, 151);
            this.extraInfo.Name = "extraInfo";
            this.extraInfo.Size = new System.Drawing.Size(343, 47);
            this.extraInfo.TabIndex = 23;
            this.extraInfo.Text = "No customer selected.";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(132, 138);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(185, 84);
            this.listBox1.TabIndex = 24;
            this.listBox1.Visible = false;
            this.listBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.onListBoxKeyUp);
            // 
            // previewPrice
            // 
            this.previewPrice.AutoSize = true;
            this.previewPrice.Location = new System.Drawing.Point(166, 238);
            this.previewPrice.Name = "previewPrice";
            this.previewPrice.Size = new System.Drawing.Size(0, 16);
            this.previewPrice.TabIndex = 25;
            // 
            // SellRecyclables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.previewPrice);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.extraInfo);
            this.Controls.Add(this.addNew);
            this.Controls.Add(this.categories);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.phoneNum);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.weight);
            this.Controls.Add(this.label1);
            this.Name = "SellRecyclables";
            this.Size = new System.Drawing.Size(1062, 562);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.TextBox weight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox phoneNum;
        private System.Windows.Forms.ComboBox categories;
        private System.Windows.Forms.Button addNew;
        private System.Windows.Forms.Label extraInfo;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label previewPrice;
    }
}
