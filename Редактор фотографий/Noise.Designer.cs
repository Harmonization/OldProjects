namespace FlyPhoto
{
    partial class Noise
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Noise));
            this.Input = new System.Windows.Forms.PictureBox();
            this.Rand = new System.Windows.Forms.PictureBox();
            this.Result = new System.Windows.Forms.PictureBox();
            this.RandNoise = new System.Windows.Forms.Button();
            this.Ok = new System.Windows.Forms.Button();
            this.AddNoise = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Animation = new System.Windows.Forms.Button();
            this.Anim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddNoise)).BeginInit();
            this.SuspendLayout();
            // 
            // Input
            // 
            this.Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Input.Location = new System.Drawing.Point(12, 51);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(621, 621);
            this.Input.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Input.TabIndex = 4;
            this.Input.TabStop = false;
            // 
            // Rand
            // 
            this.Rand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Rand.Location = new System.Drawing.Point(639, 51);
            this.Rand.Name = "Rand";
            this.Rand.Size = new System.Drawing.Size(621, 621);
            this.Rand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Rand.TabIndex = 5;
            this.Rand.TabStop = false;
            // 
            // Result
            // 
            this.Result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Result.Location = new System.Drawing.Point(1266, 51);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(621, 621);
            this.Result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Result.TabIndex = 6;
            this.Result.TabStop = false;
            // 
            // RandNoise
            // 
            this.RandNoise.BackColor = System.Drawing.Color.LemonChiffon;
            this.RandNoise.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RandNoise.Location = new System.Drawing.Point(799, 730);
            this.RandNoise.Name = "RandNoise";
            this.RandNoise.Size = new System.Drawing.Size(304, 51);
            this.RandNoise.TabIndex = 7;
            this.RandNoise.Text = "Сгенерировать шум";
            this.RandNoise.UseVisualStyleBackColor = false;
            this.RandNoise.Click += new System.EventHandler(this.RandNoise_Click);
            // 
            // Ok
            // 
            this.Ok.BackColor = System.Drawing.Color.LemonChiffon;
            this.Ok.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ok.Location = new System.Drawing.Point(1708, 812);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(167, 51);
            this.Ok.TabIndex = 8;
            this.Ok.Text = "Ок";
            this.Ok.UseVisualStyleBackColor = false;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // AddNoise
            // 
            this.AddNoise.BackColor = System.Drawing.Color.LemonChiffon;
            this.AddNoise.Location = new System.Drawing.Point(1425, 730);
            this.AddNoise.Maximum = 100;
            this.AddNoise.Name = "AddNoise";
            this.AddNoise.Size = new System.Drawing.Size(236, 69);
            this.AddNoise.TabIndex = 21;
            this.AddNoise.TickStyle = System.Windows.Forms.TickStyle.None;
            this.AddNoise.Scroll += new System.EventHandler(this.AddNoise_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(164, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 40);
            this.label3.TabIndex = 22;
            this.label3.Text = "Исходное";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(837, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 40);
            this.label1.TabIndex = 23;
            this.label1.Text = "Шум";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1509, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 40);
            this.label2.TabIndex = 24;
            this.label2.Text = "Результат";
            // 
            // Animation
            // 
            this.Animation.BackColor = System.Drawing.Color.LemonChiffon;
            this.Animation.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Animation.Location = new System.Drawing.Point(799, 812);
            this.Animation.Name = "Animation";
            this.Animation.Size = new System.Drawing.Size(304, 51);
            this.Animation.TabIndex = 25;
            this.Animation.Text = "Анимировать";
            this.Animation.UseVisualStyleBackColor = false;
            this.Animation.Click += new System.EventHandler(this.Animation_Click);
            // 
            // Anim
            // 
            this.Anim.BackColor = System.Drawing.Color.LemonChiffon;
            this.Anim.BackgroundImage = global::FlyPhoto.Properties.Resources._2000px_Xmark01_svg_;
            this.Anim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Anim.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Anim.Location = new System.Drawing.Point(1109, 812);
            this.Anim.Name = "Anim";
            this.Anim.Size = new System.Drawing.Size(74, 51);
            this.Anim.TabIndex = 26;
            this.Anim.UseVisualStyleBackColor = false;
            this.Anim.Click += new System.EventHandler(this.Anim_Click);
            // 
            // Noise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(1924, 875);
            this.Controls.Add(this.Anim);
            this.Controls.Add(this.Animation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AddNoise);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.RandNoise);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Rand);
            this.Controls.Add(this.Input);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Noise";
            this.Text = "Добавить шум";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Noise_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Input)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddNoise)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox Input;
        public System.Windows.Forms.PictureBox Rand;
        public System.Windows.Forms.PictureBox Result;
        private System.Windows.Forms.Button RandNoise;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.TrackBar AddNoise;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button Animation;
        private System.Windows.Forms.Button Anim;
    }
}