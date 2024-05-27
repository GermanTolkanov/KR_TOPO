namespace GD_Kassa
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Table_b_Post = new System.Windows.Forms.Button();
            this.Table_b_Users = new System.Windows.Forms.Button();
            this.Table_b_Passage_Discount = new System.Windows.Forms.Button();
            this.Table_b_Passanger = new System.Windows.Forms.Button();
            this.Table_b_Class = new System.Windows.Forms.Button();
            this.Table_b_Station = new System.Windows.Forms.Button();
            this.Table_b_Passage = new System.Windows.Forms.Button();
            this.Table_b_Discount = new System.Windows.Forms.Button();
            this.Table_b_Payment = new System.Windows.Forms.Button();
            this.Table_b_Train = new System.Windows.Forms.Button();
            this.Table_b_Ticket = new System.Windows.Forms.Button();
            this.Table_b_cashBox = new System.Windows.Forms.Button();
            this.Table_b_Depot = new System.Windows.Forms.Button();
            this.Table_b_policy = new System.Windows.Forms.Button();
            this.l_chngPswd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(158, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 26);
            this.label1.TabIndex = 38;
            this.label1.Text = "Главная форма";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(490, 69);
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // Table_b_Post
            // 
            this.Table_b_Post.Location = new System.Drawing.Point(279, 290);
            this.Table_b_Post.Name = "Table_b_Post";
            this.Table_b_Post.Size = new System.Drawing.Size(88, 23);
            this.Table_b_Post.TabIndex = 62;
            this.Table_b_Post.Text = "Должности";
            this.Table_b_Post.UseVisualStyleBackColor = true;
            this.Table_b_Post.Click += new System.EventHandler(this.Table_b_Post_Click);
            // 
            // Table_b_Users
            // 
            this.Table_b_Users.Enabled = false;
            this.Table_b_Users.Location = new System.Drawing.Point(132, 330);
            this.Table_b_Users.Name = "Table_b_Users";
            this.Table_b_Users.Size = new System.Drawing.Size(88, 23);
            this.Table_b_Users.TabIndex = 61;
            this.Table_b_Users.Text = "Пользователи";
            this.Table_b_Users.UseVisualStyleBackColor = true;
            this.Table_b_Users.Visible = false;
            this.Table_b_Users.Click += new System.EventHandler(this.Table_b_Users_Click);
            // 
            // Table_b_Passage_Discount
            // 
            this.Table_b_Passage_Discount.Location = new System.Drawing.Point(132, 290);
            this.Table_b_Passage_Discount.Name = "Table_b_Passage_Discount";
            this.Table_b_Passage_Discount.Size = new System.Drawing.Size(88, 23);
            this.Table_b_Passage_Discount.TabIndex = 60;
            this.Table_b_Passage_Discount.Text = "Рейс_Скидка";
            this.Table_b_Passage_Discount.UseVisualStyleBackColor = true;
            this.Table_b_Passage_Discount.Click += new System.EventHandler(this.Table_b_Passage_Discount_Click);
            // 
            // Table_b_Passanger
            // 
            this.Table_b_Passanger.Location = new System.Drawing.Point(279, 86);
            this.Table_b_Passanger.Name = "Table_b_Passanger";
            this.Table_b_Passanger.Size = new System.Drawing.Size(88, 23);
            this.Table_b_Passanger.TabIndex = 59;
            this.Table_b_Passanger.Text = "Пассажир";
            this.Table_b_Passanger.UseVisualStyleBackColor = true;
            this.Table_b_Passanger.Click += new System.EventHandler(this.Table_b_Passanger_Click);
            // 
            // Table_b_Class
            // 
            this.Table_b_Class.Location = new System.Drawing.Point(279, 127);
            this.Table_b_Class.Name = "Table_b_Class";
            this.Table_b_Class.Size = new System.Drawing.Size(88, 23);
            this.Table_b_Class.TabIndex = 58;
            this.Table_b_Class.Text = "Класс";
            this.Table_b_Class.UseVisualStyleBackColor = true;
            this.Table_b_Class.Click += new System.EventHandler(this.Table_b_Class_Click);
            // 
            // Table_b_Station
            // 
            this.Table_b_Station.Location = new System.Drawing.Point(279, 167);
            this.Table_b_Station.Name = "Table_b_Station";
            this.Table_b_Station.Size = new System.Drawing.Size(88, 23);
            this.Table_b_Station.TabIndex = 57;
            this.Table_b_Station.Text = "Cтанции";
            this.Table_b_Station.UseVisualStyleBackColor = true;
            this.Table_b_Station.Click += new System.EventHandler(this.Table_b_Station_Click);
            // 
            // Table_b_Passage
            // 
            this.Table_b_Passage.Location = new System.Drawing.Point(132, 254);
            this.Table_b_Passage.Name = "Table_b_Passage";
            this.Table_b_Passage.Size = new System.Drawing.Size(88, 23);
            this.Table_b_Passage.TabIndex = 56;
            this.Table_b_Passage.Text = "Рейс";
            this.Table_b_Passage.UseVisualStyleBackColor = true;
            this.Table_b_Passage.Click += new System.EventHandler(this.Table_b_Passage_Click);
            // 
            // Table_b_Discount
            // 
            this.Table_b_Discount.Location = new System.Drawing.Point(279, 254);
            this.Table_b_Discount.Name = "Table_b_Discount";
            this.Table_b_Discount.Size = new System.Drawing.Size(88, 23);
            this.Table_b_Discount.TabIndex = 55;
            this.Table_b_Discount.Text = "Скидка";
            this.Table_b_Discount.UseVisualStyleBackColor = true;
            this.Table_b_Discount.Click += new System.EventHandler(this.Table_b_Discount_Click);
            // 
            // Table_b_Payment
            // 
            this.Table_b_Payment.Location = new System.Drawing.Point(279, 210);
            this.Table_b_Payment.Name = "Table_b_Payment";
            this.Table_b_Payment.Size = new System.Drawing.Size(88, 23);
            this.Table_b_Payment.TabIndex = 54;
            this.Table_b_Payment.Text = "Платеж";
            this.Table_b_Payment.UseVisualStyleBackColor = true;
            this.Table_b_Payment.Click += new System.EventHandler(this.Table_b_Payment_Click);
            // 
            // Table_b_Train
            // 
            this.Table_b_Train.Location = new System.Drawing.Point(132, 168);
            this.Table_b_Train.Name = "Table_b_Train";
            this.Table_b_Train.Size = new System.Drawing.Size(88, 23);
            this.Table_b_Train.TabIndex = 53;
            this.Table_b_Train.Text = "Поезд";
            this.Table_b_Train.UseVisualStyleBackColor = true;
            this.Table_b_Train.Click += new System.EventHandler(this.Table_b_Train_Click);
            // 
            // Table_b_Ticket
            // 
            this.Table_b_Ticket.Location = new System.Drawing.Point(132, 211);
            this.Table_b_Ticket.Name = "Table_b_Ticket";
            this.Table_b_Ticket.Size = new System.Drawing.Size(88, 23);
            this.Table_b_Ticket.TabIndex = 52;
            this.Table_b_Ticket.Text = "Билет";
            this.Table_b_Ticket.UseVisualStyleBackColor = true;
            this.Table_b_Ticket.Click += new System.EventHandler(this.Table_b_Ticket_Click);
            // 
            // Table_b_cashBox
            // 
            this.Table_b_cashBox.Location = new System.Drawing.Point(132, 128);
            this.Table_b_cashBox.Name = "Table_b_cashBox";
            this.Table_b_cashBox.Size = new System.Drawing.Size(88, 23);
            this.Table_b_cashBox.TabIndex = 51;
            this.Table_b_cashBox.Text = "Касса";
            this.Table_b_cashBox.UseVisualStyleBackColor = true;
            this.Table_b_cashBox.Click += new System.EventHandler(this.Table_b_cashBox_Click);
            // 
            // Table_b_Depot
            // 
            this.Table_b_Depot.Location = new System.Drawing.Point(132, 86);
            this.Table_b_Depot.Name = "Table_b_Depot";
            this.Table_b_Depot.Size = new System.Drawing.Size(88, 23);
            this.Table_b_Depot.TabIndex = 50;
            this.Table_b_Depot.Text = "Вокзал";
            this.Table_b_Depot.UseVisualStyleBackColor = true;
            this.Table_b_Depot.Click += new System.EventHandler(this.Table_b_Depot_Click);
            // 
            // Table_b_policy
            // 
            this.Table_b_policy.Enabled = false;
            this.Table_b_policy.Location = new System.Drawing.Point(279, 330);
            this.Table_b_policy.Name = "Table_b_policy";
            this.Table_b_policy.Size = new System.Drawing.Size(88, 23);
            this.Table_b_policy.TabIndex = 63;
            this.Table_b_policy.Text = "Политика";
            this.Table_b_policy.UseVisualStyleBackColor = true;
            this.Table_b_policy.Visible = false;
            this.Table_b_policy.Click += new System.EventHandler(this.Table_b_policy_Click);
            // 
            // l_chngPswd
            // 
            this.l_chngPswd.AutoSize = true;
            this.l_chngPswd.Location = new System.Drawing.Point(133, 366);
            this.l_chngPswd.Name = "l_chngPswd";
            this.l_chngPswd.Size = new System.Drawing.Size(234, 13);
            this.l_chngPswd.TabIndex = 64;
            this.l_chngPswd.Text = "Необходимо сменить пароль пользователю!";
            this.l_chngPswd.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 398);
            this.Controls.Add(this.l_chngPswd);
            this.Controls.Add(this.Table_b_policy);
            this.Controls.Add(this.Table_b_Post);
            this.Controls.Add(this.Table_b_Users);
            this.Controls.Add(this.Table_b_Passage_Discount);
            this.Controls.Add(this.Table_b_Passanger);
            this.Controls.Add(this.Table_b_Class);
            this.Controls.Add(this.Table_b_Station);
            this.Controls.Add(this.Table_b_Passage);
            this.Controls.Add(this.Table_b_Discount);
            this.Controls.Add(this.Table_b_Payment);
            this.Controls.Add(this.Table_b_Train);
            this.Controls.Add(this.Table_b_Ticket);
            this.Controls.Add(this.Table_b_cashBox);
            this.Controls.Add(this.Table_b_Depot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Table_b_Post;
        private System.Windows.Forms.Button Table_b_Users;
        private System.Windows.Forms.Button Table_b_Passage_Discount;
        private System.Windows.Forms.Button Table_b_Passanger;
        private System.Windows.Forms.Button Table_b_Class;
        private System.Windows.Forms.Button Table_b_Station;
        private System.Windows.Forms.Button Table_b_Passage;
        private System.Windows.Forms.Button Table_b_Discount;
        private System.Windows.Forms.Button Table_b_Payment;
        private System.Windows.Forms.Button Table_b_Train;
        private System.Windows.Forms.Button Table_b_Ticket;
        private System.Windows.Forms.Button Table_b_cashBox;
        private System.Windows.Forms.Button Table_b_Depot;
        private System.Windows.Forms.Button Table_b_policy;
        private System.Windows.Forms.Label l_chngPswd;
    }
}