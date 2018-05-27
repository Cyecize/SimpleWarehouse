namespace SimpleWarehouse.Forms
{
    partial class FirstRunForm
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
            this.ShowDatabasesBtn = new System.Windows.Forms.Button();
            this.ServerTextBox = new System.Windows.Forms.TextBox();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TestConnBtn = new System.Windows.Forms.Button();
            this.LogLabel = new System.Windows.Forms.Label();
            this.AvaivableDatabasesListBox = new System.Windows.Forms.ComboBox();
            this.SelectDatabaseBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.NewDbTextBox = new System.Windows.Forms.TextBox();
            this.CreateDatabaseBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.NewUserUsernameTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.NewUserPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.NewUserConfPasswordTextBox = new System.Windows.Forms.TextBox();
            this.CreateUserBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.ConcludeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ShowDatabasesBtn
            // 
            this.ShowDatabasesBtn.Location = new System.Drawing.Point(151, 109);
            this.ShowDatabasesBtn.Name = "ShowDatabasesBtn";
            this.ShowDatabasesBtn.Size = new System.Drawing.Size(121, 23);
            this.ShowDatabasesBtn.TabIndex = 1;
            this.ShowDatabasesBtn.Text = "Display Databases";
            this.ShowDatabasesBtn.UseVisualStyleBackColor = true;
            this.ShowDatabasesBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ServerTextBox
            // 
            this.ServerTextBox.Location = new System.Drawing.Point(12, 83);
            this.ServerTextBox.Name = "ServerTextBox";
            this.ServerTextBox.Size = new System.Drawing.Size(100, 20);
            this.ServerTextBox.TabIndex = 2;
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(12, 122);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(100, 20);
            this.PortTextBox.TabIndex = 3;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(12, 161);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.UsernameTextBox.TabIndex = 4;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(12, 200);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.PasswordTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password";
            // 
            // TestConnBtn
            // 
            this.TestConnBtn.Location = new System.Drawing.Point(12, 226);
            this.TestConnBtn.Name = "TestConnBtn";
            this.TestConnBtn.Size = new System.Drawing.Size(100, 23);
            this.TestConnBtn.TabIndex = 10;
            this.TestConnBtn.Text = "TestConnection";
            this.TestConnBtn.UseVisualStyleBackColor = true;
            this.TestConnBtn.Click += new System.EventHandler(this.TestConnBtn_Click);
            // 
            // LogLabel
            // 
            this.LogLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(12, 287);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(35, 13);
            this.LogLabel.TabIndex = 11;
            this.LogLabel.Text = "label5";
            // 
            // AvaivableDatabasesListBox
            // 
            this.AvaivableDatabasesListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AvaivableDatabasesListBox.FormattingEnabled = true;
            this.AvaivableDatabasesListBox.Location = new System.Drawing.Point(151, 82);
            this.AvaivableDatabasesListBox.Name = "AvaivableDatabasesListBox";
            this.AvaivableDatabasesListBox.Size = new System.Drawing.Size(121, 21);
            this.AvaivableDatabasesListBox.TabIndex = 12;
            // 
            // SelectDatabaseBtn
            // 
            this.SelectDatabaseBtn.Location = new System.Drawing.Point(151, 135);
            this.SelectDatabaseBtn.Name = "SelectDatabaseBtn";
            this.SelectDatabaseBtn.Size = new System.Drawing.Size(121, 23);
            this.SelectDatabaseBtn.TabIndex = 13;
            this.SelectDatabaseBtn.Text = "Select Database";
            this.SelectDatabaseBtn.UseVisualStyleBackColor = true;
            this.SelectDatabaseBtn.Click += new System.EventHandler(this.SelectDatabaseBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "New Database";
            // 
            // NewDbTextBox
            // 
            this.NewDbTextBox.Location = new System.Drawing.Point(151, 200);
            this.NewDbTextBox.Name = "NewDbTextBox";
            this.NewDbTextBox.Size = new System.Drawing.Size(121, 20);
            this.NewDbTextBox.TabIndex = 14;
            // 
            // CreateDatabaseBtn
            // 
            this.CreateDatabaseBtn.Location = new System.Drawing.Point(151, 226);
            this.CreateDatabaseBtn.Name = "CreateDatabaseBtn";
            this.CreateDatabaseBtn.Size = new System.Drawing.Size(121, 23);
            this.CreateDatabaseBtn.TabIndex = 16;
            this.CreateDatabaseBtn.Text = "Create Database";
            this.CreateDatabaseBtn.UseVisualStyleBackColor = true;
            this.CreateDatabaseBtn.Click += new System.EventHandler(this.CreateDatabaseBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(354, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Administrator";
            // 
            // NewUserUsernameTextBox
            // 
            this.NewUserUsernameTextBox.Location = new System.Drawing.Point(357, 109);
            this.NewUserUsernameTextBox.Name = "NewUserUsernameTextBox";
            this.NewUserUsernameTextBox.Size = new System.Drawing.Size(121, 20);
            this.NewUserUsernameTextBox.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(354, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Username";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(354, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Password";
            // 
            // NewUserPasswordTextBox
            // 
            this.NewUserPasswordTextBox.Location = new System.Drawing.Point(357, 148);
            this.NewUserPasswordTextBox.Name = "NewUserPasswordTextBox";
            this.NewUserPasswordTextBox.Size = new System.Drawing.Size(121, 20);
            this.NewUserPasswordTextBox.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(354, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Conf-Password";
            // 
            // NewUserConfPasswordTextBox
            // 
            this.NewUserConfPasswordTextBox.Location = new System.Drawing.Point(357, 200);
            this.NewUserConfPasswordTextBox.Name = "NewUserConfPasswordTextBox";
            this.NewUserConfPasswordTextBox.Size = new System.Drawing.Size(121, 20);
            this.NewUserConfPasswordTextBox.TabIndex = 22;
            // 
            // CreateUserBtn
            // 
            this.CreateUserBtn.Enabled = false;
            this.CreateUserBtn.Location = new System.Drawing.Point(357, 226);
            this.CreateUserBtn.Name = "CreateUserBtn";
            this.CreateUserBtn.Size = new System.Drawing.Size(121, 23);
            this.CreateUserBtn.TabIndex = 24;
            this.CreateUserBtn.Text = "Create User";
            this.CreateUserBtn.UseVisualStyleBackColor = true;
            this.CreateUserBtn.Click += new System.EventHandler(this.CreateUserBtn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(151, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Select Database";
            // 
            // ConcludeBtn
            // 
            this.ConcludeBtn.Location = new System.Drawing.Point(357, 275);
            this.ConcludeBtn.Name = "ConcludeBtn";
            this.ConcludeBtn.Size = new System.Drawing.Size(121, 23);
            this.ConcludeBtn.TabIndex = 26;
            this.ConcludeBtn.Text = "Finish";
            this.ConcludeBtn.UseVisualStyleBackColor = true;
            this.ConcludeBtn.Click += new System.EventHandler(this.ConcludeBtn_Click);
            // 
            // FirstRunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 310);
            this.Controls.Add(this.ConcludeBtn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CreateUserBtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.NewUserConfPasswordTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.NewUserPasswordTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.NewUserUsernameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CreateDatabaseBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NewDbTextBox);
            this.Controls.Add(this.SelectDatabaseBtn);
            this.Controls.Add(this.AvaivableDatabasesListBox);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.TestConnBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.PortTextBox);
            this.Controls.Add(this.ServerTextBox);
            this.Controls.Add(this.ShowDatabasesBtn);
            this.MaximumSize = new System.Drawing.Size(495, 310);
            this.MinimumSize = new System.Drawing.Size(495, 310);
            this.Name = "FirstRunForm";
            this.Sizable = false;
            this.Text = "FirstRunRorm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ShowDatabasesBtn;
        private System.Windows.Forms.TextBox ServerTextBox;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button TestConnBtn;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.ComboBox AvaivableDatabasesListBox;
        private System.Windows.Forms.Button SelectDatabaseBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NewDbTextBox;
        private System.Windows.Forms.Button CreateDatabaseBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NewUserUsernameTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NewUserPasswordTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox NewUserConfPasswordTextBox;
        private System.Windows.Forms.Button CreateUserBtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button ConcludeBtn;
    }
}