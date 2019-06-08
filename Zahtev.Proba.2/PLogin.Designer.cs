namespace DiReqt
{
    partial class PLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLogin));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelLinija2 = new System.Windows.Forms.Panel();
            this.panelLinija1 = new System.Windows.Forms.Panel();
            this.picBoxPassword = new System.Windows.Forms.PictureBox();
            this.picBoxUsername = new System.Windows.Forms.PictureBox();
            this.picBoxDireqtLogo = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDireqtLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.SteelBlue;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Arial", 12F);
            this.textBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textBox2.Location = new System.Drawing.Point(62, 242);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(187, 19);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Password";
            this.textBox2.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.textBox2.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial CE", 12F);
            this.textBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.Location = new System.Drawing.Point(62, 192);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Username";
            this.textBox1.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.textBox1.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.btnClose);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(307, 26);
            this.TopPanel.TabIndex = 21;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(283, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 26);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelLinija2
            // 
            this.panelLinija2.BackColor = System.Drawing.SystemColors.Window;
            this.panelLinija2.Location = new System.Drawing.Point(29, 267);
            this.panelLinija2.Name = "panelLinija2";
            this.panelLinija2.Size = new System.Drawing.Size(250, 1);
            this.panelLinija2.TabIndex = 20;
            // 
            // panelLinija1
            // 
            this.panelLinija1.BackColor = System.Drawing.SystemColors.Window;
            this.panelLinija1.ForeColor = System.Drawing.Color.White;
            this.panelLinija1.Location = new System.Drawing.Point(29, 217);
            this.panelLinija1.Name = "panelLinija1";
            this.panelLinija1.Size = new System.Drawing.Size(250, 1);
            this.panelLinija1.TabIndex = 19;
            // 
            // picBoxPassword
            // 
            this.picBoxPassword.Image = global::DiReqt.Properties.Resources.Password_24px;
            this.picBoxPassword.Location = new System.Drawing.Point(29, 237);
            this.picBoxPassword.Name = "picBoxPassword";
            this.picBoxPassword.Size = new System.Drawing.Size(24, 24);
            this.picBoxPassword.TabIndex = 18;
            this.picBoxPassword.TabStop = false;
            // 
            // picBoxUsername
            // 
            this.picBoxUsername.Image = global::DiReqt.Properties.Resources.Username_24px;
            this.picBoxUsername.Location = new System.Drawing.Point(29, 187);
            this.picBoxUsername.Name = "picBoxUsername";
            this.picBoxUsername.Size = new System.Drawing.Size(24, 24);
            this.picBoxUsername.TabIndex = 17;
            this.picBoxUsername.TabStop = false;
            // 
            // picBoxDireqtLogo
            // 
            this.picBoxDireqtLogo.Image = global::DiReqt.Properties.Resources.Logo_130px;
            this.picBoxDireqtLogo.Location = new System.Drawing.Point(85, 34);
            this.picBoxDireqtLogo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 3);
            this.picBoxDireqtLogo.Name = "picBoxDireqtLogo";
            this.picBoxDireqtLogo.Size = new System.Drawing.Size(130, 130);
            this.picBoxDireqtLogo.TabIndex = 16;
            this.picBoxDireqtLogo.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 12F);
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(97, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "Log in";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(307, 420);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.panelLinija2);
            this.Controls.Add(this.panelLinija1);
            this.Controls.Add(this.picBoxPassword);
            this.Controls.Add(this.picBoxUsername);
            this.Controls.Add(this.picBoxDireqtLogo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.PLogin_Load);
            this.TopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDireqtLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelLinija2;
        private System.Windows.Forms.Panel panelLinija1;
        private System.Windows.Forms.PictureBox picBoxPassword;
        private System.Windows.Forms.PictureBox picBoxUsername;
        private System.Windows.Forms.PictureBox picBoxDireqtLogo;
    }
}