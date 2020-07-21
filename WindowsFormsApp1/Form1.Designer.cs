namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.users = new System.Windows.Forms.Button();
            this.reservations = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // users
            // 
            this.users.ForeColor = System.Drawing.SystemColors.ControlText;
            this.users.Location = new System.Drawing.Point(188, 119);
            this.users.Margin = new System.Windows.Forms.Padding(2);
            this.users.Name = "users";
            this.users.Size = new System.Drawing.Size(150, 40);
            this.users.TabIndex = 0;
            this.users.Text = "Users";
            this.users.UseVisualStyleBackColor = true;
            this.users.Click += new System.EventHandler(this.button1_Click);
            // 
            // reservations
            // 
            this.reservations.Location = new System.Drawing.Point(188, 198);
            this.reservations.Margin = new System.Windows.Forms.Padding(2);
            this.reservations.Name = "reservations";
            this.reservations.Size = new System.Drawing.Size(150, 44);
            this.reservations.TabIndex = 1;
            this.reservations.Text = "Reservations";
            this.reservations.UseVisualStyleBackColor = true;
            this.reservations.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.asdasdasdas;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(525, 411);
            this.Controls.Add(this.users);
            this.Controls.Add(this.reservations);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Extreme gaming";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button users;
        private System.Windows.Forms.Button reservations;
    }
}

