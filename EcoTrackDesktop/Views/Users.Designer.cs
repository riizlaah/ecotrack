namespace EcoTrackDesktop.Views
{
    partial class Users
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
            this.insert = new System.Windows.Forms.Button();
            this.roleFilters = new System.Windows.Forms.ComboBox();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.saveNCancel = new System.Windows.Forms.Panel();
            this.search = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordLb = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fullName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.roleLb = new System.Windows.Forms.Label();
            this.roles = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            this.actionPanel.SuspendLayout();
            this.saveNCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Role";
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
            this.table1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.onCellClicked);
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(813, 349);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(75, 23);
            this.insert.TabIndex = 2;
            this.insert.Text = "Insert";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.onInsertClicked);
            // 
            // roleFilters
            // 
            this.roleFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleFilters.FormattingEnabled = true;
            this.roleFilters.Location = new System.Drawing.Point(118, 8);
            this.roleFilters.Name = "roleFilters";
            this.roleFilters.Size = new System.Drawing.Size(121, 24);
            this.roleFilters.TabIndex = 3;
            this.roleFilters.SelectedValueChanged += new System.EventHandler(this.onFilterChanged);
            // 
            // actionPanel
            // 
            this.actionPanel.Controls.Add(this.button4);
            this.actionPanel.Controls.Add(this.button3);
            this.actionPanel.Location = new System.Drawing.Point(894, 345);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(164, 30);
            this.actionPanel.TabIndex = 4;
            this.actionPanel.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(84, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Delete";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.onDelete);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.onEdit);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.onSave);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(84, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Cancel";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.onCancel);
            // 
            // saveNCancel
            // 
            this.saveNCancel.Controls.Add(this.button2);
            this.saveNCancel.Controls.Add(this.button5);
            this.saveNCancel.Location = new System.Drawing.Point(10, 526);
            this.saveNCancel.Name = "saveNCancel";
            this.saveNCancel.Size = new System.Drawing.Size(164, 33);
            this.saveNCancel.TabIndex = 7;
            this.saveNCancel.Visible = false;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(830, 10);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(222, 22);
            this.search.TabIndex = 8;
            this.search.TextChanged += new System.EventHandler(this.onTrySearch);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(88, 349);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(187, 22);
            this.username.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Username";
            // 
            // passwordLb
            // 
            this.passwordLb.AutoSize = true;
            this.passwordLb.Location = new System.Drawing.Point(7, 433);
            this.passwordLb.Name = "passwordLb";
            this.passwordLb.Size = new System.Drawing.Size(67, 16);
            this.passwordLb.TabIndex = 13;
            this.passwordLb.Text = "Password";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(88, 430);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(187, 22);
            this.password.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Full Name";
            // 
            // fullName
            // 
            this.fullName.Location = new System.Drawing.Point(88, 375);
            this.fullName.Name = "fullName";
            this.fullName.Size = new System.Drawing.Size(187, 22);
            this.fullName.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 406);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Phone";
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(88, 403);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(187, 22);
            this.phone.TabIndex = 16;
            // 
            // roleLb
            // 
            this.roleLb.AutoSize = true;
            this.roleLb.Location = new System.Drawing.Point(7, 459);
            this.roleLb.Name = "roleLb";
            this.roleLb.Size = new System.Drawing.Size(36, 16);
            this.roleLb.TabIndex = 19;
            this.roleLb.Text = "Role";
            // 
            // roles
            // 
            this.roles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roles.FormattingEnabled = true;
            this.roles.Location = new System.Drawing.Point(88, 456);
            this.roles.Name = "roles";
            this.roles.Size = new System.Drawing.Size(187, 24);
            this.roles.TabIndex = 20;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.roles);
            this.Controls.Add(this.roleLb);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fullName);
            this.Controls.Add(this.passwordLb);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.username);
            this.Controls.Add(this.search);
            this.Controls.Add(this.saveNCancel);
            this.Controls.Add(this.actionPanel);
            this.Controls.Add(this.roleFilters);
            this.Controls.Add(this.table1);
            this.Controls.Add(this.label1);
            this.Name = "Users";
            this.Size = new System.Drawing.Size(1062, 562);
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            this.actionPanel.ResumeLayout(false);
            this.saveNCancel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView table1;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.ComboBox roleFilters;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel saveNCancel;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label passwordLb;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox fullName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Label roleLb;
        private System.Windows.Forms.ComboBox roles;
    }
}
