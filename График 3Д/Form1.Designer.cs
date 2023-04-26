namespace Graph3D
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.A = new System.Windows.Forms.TextBox();
            this.B = new System.Windows.Forms.TextBox();
            this.D = new System.Windows.Forms.TextBox();
            this.C = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Func = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьНаборТочекToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьНаборТочекToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox = new System.Windows.Forms.ToolStripComboBox();
            this.шагToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.H = new System.Windows.Forms.ToolStripTextBox();
            this.цветToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorBox = new System.Windows.Forms.ToolStripComboBox();
            this.функцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FuncBox = new System.Windows.Forms.ToolStripComboBox();
            this.FuncX = new System.Windows.Forms.TextBox();
            this.FuncY = new System.Windows.Forms.TextBox();
            this.FuncZ = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
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
            this.AnT.Location = new System.Drawing.Point(12, 42);
            this.AnT.Name = "AnT";
            this.AnT.Size = new System.Drawing.Size(1900, 949);
            this.AnT.StencilBits = ((byte)(0));
            this.AnT.TabIndex = 0;
            this.AnT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AnT_KeyDown);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox.Location = new System.Drawing.Point(363, 2);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(76, 35);
            this.checkBox.TabIndex = 1;
            this.checkBox.Text = "Оси";
            this.checkBox.UseVisualStyleBackColor = false;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // A
            // 
            this.A.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.A.Location = new System.Drawing.Point(1664, 197);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(70, 50);
            this.A.TabIndex = 3;
            this.A.Text = "-1";
            this.A.Leave += new System.EventHandler(this.A_Leave);
            // 
            // B
            // 
            this.B.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B.Location = new System.Drawing.Point(1759, 197);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(70, 50);
            this.B.TabIndex = 4;
            this.B.Text = "1";
            this.B.Leave += new System.EventHandler(this.B_Leave);
            // 
            // D
            // 
            this.D.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.D.Location = new System.Drawing.Point(1759, 293);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(70, 50);
            this.D.TabIndex = 6;
            this.D.Text = "1";
            this.D.Leave += new System.EventHandler(this.D_Leave);
            // 
            // C
            // 
            this.C.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.C.Location = new System.Drawing.Point(1664, 293);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(70, 50);
            this.C.TabIndex = 5;
            this.C.Text = "-1";
            this.C.Leave += new System.EventHandler(this.C_Leave);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX.Location = new System.Drawing.Point(1608, 200);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(64, 43);
            this.labelX.TabIndex = 7;
            this.labelX.Text = "X: [";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelY.Location = new System.Drawing.Point(1608, 293);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(62, 43);
            this.labelY.TabIndex = 8;
            this.labelY.Text = "Y: [";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1735, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 43);
            this.label1.TabIndex = 9;
            this.label1.Text = ",";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1835, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 43);
            this.label2.TabIndex = 10;
            this.label2.Text = "]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1835, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 43);
            this.label3.TabIndex = 11;
            this.label3.Text = "]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1735, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 43);
            this.label4.TabIndex = 12;
            this.label4.Text = ",";
            // 
            // Func
            // 
            this.Func.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Func.Location = new System.Drawing.Point(1599, 105);
            this.Func.Name = "Func";
            this.Func.Size = new System.Drawing.Size(267, 50);
            this.Func.TabIndex = 15;
            this.Func.Text = "1-x^2-y^2";
            this.Func.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Func_KeyDown);
            this.Func.Leave += new System.EventHandler(this.Func_Leave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.отображениеToolStripMenuItem,
            this.функцияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 39);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.открытьНаборТочекToolStripMenuItem,
            this.сохранитьНаборТочекToolStripMenuItem});
            this.файлToolStripMenuItem.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(75, 35);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(331, 36);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(331, 36);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // открытьНаборТочекToolStripMenuItem
            // 
            this.открытьНаборТочекToolStripMenuItem.Name = "открытьНаборТочекToolStripMenuItem";
            this.открытьНаборТочекToolStripMenuItem.Size = new System.Drawing.Size(331, 36);
            this.открытьНаборТочекToolStripMenuItem.Text = "Открыть набор точек";
            this.открытьНаборТочекToolStripMenuItem.Click += new System.EventHandler(this.открытьНаборТочекToolStripMenuItem_Click);
            // 
            // сохранитьНаборТочекToolStripMenuItem
            // 
            this.сохранитьНаборТочекToolStripMenuItem.Name = "сохранитьНаборТочекToolStripMenuItem";
            this.сохранитьНаборТочекToolStripMenuItem.Size = new System.Drawing.Size(331, 36);
            this.сохранитьНаборТочекToolStripMenuItem.Text = "Сохранить набор точек";
            this.сохранитьНаборТочекToolStripMenuItem.Click += new System.EventHandler(this.сохранитьНаборТочекToolStripMenuItem_Click);
            // 
            // отображениеToolStripMenuItem
            // 
            this.отображениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comboBox,
            this.шагToolStripMenuItem,
            this.цветToolStripMenuItem});
            this.отображениеToolStripMenuItem.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.отображениеToolStripMenuItem.Name = "отображениеToolStripMenuItem";
            this.отображениеToolStripMenuItem.Size = new System.Drawing.Size(158, 35);
            this.отображениеToolStripMenuItem.Text = "Отображение";
            // 
            // comboBox
            // 
            this.comboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Точки",
            "Сетка",
            "Полигоны"});
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox.Items.AddRange(new object[] {
            "Точки",
            "Сетка",
            "Полигоны"});
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 39);
            this.comboBox.DropDownClosed += new System.EventHandler(this.comboBox_DropDownClosed);
            // 
            // шагToolStripMenuItem
            // 
            this.шагToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.H});
            this.шагToolStripMenuItem.Name = "шагToolStripMenuItem";
            this.шагToolStripMenuItem.Size = new System.Drawing.Size(193, 36);
            this.шагToolStripMenuItem.Text = "Шаг";
            this.шагToolStripMenuItem.DropDownClosed += new System.EventHandler(this.шагToolStripMenuItem_DropDownClosed);
            // 
            // H
            // 
            this.H.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.H.Name = "H";
            this.H.Size = new System.Drawing.Size(100, 39);
            this.H.Text = "0,05";
            // 
            // цветToolStripMenuItem
            // 
            this.цветToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorBox});
            this.цветToolStripMenuItem.Name = "цветToolStripMenuItem";
            this.цветToolStripMenuItem.Size = new System.Drawing.Size(193, 36);
            this.цветToolStripMenuItem.Text = "Цвет";
            // 
            // ColorBox
            // 
            this.ColorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColorBox.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ColorBox.Items.AddRange(new object[] {
            "Градиент 1",
            "Градиент 2",
            "Градиент 3",
            "Градиент 4",
            "Градиент 5"});
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.Size = new System.Drawing.Size(121, 39);
            this.ColorBox.DropDownClosed += new System.EventHandler(this.ColorBox_DropDownClosed);
            // 
            // функцияToolStripMenuItem
            // 
            this.функцияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FuncBox});
            this.функцияToolStripMenuItem.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.функцияToolStripMenuItem.Name = "функцияToolStripMenuItem";
            this.функцияToolStripMenuItem.Size = new System.Drawing.Size(107, 35);
            this.функцияToolStripMenuItem.Text = "Функция";
            // 
            // FuncBox
            // 
            this.FuncBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FuncBox.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FuncBox.Items.AddRange(new object[] {
            "Явная",
            "Параметрическая"});
            this.FuncBox.Name = "FuncBox";
            this.FuncBox.Size = new System.Drawing.Size(121, 39);
            this.FuncBox.DropDownClosed += new System.EventHandler(this.FuncBox_DropDownClosed);
            // 
            // FuncX
            // 
            this.FuncX.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FuncX.Location = new System.Drawing.Point(1599, 412);
            this.FuncX.Name = "FuncX";
            this.FuncX.Size = new System.Drawing.Size(267, 50);
            this.FuncX.TabIndex = 17;
            this.FuncX.Text = "sin(u)*cos(v)";
            this.FuncX.Visible = false;
            this.FuncX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FuncX_KeyDown);
            // 
            // FuncY
            // 
            this.FuncY.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FuncY.Location = new System.Drawing.Point(1599, 484);
            this.FuncY.Name = "FuncY";
            this.FuncY.Size = new System.Drawing.Size(267, 50);
            this.FuncY.TabIndex = 18;
            this.FuncY.Text = "sin(u)*sin(v)";
            this.FuncY.Visible = false;
            this.FuncY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FuncY_KeyDown);
            // 
            // FuncZ
            // 
            this.FuncZ.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FuncZ.Location = new System.Drawing.Point(1599, 556);
            this.FuncZ.Name = "FuncZ";
            this.FuncZ.Size = new System.Drawing.Size(267, 50);
            this.FuncZ.TabIndex = 19;
            this.FuncZ.Text = "cos(u)";
            this.FuncZ.Visible = false;
            this.FuncZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FuncZ_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.FuncZ);
            this.Controls.Add(this.FuncY);
            this.Controls.Add(this.FuncX);
            this.Controls.Add(this.Func);
            this.Controls.Add(this.A);
            this.Controls.Add(this.D);
            this.Controls.Add(this.C);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.B);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.AnT);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Трехмерный график";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl AnT;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.TextBox A;
        private System.Windows.Forms.TextBox B;
        private System.Windows.Forms.TextBox D;
        private System.Windows.Forms.TextBox C;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Func;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem отображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox comboBox;
        private System.Windows.Forms.ToolStripMenuItem шагToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox H;
        private System.Windows.Forms.ToolStripMenuItem цветToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox ColorBox;
        private System.Windows.Forms.TextBox FuncX;
        private System.Windows.Forms.TextBox FuncY;
        private System.Windows.Forms.TextBox FuncZ;
        private System.Windows.Forms.ToolStripMenuItem функцияToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox FuncBox;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьНаборТочекToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьНаборТочекToolStripMenuItem;
    }
}

