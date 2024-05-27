namespace GD_Kassa
{
    partial class log_in
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(log_in));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pB_Clear = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.tB_login = new System.Windows.Forms.TextBox();
            this.tB_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(154, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Аутентификация";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(487, 68);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pB_Clear
            // 
            this.pB_Clear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pB_Clear.BackgroundImage")));
            this.pB_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pB_Clear.Location = new System.Drawing.Point(359, 221);
            this.pB_Clear.Name = "pB_Clear";
            this.pB_Clear.Size = new System.Drawing.Size(26, 25);
            this.pB_Clear.TabIndex = 75;
            this.pB_Clear.UseVisualStyleBackColor = true;
            this.pB_Clear.Click += new System.EventHandler(this.pB_Clear_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEnter.Location = new System.Drawing.Point(202, 243);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(105, 34);
            this.btnEnter.TabIndex = 74;
            this.btnEnter.Text = "Войти";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // tB_login
            // 
            this.tB_login.Location = new System.Drawing.Point(188, 108);
            this.tB_login.Name = "tB_login";
            this.tB_login.Size = new System.Drawing.Size(165, 20);
            this.tB_login.TabIndex = 73;
            // 
            // tB_password
            // 
            this.tB_password.BackColor = System.Drawing.SystemColors.Window;
            this.tB_password.Location = new System.Drawing.Point(188, 170);
            this.tB_password.Name = "tB_password";
            this.tB_password.PasswordChar = '*';
            this.tB_password.Size = new System.Drawing.Size(165, 20);
            this.tB_password.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(102, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 22);
            this.label3.TabIndex = 71;
            this.label3.Text = "Пароль:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(117, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 22);
            this.label2.TabIndex = 70;
            this.label2.Text = "Логин:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // log_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(487, 306);
            this.Controls.Add(this.pB_Clear);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.tB_login);
            this.Controls.Add(this.tB_password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "log_in";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button pB_Clear;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox tB_login;
        private System.Windows.Forms.TextBox tB_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

