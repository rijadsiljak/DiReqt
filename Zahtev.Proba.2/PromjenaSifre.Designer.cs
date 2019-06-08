namespace DiReqt
{
    partial class PromjenaSifre
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.lblNaslov = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLinija2 = new System.Windows.Forms.Panel();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.txtPotvrdaSifre = new System.Windows.Forms.TextBox();
            this.txtNovaSifra = new System.Windows.Forms.TextBox();
            this.txtStaraSifra = new System.Windows.Forms.TextBox();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.SystemColors.Control;
            this.TopPanel.Controls.Add(this.lblNaslov);
            this.TopPanel.Controls.Add(this.CloseButton);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(434, 25);
            this.TopPanel.TabIndex = 27;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            this.TopPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseUp);
            // 
            // lblNaslov
            // 
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblNaslov.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNaslov.Location = new System.Drawing.Point(1, 6);
            this.lblNaslov.Margin = new System.Windows.Forms.Padding(0);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(110, 16);
            this.lblNaslov.TabIndex = 22;
            this.lblNaslov.Text = "Promjena šifre";
            // 
            // CloseButton
            // 
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.SystemColors.Control;
            this.CloseButton.Image = global::DiReqt.Properties.Resources.Close_SteelBlue;
            this.CloseButton.Location = new System.Drawing.Point(410, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(24, 25);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Location = new System.Drawing.Point(22, 144);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 1);
            this.panel2.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(22, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 1);
            this.panel1.TabIndex = 26;
            // 
            // panelLinija2
            // 
            this.panelLinija2.BackColor = System.Drawing.Color.SteelBlue;
            this.panelLinija2.Location = new System.Drawing.Point(22, 73);
            this.panelLinija2.Name = "panelLinija2";
            this.panelLinija2.Size = new System.Drawing.Size(300, 1);
            this.panelLinija2.TabIndex = 29;
            // 
            // btnSpremi
            // 
            this.btnSpremi.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSpremi.FlatAppearance.BorderSize = 0;
            this.btnSpremi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpremi.Font = new System.Drawing.Font("Arial", 12F);
            this.btnSpremi.ForeColor = System.Drawing.Color.White;
            this.btnSpremi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSpremi.Location = new System.Drawing.Point(330, 165);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(92, 36);
            this.btnSpremi.TabIndex = 3;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSpremi.UseVisualStyleBackColor = false;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // txtPotvrdaSifre
            // 
            this.txtPotvrdaSifre.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPotvrdaSifre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPotvrdaSifre.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.txtPotvrdaSifre.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtPotvrdaSifre.Location = new System.Drawing.Point(22, 128);
            this.txtPotvrdaSifre.Name = "txtPotvrdaSifre";
            this.txtPotvrdaSifre.Size = new System.Drawing.Size(230, 17);
            this.txtPotvrdaSifre.TabIndex = 2;
            this.txtPotvrdaSifre.Text = "Ponovite novu šifru";
            this.txtPotvrdaSifre.Enter += new System.EventHandler(this.txtPotvrdaSifre_Enter);
            this.txtPotvrdaSifre.Leave += new System.EventHandler(this.txtPotvrdaSifre_Leave);
            // 
            // txtNovaSifra
            // 
            this.txtNovaSifra.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtNovaSifra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNovaSifra.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtNovaSifra.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtNovaSifra.Location = new System.Drawing.Point(22, 92);
            this.txtNovaSifra.Name = "txtNovaSifra";
            this.txtNovaSifra.Size = new System.Drawing.Size(230, 18);
            this.txtNovaSifra.TabIndex = 1;
            this.txtNovaSifra.Text = "Nova šifra";
            this.txtNovaSifra.Enter += new System.EventHandler(this.txtNovaSifra_Enter);
            this.txtNovaSifra.Leave += new System.EventHandler(this.txtNovaSifra_Leave);
            // 
            // txtStaraSifra
            // 
            this.txtStaraSifra.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtStaraSifra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStaraSifra.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaraSifra.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtStaraSifra.Location = new System.Drawing.Point(22, 56);
            this.txtStaraSifra.Name = "txtStaraSifra";
            this.txtStaraSifra.Size = new System.Drawing.Size(230, 18);
            this.txtStaraSifra.TabIndex = 0;
            this.txtStaraSifra.Text = "Stara šifra";
            this.txtStaraSifra.Enter += new System.EventHandler(this.txtStaraSifra_Enter);
            this.txtStaraSifra.Leave += new System.EventHandler(this.txtStaraSifra_Leave);
            // 
            // PromjenaSifre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(434, 207);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelLinija2);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.txtPotvrdaSifre);
            this.Controls.Add(this.txtNovaSifra);
            this.Controls.Add(this.txtStaraSifra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PromjenaSifre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PromjenaSifre";
            this.Load += new System.EventHandler(this.PromjenaSifre_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelLinija2;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.TextBox txtPotvrdaSifre;
        private System.Windows.Forms.TextBox txtNovaSifra;
        private System.Windows.Forms.TextBox txtStaraSifra;
    }
}