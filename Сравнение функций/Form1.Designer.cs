namespace Functions
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
            this.zed = new ZedGraph.ZedGraphControl();
            this.F = new System.Windows.Forms.TextBox();
            this.G = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Calculate = new System.Windows.Forms.Button();
            this.A = new System.Windows.Forms.TextBox();
            this.B = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Eps = new System.Windows.Forms.Label();
            this.zedEps = new ZedGraph.ZedGraphControl();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zed
            // 
            this.zed.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.zed.Location = new System.Drawing.Point(738, 14);
            this.zed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zed.Name = "zed";
            this.zed.ScrollGrace = 0D;
            this.zed.ScrollMaxX = 0D;
            this.zed.ScrollMaxY = 0D;
            this.zed.ScrollMaxY2 = 0D;
            this.zed.ScrollMinX = 0D;
            this.zed.ScrollMinY = 0D;
            this.zed.ScrollMinY2 = 0D;
            this.zed.Size = new System.Drawing.Size(1173, 847);
            this.zed.TabIndex = 0;
            // 
            // F
            // 
            this.F.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.F.Location = new System.Drawing.Point(113, 7);
            this.F.Name = "F";
            this.F.Size = new System.Drawing.Size(334, 50);
            this.F.TabIndex = 1;
            this.F.Text = "x^2";
            // 
            // G
            // 
            this.G.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.G.Location = new System.Drawing.Point(113, 83);
            this.G.Name = "G";
            this.G.Size = new System.Drawing.Size(334, 50);
            this.G.TabIndex = 2;
            this.G.Text = "x^3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 43);
            this.label1.TabIndex = 3;
            this.label1.Text = "f(x) = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 43);
            this.label2.TabIndex = 4;
            this.label2.Text = "g(x) = ";
            // 
            // Calculate
            // 
            this.Calculate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Calculate.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Calculate.Location = new System.Drawing.Point(482, 44);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(226, 70);
            this.Calculate.TabIndex = 5;
            this.Calculate.Text = "Вычислить";
            this.Calculate.UseVisualStyleBackColor = false;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // A
            // 
            this.A.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.A.Location = new System.Drawing.Point(145, 162);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(75, 50);
            this.A.TabIndex = 6;
            this.A.Text = "0";
            // 
            // B
            // 
            this.B.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B.Location = new System.Drawing.Point(363, 162);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(75, 50);
            this.B.TabIndex = 7;
            this.B.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(71, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 43);
            this.label3.TabIndex = 8;
            this.label3.Text = "a = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(289, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 43);
            this.label4.TabIndex = 9;
            this.label4.Text = "b = ";
            // 
            // Eps
            // 
            this.Eps.AutoSize = true;
            this.Eps.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Eps.Location = new System.Drawing.Point(12, 260);
            this.Eps.Name = "Eps";
            this.Eps.Size = new System.Drawing.Size(253, 43);
            this.Eps.TabIndex = 10;
            this.Eps.Text = "max|f(x) - g(x)| =  ";
            // 
            // zedEps
            // 
            this.zedEps.Location = new System.Drawing.Point(2, 317);
            this.zedEps.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedEps.Name = "zedEps";
            this.zedEps.ScrollGrace = 0D;
            this.zedEps.ScrollMaxX = 0D;
            this.zedEps.ScrollMaxY = 0D;
            this.zedEps.ScrollMaxY2 = 0D;
            this.zedEps.ScrollMinX = 0D;
            this.zedEps.ScrollMinY = 0D;
            this.zedEps.ScrollMinY2 = 0D;
            this.zedEps.Size = new System.Drawing.Size(728, 544);
            this.zedEps.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(174, 876);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(296, 43);
            this.label5.TabIndex = 12;
            this.label5.Text = "График погрешности";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(1264, 876);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(244, 43);
            this.label6.TabIndex = 13;
            this.label6.Text = "График функций ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.zedEps);
            this.Controls.Add(this.Eps);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.B);
            this.Controls.Add(this.A);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.G);
            this.Controls.Add(this.F);
            this.Controls.Add(this.zed);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Сравнение функций";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zed;
        private System.Windows.Forms.TextBox F;
        private System.Windows.Forms.TextBox G;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.TextBox A;
        private System.Windows.Forms.TextBox B;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Eps;
        private ZedGraph.ZedGraphControl zedEps;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

