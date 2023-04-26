namespace Integration
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.xn = new System.Windows.Forms.TextBox();
            this.x0 = new System.Windows.Forms.TextBox();
            this.dx = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Func = new System.Windows.Forms.TextBox();
            this.I1 = new System.Windows.Forms.Label();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.Fx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Fy = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.S = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // xn
            // 
            this.xn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.xn.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xn.Location = new System.Drawing.Point(24, 12);
            this.xn.Name = "xn";
            this.xn.Size = new System.Drawing.Size(51, 50);
            this.xn.TabIndex = 69;
            this.xn.Text = "Pi/4";
            // 
            // x0
            // 
            this.x0.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.x0.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.x0.Location = new System.Drawing.Point(12, 161);
            this.x0.Name = "x0";
            this.x0.Size = new System.Drawing.Size(53, 50);
            this.x0.TabIndex = 68;
            this.x0.Text = "0";
            // 
            // dx
            // 
            this.dx.AutoSize = true;
            this.dx.Font = new System.Drawing.Font("Segoe Print", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dx.Location = new System.Drawing.Point(235, 76);
            this.dx.Name = "dx";
            this.dx.Size = new System.Drawing.Size(63, 57);
            this.dx.TabIndex = 67;
            this.dx.Text = "dx";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = global::Integration.Properties.Resources._638px_WPint_svg;
            this.pictureBox2.Location = new System.Drawing.Point(12, 65);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 90);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 70;
            this.pictureBox2.TabStop = false;
            // 
            // Func
            // 
            this.Func.BackColor = System.Drawing.Color.Snow;
            this.Func.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Func.Location = new System.Drawing.Point(81, 83);
            this.Func.Name = "Func";
            this.Func.Size = new System.Drawing.Size(148, 50);
            this.Func.TabIndex = 72;
            this.Func.Text = "x * cos(x)";
            this.Func.TextChanged += new System.EventHandler(this.Func_TextChanged);
            this.Func.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Func_KeyDown);
            // 
            // I1
            // 
            this.I1.AutoSize = true;
            this.I1.Font = new System.Drawing.Font("Segoe Print", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.I1.Location = new System.Drawing.Point(216, 371);
            this.I1.Name = "I1";
            this.I1.Size = new System.Drawing.Size(49, 57);
            this.I1.TabIndex = 73;
            this.I1.Text = "...";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(783, 12);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1128, 885);
            this.zedGraphControl1.TabIndex = 74;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 462);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(597, 520);
            this.dataGridView1.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(28, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 57);
            this.label1.TabIndex = 77;
            this.label1.Text = "Значение:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(105, 164);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(115, 47);
            this.radioButton1.TabIndex = 78;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Явная";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton2.Location = new System.Drawing.Point(245, 164);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(237, 47);
            this.radioButton2.TabIndex = 79;
            this.radioButton2.Text = "С параметром";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // Fx
            // 
            this.Fx.BackColor = System.Drawing.Color.Snow;
            this.Fx.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Fx.Location = new System.Drawing.Point(135, 234);
            this.Fx.Name = "Fx";
            this.Fx.Size = new System.Drawing.Size(148, 50);
            this.Fx.TabIndex = 80;
            this.Fx.Text = "t";
            this.Fx.TextChanged += new System.EventHandler(this.Fx_TextChanged);
            this.Fx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Fx_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 57);
            this.label2.TabIndex = 81;
            this.label2.Text = "x(t) =";
            // 
            // Fy
            // 
            this.Fy.BackColor = System.Drawing.Color.Snow;
            this.Fy.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Fy.Location = new System.Drawing.Point(135, 303);
            this.Fy.Name = "Fy";
            this.Fy.Size = new System.Drawing.Size(148, 50);
            this.Fy.TabIndex = 82;
            this.Fy.Text = "t * cos(t)";
            this.Fy.TextChanged += new System.EventHandler(this.Fy_TextChanged);
            this.Fy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Fy_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(14, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 57);
            this.label3.TabIndex = 83;
            this.label3.Text = "y(t) =";
            // 
            // S
            // 
            this.S.AutoSize = true;
            this.S.Checked = true;
            this.S.CheckState = System.Windows.Forms.CheckState.Checked;
            this.S.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.S.Location = new System.Drawing.Point(1572, 905);
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(313, 47);
            this.S.TabIndex = 84;
            this.S.Text = "Показывать площадь";
            this.S.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1924, 994);
            this.Controls.Add(this.S);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Fy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Fx);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.I1);
            this.Controls.Add(this.Func);
            this.Controls.Add(this.xn);
            this.Controls.Add(this.x0);
            this.Controls.Add(this.dx);
            this.Controls.Add(this.pictureBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Определенный интеграл";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox xn;
        private System.Windows.Forms.TextBox x0;
        public System.Windows.Forms.Label dx;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox Func;
        public System.Windows.Forms.Label I1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox Fx;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Fy;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox S;
    }
}

