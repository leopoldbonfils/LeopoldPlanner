namespace LeopoldPlan
{
    partial class Register
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.linkRegister1 = new System.Windows.Forms.LinkLabel();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConform = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.loginBtn1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(-8, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 501);
            this.panel1.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Cursor = System.Windows.Forms.Cursors.No;
            this.label4.Location = new System.Drawing.Point(36, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Welcome to Leopld Plan";
            // 
            // linkRegister1
            // 
            this.linkRegister1.AutoSize = true;
            this.linkRegister1.Location = new System.Drawing.Point(540, 450);
            this.linkRegister1.Name = "linkRegister1";
            this.linkRegister1.Size = new System.Drawing.Size(160, 20);
            this.linkRegister1.TabIndex = 14;
            this.linkRegister1.TabStop = true;
            this.linkRegister1.Text = "Click here to Register";
            this.linkRegister1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRegister1_LinkClicked);
            // 
            // txtPassword1
            // 
            this.txtPassword1.Location = new System.Drawing.Point(522, 230);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.Size = new System.Drawing.Size(238, 26);
            this.txtPassword1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Password";
            // 
            // txtEmail1
            // 
            this.txtEmail1.Location = new System.Drawing.Point(522, 156);
            this.txtEmail1.Name = "txtEmail1";
            this.txtEmail1.Size = new System.Drawing.Size(238, 26);
            this.txtEmail1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(562, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "REGISTER Here";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "confirm Password";
            // 
            // txtConform
            // 
            this.txtConform.Location = new System.Drawing.Point(531, 285);
            this.txtConform.Name = "txtConform";
            this.txtConform.Size = new System.Drawing.Size(229, 26);
            this.txtConform.TabIndex = 17;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(468, 340);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(213, 24);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "Agree term and condition";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // loginBtn1
            // 
            this.loginBtn1.Location = new System.Drawing.Point(544, 370);
            this.loginBtn1.Name = "loginBtn1";
            this.loginBtn1.Size = new System.Drawing.Size(115, 55);
            this.loginBtn1.TabIndex = 13;
            this.loginBtn1.Text = "Register";
            this.loginBtn1.UseVisualStyleBackColor = true;
            this.loginBtn1.Click += new System.EventHandler(this.loginBtn1_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 492);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtConform);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.linkRegister1);
            this.Controls.Add(this.loginBtn1);
            this.Controls.Add(this.txtPassword1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmail1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Register";
            this.Text = "Register";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkRegister1;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtConform;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button loginBtn1;
    }
}