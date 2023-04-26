namespace FlyPhoto
{
    partial class Gamma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gamma));
            this.Green = new System.Windows.Forms.TrackBar();
            this.Blue = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Red = new System.Windows.Forms.TrackBar();
            this.Ok = new System.Windows.Forms.Button();
            this.Return = new System.Windows.Forms.Button();
            this.Swap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Red)).BeginInit();
            this.SuspendLayout();
            // 
            // Green
            // 
            this.Green.BackColor = System.Drawing.Color.LemonChiffon;
            this.Green.Location = new System.Drawing.Point(123, 154);
            this.Green.Maximum = 255;
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(525, 69);
            this.Green.TabIndex = 25;
            this.Green.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Green.Value = 25;
            this.Green.Scroll += new System.EventHandler(this.Green_Scroll);
            // 
            // Blue
            // 
            this.Blue.BackColor = System.Drawing.Color.LemonChiffon;
            this.Blue.Location = new System.Drawing.Point(123, 229);
            this.Blue.Maximum = 255;
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(525, 69);
            this.Blue.TabIndex = 26;
            this.Blue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Blue.Value = 25;
            this.Blue.Scroll += new System.EventHandler(this.Blue_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe Script", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(654, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 32);
            this.label8.TabIndex = 27;
            this.label8.Text = "Голубой";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(654, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 32);
            this.label1.TabIndex = 28;
            this.label1.Text = "Зеленый";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(654, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 32);
            this.label2.TabIndex = 29;
            this.label2.Text = "Красный";
            // 
            // Red
            // 
            this.Red.BackColor = System.Drawing.Color.LemonChiffon;
            this.Red.Location = new System.Drawing.Point(123, 68);
            this.Red.Maximum = 255;
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(525, 69);
            this.Red.TabIndex = 30;
            this.Red.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Red.Value = 25;
            this.Red.Scroll += new System.EventHandler(this.Red_Scroll);
            // 
            // Ok
            // 
            this.Ok.BackColor = System.Drawing.Color.LemonChiffon;
            this.Ok.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ok.ForeColor = System.Drawing.Color.Blue;
            this.Ok.Location = new System.Drawing.Point(407, 325);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(241, 51);
            this.Ok.TabIndex = 31;
            this.Ok.Text = "Ок";
            this.Ok.UseVisualStyleBackColor = false;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // Return
            // 
            this.Return.BackColor = System.Drawing.Color.LemonChiffon;
            this.Return.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Return.ForeColor = System.Drawing.Color.Blue;
            this.Return.Location = new System.Drawing.Point(123, 325);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(241, 51);
            this.Return.TabIndex = 32;
            this.Return.Text = "Вернуть";
            this.Return.UseVisualStyleBackColor = false;
            this.Return.Click += new System.EventHandler(this.Return_Click);
            // 
            // Swap
            // 
            this.Swap.BackColor = System.Drawing.Color.LemonChiffon;
            this.Swap.BackgroundImage = global::FlyPhoto.Properties.Resources.arrow_35171__4801;
            this.Swap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Swap.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Swap.Location = new System.Drawing.Point(43, 140);
            this.Swap.Name = "Swap";
            this.Swap.Size = new System.Drawing.Size(62, 59);
            this.Swap.TabIndex = 33;
            this.Swap.UseVisualStyleBackColor = false;
            this.Swap.Click += new System.EventHandler(this.Swap_Click);
            // 
            // Gamma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Swap);
            this.Controls.Add(this.Return);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Red);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Blue);
            this.Controls.Add(this.Green);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Gamma";
            this.Text = "Гамма изображения";
            ((System.ComponentModel.ISupportInitialize)(this.Green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Red)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar Green;
        private System.Windows.Forms.TrackBar Blue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar Red;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Return;
        private System.Windows.Forms.Button Swap;
    }
}