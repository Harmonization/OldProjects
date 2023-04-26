namespace Arcan
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.RenderTime = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.labeltime = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // AnT
            // 
            this.AnT.AccumBits = ((byte)(0));
            this.AnT.AutoCheckErrors = false;
            this.AnT.AutoFinish = false;
            this.AnT.AutoMakeCurrent = true;
            this.AnT.AutoSwapBuffers = true;
            this.AnT.BackColor = System.Drawing.Color.Black;
            this.AnT.ColorBits = ((byte)(32));
            this.AnT.DepthBits = ((byte)(16));
            this.AnT.Location = new System.Drawing.Point(7, 3);
            this.AnT.Name = "AnT";
            this.AnT.Size = new System.Drawing.Size(1916, 1004);
            this.AnT.StencilBits = ((byte)(0));
            this.AnT.TabIndex = 0;
            this.AnT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AnT_KeyDown);
            // 
            // RenderTime
            // 
            this.RenderTime.Interval = 35;
            this.RenderTime.Tick += new System.EventHandler(this.RenderTime_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BackgroundImage = global::Arcan.Properties.Resources.bg32;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(34, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 45);
            this.panel1.TabIndex = 1;
            this.panel1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.panel1_PreviewKeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe Print", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Image = global::Arcan.Properties.Resources.bg32;
            this.label11.Location = new System.Drawing.Point(352, 420);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(631, 50);
            this.label11.TabIndex = 10;
            this.label11.Text = "Пробел - усиление мячика (1 раз за игру)";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox2.Location = new System.Drawing.Point(1248, 640);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(277, 47);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "Закрытые стенки";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            this.checkBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBox2_KeyDown);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.checkBox1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.Location = new System.Drawing.Point(1248, 559);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(179, 47);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "3Д режим";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBox1_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Image = global::Arcan.Properties.Resources.bg32;
            this.label7.Location = new System.Drawing.Point(843, 636);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(306, 50);
            this.label7.TabIndex = 7;
            this.label7.Text = "Количество блоков";
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.trackBar1.Location = new System.Drawing.Point(391, 689);
            this.trackBar1.Maximum = 7;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(385, 69);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 1;
            this.trackBar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trackBar1_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Print", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Image = global::Arcan.Properties.Resources.bg32;
            this.label6.Location = new System.Drawing.Point(554, 481);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 50);
            this.label6.TabIndex = 5;
            this.label6.Text = "Enter - пауза";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Image = global::Arcan.Properties.Resources.bg32;
            this.label4.Location = new System.Drawing.Point(809, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(303, 50);
            this.label4.TabIndex = 4;
            this.label4.Text = "D - быстро вправо";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Image = global::Arcan.Properties.Resources.bg32;
            this.label5.Location = new System.Drawing.Point(809, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(323, 50);
            this.label5.TabIndex = 3;
            this.label5.Text = "E - медленно вправо";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Image = global::Arcan.Properties.Resources.bg32;
            this.label3.Location = new System.Drawing.Point(228, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 50);
            this.label3.TabIndex = 2;
            this.label3.Text = "A - быстро влево";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Image = global::Arcan.Properties.Resources.bg32;
            this.label2.Location = new System.Drawing.Point(228, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 50);
            this.label2.TabIndex = 1;
            this.label2.Text = "Q - медленно влево";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Image = global::Arcan.Properties.Resources.bg32;
            this.label1.Location = new System.Drawing.Point(525, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Игра \"Арканоид\"";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(34, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(60, 56);
            this.panel2.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Arcan.Properties.Resources.bg32;
            this.button2.Font = new System.Drawing.Font("Segoe Print", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(40, 672);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(207, 104);
            this.button2.TabIndex = 10;
            this.button2.Text = "Еще раз";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe Print", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Image = global::Arcan.Properties.Resources.bg32;
            this.button1.Location = new System.Drawing.Point(1578, 632);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 104);
            this.button1.TabIndex = 9;
            this.button1.Text = "Выйти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe Print", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Image = global::Arcan.Properties.Resources.bg32;
            this.label8.Location = new System.Drawing.Point(670, 632);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(236, 91);
            this.label8.TabIndex = 8;
            this.label8.Text = "Победа!";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Arcan.Properties.Resources.bg32;
            this.pictureBox2.Image = global::Arcan.Properties.Resources.sm51;
            this.pictureBox2.Location = new System.Drawing.Point(20, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(456, 209);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Arcan.Properties.Resources.bg32;
            this.pictureBox1.Image = global::Arcan.Properties.Resources._7f90afdeabb41;
            this.pictureBox1.Location = new System.Drawing.Point(20, 233);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 209);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Font = new System.Drawing.Font("Segoe Print", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(621, 950);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(1054, 91);
            this.label10.TabIndex = 12;
            this.label10.Text = "Нажмите Enter, чтобы начать игру";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.BackgroundImage = global::Arcan.Properties.Resources.bg32;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(34, 121);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(49, 49);
            this.panel3.TabIndex = 11;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Segoe Print", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Image = global::Arcan.Properties.Resources.bg32;
            this.button5.Location = new System.Drawing.Point(171, 810);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(161, 104);
            this.button5.TabIndex = 12;
            this.button5.Text = "Еще раз";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe Print", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Image = global::Arcan.Properties.Resources.bg32;
            this.button3.Location = new System.Drawing.Point(1399, 777);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(189, 104);
            this.button3.TabIndex = 10;
            this.button3.Text = "Выйти";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Font = new System.Drawing.Font("Segoe Print", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Image = global::Arcan.Properties.Resources.bg32;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(12, 62);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label9.Size = new System.Drawing.Size(419, 91);
            this.label9.TabIndex = 9;
            this.label9.Text = "Вы проиграли";
            // 
            // labeltime
            // 
            this.labeltime.AutoSize = true;
            this.labeltime.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labeltime.Font = new System.Drawing.Font("Segoe Print", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labeltime.Image = global::Arcan.Properties.Resources.bg32;
            this.labeltime.Location = new System.Drawing.Point(25, 312);
            this.labeltime.Name = "labeltime";
            this.labeltime.Size = new System.Drawing.Size(315, 50);
            this.labeltime.TabIndex = 13;
            this.labeltime.Text = "замедление времени";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.labeltime);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AnT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl AnT;
        private System.Windows.Forms.Timer RenderTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label labeltime;
        private System.Windows.Forms.Label label11;
    }
}

