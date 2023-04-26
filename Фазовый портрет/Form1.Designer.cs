namespace Phase_picture
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
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.Calculate = new System.Windows.Forms.Button();
            this.PhaseGraph = new ZedGraph.ZedGraphControl();
            this.textBoxTn = new System.Windows.Forms.TextBox();
            this.textBoxT0 = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.labelT0 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.hX0 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maxX0 = new System.Windows.Forms.TextBox();
            this.minX0 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelX0 = new System.Windows.Forms.Label();
            this.hY0 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.maxY0 = new System.Windows.Forms.TextBox();
            this.minY0 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelY0 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX.Location = new System.Drawing.Point(20, 14);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(72, 43);
            this.labelX.TabIndex = 0;
            this.labelX.Text = "ẋ = ";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelY.Location = new System.Drawing.Point(20, 79);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(72, 43);
            this.labelY.TabIndex = 1;
            this.labelY.Text = "ẏ = ";
            // 
            // textBoxX
            // 
            this.textBoxX.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxX.Location = new System.Drawing.Point(98, 14);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(293, 50);
            this.textBoxX.TabIndex = 2;
            this.textBoxX.Leave += new System.EventHandler(this.textBoxX_Leave);
            // 
            // textBoxY
            // 
            this.textBoxY.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxY.Location = new System.Drawing.Point(98, 76);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(293, 50);
            this.textBoxY.TabIndex = 3;
            this.textBoxY.Leave += new System.EventHandler(this.textBoxY_Leave);
            // 
            // Calculate
            // 
            this.Calculate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Calculate.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Calculate.Location = new System.Drawing.Point(368, 183);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(200, 91);
            this.Calculate.TabIndex = 4;
            this.Calculate.Text = "Построить";
            this.Calculate.UseVisualStyleBackColor = false;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // PhaseGraph
            // 
            this.PhaseGraph.Location = new System.Drawing.Point(677, 14);
            this.PhaseGraph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PhaseGraph.Name = "PhaseGraph";
            this.PhaseGraph.ScrollGrace = 0D;
            this.PhaseGraph.ScrollMaxX = 0D;
            this.PhaseGraph.ScrollMaxY = 0D;
            this.PhaseGraph.ScrollMaxY2 = 0D;
            this.PhaseGraph.ScrollMinX = 0D;
            this.PhaseGraph.ScrollMinY = 0D;
            this.PhaseGraph.ScrollMinY2 = 0D;
            this.PhaseGraph.Size = new System.Drawing.Size(1234, 966);
            this.PhaseGraph.TabIndex = 5;
            // 
            // textBoxTn
            // 
            this.textBoxTn.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTn.Location = new System.Drawing.Point(161, 190);
            this.textBoxTn.Name = "textBoxTn";
            this.textBoxTn.Size = new System.Drawing.Size(46, 50);
            this.textBoxTn.TabIndex = 17;
            this.textBoxTn.Text = "15";
            // 
            // textBoxT0
            // 
            this.textBoxT0.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxT0.Location = new System.Drawing.Point(92, 190);
            this.textBoxT0.Name = "textBoxT0";
            this.textBoxT0.Size = new System.Drawing.Size(46, 50);
            this.textBoxT0.TabIndex = 16;
            this.textBoxT0.Text = "0";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(139, 197);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(27, 43);
            this.label.TabIndex = 15;
            this.label.Text = ",";
            // 
            // labelT0
            // 
            this.labelT0.AutoSize = true;
            this.labelT0.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelT0.Location = new System.Drawing.Point(35, 193);
            this.labelT0.Name = "labelT0";
            this.labelT0.Size = new System.Drawing.Size(57, 43);
            this.labelT0.TabIndex = 14;
            this.labelT0.Text = "t: [";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(213, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 43);
            this.label4.TabIndex = 18;
            this.label4.Text = "]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(35, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 43);
            this.label1.TabIndex = 19;
            this.label1.Text = "Шагов: ";
            // 
            // textBoxN
            // 
            this.textBoxN.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxN.Location = new System.Drawing.Point(158, 290);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(136, 50);
            this.textBoxN.TabIndex = 20;
            this.textBoxN.Text = "150";
            // 
            // hX0
            // 
            this.hX0.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hX0.Location = new System.Drawing.Point(380, 495);
            this.hX0.Name = "hX0";
            this.hX0.Size = new System.Drawing.Size(46, 50);
            this.hX0.TabIndex = 32;
            this.hX0.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(275, 495);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 43);
            this.label2.TabIndex = 31;
            this.label2.Text = "], шаг: ";
            // 
            // maxX0
            // 
            this.maxX0.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxX0.Location = new System.Drawing.Point(207, 492);
            this.maxX0.Name = "maxX0";
            this.maxX0.Size = new System.Drawing.Size(63, 50);
            this.maxX0.TabIndex = 30;
            this.maxX0.Text = "10";
            // 
            // minX0
            // 
            this.minX0.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minX0.Location = new System.Drawing.Point(127, 492);
            this.minX0.Name = "minX0";
            this.minX0.Size = new System.Drawing.Size(63, 50);
            this.minX0.TabIndex = 29;
            this.minX0.Text = "-10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(183, 499);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 43);
            this.label3.TabIndex = 28;
            this.label3.Text = ",";
            // 
            // labelX0
            // 
            this.labelX0.AutoSize = true;
            this.labelX0.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX0.Location = new System.Drawing.Point(46, 495);
            this.labelX0.Name = "labelX0";
            this.labelX0.Size = new System.Drawing.Size(76, 43);
            this.labelX0.TabIndex = 27;
            this.labelX0.Text = "x0: [";
            // 
            // hY0
            // 
            this.hY0.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hY0.Location = new System.Drawing.Point(380, 563);
            this.hY0.Name = "hY0";
            this.hY0.Size = new System.Drawing.Size(46, 50);
            this.hY0.TabIndex = 38;
            this.hY0.Text = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(275, 563);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 43);
            this.label6.TabIndex = 37;
            this.label6.Text = "], шаг: ";
            // 
            // maxY0
            // 
            this.maxY0.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxY0.Location = new System.Drawing.Point(207, 563);
            this.maxY0.Name = "maxY0";
            this.maxY0.Size = new System.Drawing.Size(63, 50);
            this.maxY0.TabIndex = 36;
            this.maxY0.Text = "10";
            // 
            // minY0
            // 
            this.minY0.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minY0.Location = new System.Drawing.Point(127, 563);
            this.minY0.Name = "minY0";
            this.minY0.Size = new System.Drawing.Size(63, 50);
            this.minY0.TabIndex = 35;
            this.minY0.Text = "-10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(183, 567);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 43);
            this.label7.TabIndex = 34;
            this.label7.Text = ",";
            // 
            // labelY0
            // 
            this.labelY0.AutoSize = true;
            this.labelY0.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelY0.Location = new System.Drawing.Point(44, 563);
            this.labelY0.Name = "labelY0";
            this.labelY0.Size = new System.Drawing.Size(77, 43);
            this.labelY0.TabIndex = 33;
            this.labelY0.Text = "y0: [";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.hY0);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maxY0);
            this.Controls.Add(this.minY0);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelY0);
            this.Controls.Add(this.hX0);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxX0);
            this.Controls.Add(this.minX0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelX0);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PhaseGraph);
            this.Controls.Add(this.textBoxN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.textBoxTn);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.textBoxT0);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.label);
            this.Controls.Add(this.labelT0);
            this.Name = "Form1";
            this.Text = "Фазовый портрет";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Button Calculate;
        private ZedGraph.ZedGraphControl PhaseGraph;
        private System.Windows.Forms.TextBox textBoxTn;
        private System.Windows.Forms.TextBox textBoxT0;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelT0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.TextBox hX0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maxX0;
        private System.Windows.Forms.TextBox minX0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelX0;
        private System.Windows.Forms.TextBox hY0;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox maxY0;
        private System.Windows.Forms.TextBox minY0;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelY0;
    }
}

