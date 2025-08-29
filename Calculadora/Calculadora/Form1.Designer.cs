namespace Calculadora
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.screen_calculator = new System.Windows.Forms.TextBox();
            this.Bt0 = new System.Windows.Forms.Button();
            this.igualbt = new System.Windows.Forms.Button();
            this.reiniciobt = new System.Windows.Forms.Button();
            this.borrarbt = new System.Windows.Forms.Button();
            this.divbt = new System.Windows.Forms.Button();
            this.multbt = new System.Windows.Forms.Button();
            this.restbt = new System.Windows.Forms.Button();
            this.sumbt = new System.Windows.Forms.Button();
            this.puntobt = new System.Windows.Forms.Button();
            this.bt1 = new System.Windows.Forms.Button();
            this.bt2 = new System.Windows.Forms.Button();
            this.bt3 = new System.Windows.Forms.Button();
            this.bt6 = new System.Windows.Forms.Button();
            this.bt5 = new System.Windows.Forms.Button();
            this.bt4 = new System.Windows.Forms.Button();
            this.bt9 = new System.Windows.Forms.Button();
            this.bt8 = new System.Windows.Forms.Button();
            this.bt7 = new System.Windows.Forms.Button();
            this.Mmasbtn = new System.Windows.Forms.Button();
            this.expbtn = new System.Windows.Forms.Button();
            this.raizbtn = new System.Windows.Forms.Button();
            this.pibtn = new System.Windows.Forms.Button();
            this.Mmenosbtn = new System.Windows.Forms.Button();
            this.logbtn = new System.Windows.Forms.Button();
            this.MemoryClearbtn = new System.Windows.Forms.Button();
            this.Mrbton = new System.Windows.Forms.Button();
            this.FaCbtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.porcentajebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // screen_calculator
            // 
            this.screen_calculator.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screen_calculator.Location = new System.Drawing.Point(16, 15);
            this.screen_calculator.Margin = new System.Windows.Forms.Padding(4);
            this.screen_calculator.Multiline = true;
            this.screen_calculator.Name = "screen_calculator";
            this.screen_calculator.Size = new System.Drawing.Size(329, 53);
            this.screen_calculator.TabIndex = 0;
            this.screen_calculator.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.screen_calculator.TextChanged += new System.EventHandler(this.screen_calculator_TextChanged);
            // 
            // Bt0
            // 
            this.Bt0.BackColor = System.Drawing.SystemColors.Highlight;
            this.Bt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt0.Location = new System.Drawing.Point(16, 484);
            this.Bt0.Margin = new System.Windows.Forms.Padding(4);
            this.Bt0.Name = "Bt0";
            this.Bt0.Size = new System.Drawing.Size(131, 55);
            this.Bt0.TabIndex = 1;
            this.Bt0.Text = "0";
            this.Bt0.UseVisualStyleBackColor = false;
            this.Bt0.Click += new System.EventHandler(this.Bt0_Click);
            // 
            // igualbt
            // 
            this.igualbt.BackColor = System.Drawing.Color.DarkOrange;
            this.igualbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.igualbt.Location = new System.Drawing.Point(268, 400);
            this.igualbt.Margin = new System.Windows.Forms.Padding(4);
            this.igualbt.Name = "igualbt";
            this.igualbt.Size = new System.Drawing.Size(79, 139);
            this.igualbt.TabIndex = 2;
            this.igualbt.Text = "=";
            this.igualbt.UseVisualStyleBackColor = false;
            this.igualbt.Click += new System.EventHandler(this.Suma_Click);
            // 
            // reiniciobt
            // 
            this.reiniciobt.BackColor = System.Drawing.Color.Crimson;
            this.reiniciobt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reiniciobt.Location = new System.Drawing.Point(275, 335);
            this.reiniciobt.Margin = new System.Windows.Forms.Padding(4);
            this.reiniciobt.Name = "reiniciobt";
            this.reiniciobt.Size = new System.Drawing.Size(70, 57);
            this.reiniciobt.TabIndex = 3;
            this.reiniciobt.Text = "CE";
            this.reiniciobt.UseVisualStyleBackColor = false;
            this.reiniciobt.Click += new System.EventHandler(this.reiniciobt_Click);
            // 
            // borrarbt
            // 
            this.borrarbt.BackColor = System.Drawing.Color.Crimson;
            this.borrarbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borrarbt.Location = new System.Drawing.Point(275, 262);
            this.borrarbt.Margin = new System.Windows.Forms.Padding(4);
            this.borrarbt.Name = "borrarbt";
            this.borrarbt.Size = new System.Drawing.Size(64, 55);
            this.borrarbt.TabIndex = 4;
            this.borrarbt.Text = "BA";
            this.borrarbt.UseVisualStyleBackColor = false;
            this.borrarbt.Click += new System.EventHandler(this.borrarbt_Click);
            // 
            // divbt
            // 
            this.divbt.BackColor = System.Drawing.Color.Aquamarine;
            this.divbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.divbt.Location = new System.Drawing.Point(275, 89);
            this.divbt.Margin = new System.Windows.Forms.Padding(4);
            this.divbt.Name = "divbt";
            this.divbt.Size = new System.Drawing.Size(64, 49);
            this.divbt.TabIndex = 5;
            this.divbt.Text = "/";
            this.divbt.UseVisualStyleBackColor = false;
            this.divbt.Click += new System.EventHandler(this.divbt_Click);
            // 
            // multbt
            // 
            this.multbt.BackColor = System.Drawing.Color.Aquamarine;
            this.multbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multbt.Location = new System.Drawing.Point(221, 89);
            this.multbt.Margin = new System.Windows.Forms.Padding(4);
            this.multbt.Name = "multbt";
            this.multbt.Size = new System.Drawing.Size(57, 49);
            this.multbt.TabIndex = 6;
            this.multbt.Text = "*";
            this.multbt.UseVisualStyleBackColor = false;
            this.multbt.Click += new System.EventHandler(this.multbt_Click);
            // 
            // restbt
            // 
            this.restbt.BackColor = System.Drawing.Color.Aquamarine;
            this.restbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restbt.Location = new System.Drawing.Point(169, 89);
            this.restbt.Margin = new System.Windows.Forms.Padding(4);
            this.restbt.Name = "restbt";
            this.restbt.Size = new System.Drawing.Size(57, 49);
            this.restbt.TabIndex = 7;
            this.restbt.Text = "-";
            this.restbt.UseVisualStyleBackColor = false;
            this.restbt.Click += new System.EventHandler(this.restbt_Click);
            // 
            // sumbt
            // 
            this.sumbt.BackColor = System.Drawing.Color.Aquamarine;
            this.sumbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sumbt.Location = new System.Drawing.Point(119, 89);
            this.sumbt.Margin = new System.Windows.Forms.Padding(4);
            this.sumbt.Name = "sumbt";
            this.sumbt.Size = new System.Drawing.Size(57, 49);
            this.sumbt.TabIndex = 8;
            this.sumbt.Text = "+";
            this.sumbt.UseVisualStyleBackColor = false;
            this.sumbt.Click += new System.EventHandler(this.sumbt_Click);
            // 
            // puntobt
            // 
            this.puntobt.BackColor = System.Drawing.SystemColors.Highlight;
            this.puntobt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.puntobt.Location = new System.Drawing.Point(156, 484);
            this.puntobt.Margin = new System.Windows.Forms.Padding(4);
            this.puntobt.Name = "puntobt";
            this.puntobt.Size = new System.Drawing.Size(91, 55);
            this.puntobt.TabIndex = 9;
            this.puntobt.Text = ".";
            this.puntobt.UseVisualStyleBackColor = false;
            this.puntobt.Click += new System.EventHandler(this.puntobt_Click);
            // 
            // bt1
            // 
            this.bt1.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt1.Location = new System.Drawing.Point(16, 409);
            this.bt1.Margin = new System.Windows.Forms.Padding(4);
            this.bt1.Name = "bt1";
            this.bt1.Size = new System.Drawing.Size(63, 55);
            this.bt1.TabIndex = 10;
            this.bt1.Text = "1";
            this.bt1.UseVisualStyleBackColor = false;
            this.bt1.Click += new System.EventHandler(this.bt1_Click);
            // 
            // bt2
            // 
            this.bt2.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt2.Location = new System.Drawing.Point(99, 409);
            this.bt2.Margin = new System.Windows.Forms.Padding(4);
            this.bt2.Name = "bt2";
            this.bt2.Size = new System.Drawing.Size(63, 55);
            this.bt2.TabIndex = 11;
            this.bt2.Text = "2";
            this.bt2.UseVisualStyleBackColor = false;
            this.bt2.Click += new System.EventHandler(this.bt2_Click);
            // 
            // bt3
            // 
            this.bt3.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt3.Location = new System.Drawing.Point(184, 409);
            this.bt3.Margin = new System.Windows.Forms.Padding(4);
            this.bt3.Name = "bt3";
            this.bt3.Size = new System.Drawing.Size(63, 55);
            this.bt3.TabIndex = 12;
            this.bt3.Text = "3";
            this.bt3.UseVisualStyleBackColor = false;
            this.bt3.Click += new System.EventHandler(this.bt3_Click);
            // 
            // bt6
            // 
            this.bt6.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt6.Location = new System.Drawing.Point(184, 335);
            this.bt6.Margin = new System.Windows.Forms.Padding(4);
            this.bt6.Name = "bt6";
            this.bt6.Size = new System.Drawing.Size(63, 55);
            this.bt6.TabIndex = 13;
            this.bt6.Text = "6";
            this.bt6.UseVisualStyleBackColor = false;
            this.bt6.Click += new System.EventHandler(this.bt6_Click);
            // 
            // bt5
            // 
            this.bt5.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt5.Location = new System.Drawing.Point(99, 335);
            this.bt5.Margin = new System.Windows.Forms.Padding(4);
            this.bt5.Name = "bt5";
            this.bt5.Size = new System.Drawing.Size(63, 55);
            this.bt5.TabIndex = 14;
            this.bt5.Text = "5";
            this.bt5.UseVisualStyleBackColor = false;
            this.bt5.Click += new System.EventHandler(this.bt5_Click);
            // 
            // bt4
            // 
            this.bt4.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt4.Location = new System.Drawing.Point(16, 335);
            this.bt4.Margin = new System.Windows.Forms.Padding(4);
            this.bt4.Name = "bt4";
            this.bt4.Size = new System.Drawing.Size(63, 55);
            this.bt4.TabIndex = 15;
            this.bt4.Text = "4";
            this.bt4.UseVisualStyleBackColor = false;
            this.bt4.Click += new System.EventHandler(this.bt4_Click);
            // 
            // bt9
            // 
            this.bt9.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt9.Location = new System.Drawing.Point(184, 260);
            this.bt9.Margin = new System.Windows.Forms.Padding(4);
            this.bt9.Name = "bt9";
            this.bt9.Size = new System.Drawing.Size(63, 55);
            this.bt9.TabIndex = 16;
            this.bt9.Text = "9";
            this.bt9.UseVisualStyleBackColor = false;
            this.bt9.Click += new System.EventHandler(this.bt9_Click);
            // 
            // bt8
            // 
            this.bt8.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt8.Location = new System.Drawing.Point(99, 260);
            this.bt8.Margin = new System.Windows.Forms.Padding(4);
            this.bt8.Name = "bt8";
            this.bt8.Size = new System.Drawing.Size(63, 55);
            this.bt8.TabIndex = 17;
            this.bt8.Text = "8";
            this.bt8.UseVisualStyleBackColor = false;
            this.bt8.Click += new System.EventHandler(this.bt8_Click);
            // 
            // bt7
            // 
            this.bt7.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt7.Location = new System.Drawing.Point(16, 260);
            this.bt7.Margin = new System.Windows.Forms.Padding(4);
            this.bt7.Name = "bt7";
            this.bt7.Size = new System.Drawing.Size(63, 55);
            this.bt7.TabIndex = 18;
            this.bt7.Text = "7";
            this.bt7.UseVisualStyleBackColor = false;
            this.bt7.Click += new System.EventHandler(this.bt7_Click);
            // 
            // Mmasbtn
            // 
            this.Mmasbtn.BackColor = System.Drawing.Color.Chartreuse;
            this.Mmasbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mmasbtn.Location = new System.Drawing.Point(275, 197);
            this.Mmasbtn.Margin = new System.Windows.Forms.Padding(4);
            this.Mmasbtn.Name = "Mmasbtn";
            this.Mmasbtn.Size = new System.Drawing.Size(64, 55);
            this.Mmasbtn.TabIndex = 19;
            this.Mmasbtn.Text = "M+";
            this.Mmasbtn.UseVisualStyleBackColor = false;
            this.Mmasbtn.Click += new System.EventHandler(this.Mmasbtn_Click);
            // 
            // expbtn
            // 
            this.expbtn.BackColor = System.Drawing.Color.Aquamarine;
            this.expbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expbtn.Location = new System.Drawing.Point(119, 145);
            this.expbtn.Margin = new System.Windows.Forms.Padding(4);
            this.expbtn.Name = "expbtn";
            this.expbtn.Size = new System.Drawing.Size(57, 49);
            this.expbtn.TabIndex = 20;
            this.expbtn.Text = "^";
            this.expbtn.UseVisualStyleBackColor = false;
            this.expbtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // raizbtn
            // 
            this.raizbtn.BackColor = System.Drawing.Color.Aquamarine;
            this.raizbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raizbtn.Location = new System.Drawing.Point(169, 145);
            this.raizbtn.Margin = new System.Windows.Forms.Padding(4);
            this.raizbtn.Name = "raizbtn";
            this.raizbtn.Size = new System.Drawing.Size(57, 49);
            this.raizbtn.TabIndex = 21;
            this.raizbtn.Text = "√";
            this.raizbtn.UseVisualStyleBackColor = false;
            this.raizbtn.Click += new System.EventHandler(this.raizbtn_Click);
            // 
            // pibtn
            // 
            this.pibtn.BackColor = System.Drawing.Color.Aquamarine;
            this.pibtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pibtn.Location = new System.Drawing.Point(221, 145);
            this.pibtn.Margin = new System.Windows.Forms.Padding(4);
            this.pibtn.Name = "pibtn";
            this.pibtn.Size = new System.Drawing.Size(57, 49);
            this.pibtn.TabIndex = 22;
            this.pibtn.Text = "π ";
            this.pibtn.UseVisualStyleBackColor = false;
            this.pibtn.Click += new System.EventHandler(this.pibtn_Click);
            // 
            // Mmenosbtn
            // 
            this.Mmenosbtn.BackColor = System.Drawing.Color.Chartreuse;
            this.Mmenosbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mmenosbtn.Location = new System.Drawing.Point(275, 145);
            this.Mmenosbtn.Margin = new System.Windows.Forms.Padding(4);
            this.Mmenosbtn.Name = "Mmenosbtn";
            this.Mmenosbtn.Size = new System.Drawing.Size(64, 49);
            this.Mmenosbtn.TabIndex = 23;
            this.Mmenosbtn.Text = "M-";
            this.Mmenosbtn.UseVisualStyleBackColor = false;
            this.Mmenosbtn.Click += new System.EventHandler(this.Mmenosbtn_Click);
            // 
            // logbtn
            // 
            this.logbtn.BackColor = System.Drawing.Color.Bisque;
            this.logbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logbtn.Location = new System.Drawing.Point(16, 209);
            this.logbtn.Margin = new System.Windows.Forms.Padding(4);
            this.logbtn.Name = "logbtn";
            this.logbtn.Size = new System.Drawing.Size(88, 39);
            this.logbtn.TabIndex = 24;
            this.logbtn.Text = "LOG";
            this.logbtn.UseVisualStyleBackColor = false;
            this.logbtn.Click += new System.EventHandler(this.logbtn_Click);
            // 
            // MemoryClearbtn
            // 
            this.MemoryClearbtn.BackColor = System.Drawing.Color.Chartreuse;
            this.MemoryClearbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemoryClearbtn.Location = new System.Drawing.Point(131, 197);
            this.MemoryClearbtn.Margin = new System.Windows.Forms.Padding(4);
            this.MemoryClearbtn.Name = "MemoryClearbtn";
            this.MemoryClearbtn.Size = new System.Drawing.Size(64, 55);
            this.MemoryClearbtn.TabIndex = 25;
            this.MemoryClearbtn.Text = "MC";
            this.MemoryClearbtn.UseVisualStyleBackColor = false;
            this.MemoryClearbtn.Click += new System.EventHandler(this.MemoryClearbtn_Click);
            // 
            // Mrbton
            // 
            this.Mrbton.BackColor = System.Drawing.Color.Chartreuse;
            this.Mrbton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mrbton.Location = new System.Drawing.Point(203, 197);
            this.Mrbton.Margin = new System.Windows.Forms.Padding(4);
            this.Mrbton.Name = "Mrbton";
            this.Mrbton.Size = new System.Drawing.Size(64, 55);
            this.Mrbton.TabIndex = 26;
            this.Mrbton.Text = "MR";
            this.Mrbton.UseVisualStyleBackColor = false;
            this.Mrbton.Click += new System.EventHandler(this.Mrbton_Click);
            // 
            // FaCbtn
            // 
            this.FaCbtn.BackColor = System.Drawing.Color.Bisque;
            this.FaCbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FaCbtn.Location = new System.Drawing.Point(16, 174);
            this.FaCbtn.Margin = new System.Windows.Forms.Padding(4);
            this.FaCbtn.Name = "FaCbtn";
            this.FaCbtn.Size = new System.Drawing.Size(88, 39);
            this.FaCbtn.TabIndex = 27;
            this.FaCbtn.Text = "F = C";
            this.FaCbtn.UseVisualStyleBackColor = false;
            this.FaCbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Bisque;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(16, 145);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 39);
            this.button2.TabIndex = 28;
            this.button2.Text = "C = F";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Aquamarine;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(67, 89);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(57, 49);
            this.button3.TabIndex = 29;
            this.button3.Text = "!";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // porcentajebtn
            // 
            this.porcentajebtn.BackColor = System.Drawing.Color.Aquamarine;
            this.porcentajebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.porcentajebtn.Location = new System.Drawing.Point(16, 89);
            this.porcentajebtn.Margin = new System.Windows.Forms.Padding(4);
            this.porcentajebtn.Name = "porcentajebtn";
            this.porcentajebtn.Size = new System.Drawing.Size(57, 49);
            this.porcentajebtn.TabIndex = 30;
            this.porcentajebtn.Text = "%";
            this.porcentajebtn.UseVisualStyleBackColor = false;
            this.porcentajebtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(361, 554);
            this.Controls.Add(this.porcentajebtn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.FaCbtn);
            this.Controls.Add(this.Mrbton);
            this.Controls.Add(this.MemoryClearbtn);
            this.Controls.Add(this.logbtn);
            this.Controls.Add(this.Mmenosbtn);
            this.Controls.Add(this.pibtn);
            this.Controls.Add(this.raizbtn);
            this.Controls.Add(this.expbtn);
            this.Controls.Add(this.Mmasbtn);
            this.Controls.Add(this.bt7);
            this.Controls.Add(this.bt8);
            this.Controls.Add(this.bt9);
            this.Controls.Add(this.bt4);
            this.Controls.Add(this.bt5);
            this.Controls.Add(this.bt6);
            this.Controls.Add(this.bt3);
            this.Controls.Add(this.bt2);
            this.Controls.Add(this.bt1);
            this.Controls.Add(this.puntobt);
            this.Controls.Add(this.sumbt);
            this.Controls.Add(this.restbt);
            this.Controls.Add(this.multbt);
            this.Controls.Add(this.divbt);
            this.Controls.Add(this.borrarbt);
            this.Controls.Add(this.reiniciobt);
            this.Controls.Add(this.igualbt);
            this.Controls.Add(this.Bt0);
            this.Controls.Add(this.screen_calculator);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Calculador Allam PV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox screen_calculator;
        private System.Windows.Forms.Button Bt0;
        private System.Windows.Forms.Button igualbt;
        private System.Windows.Forms.Button reiniciobt;
        private System.Windows.Forms.Button borrarbt;
        private System.Windows.Forms.Button divbt;
        private System.Windows.Forms.Button multbt;
        private System.Windows.Forms.Button restbt;
        private System.Windows.Forms.Button sumbt;
        private System.Windows.Forms.Button puntobt;
        private System.Windows.Forms.Button bt1;
        private System.Windows.Forms.Button bt2;
        private System.Windows.Forms.Button bt3;
        private System.Windows.Forms.Button bt6;
        private System.Windows.Forms.Button bt5;
        private System.Windows.Forms.Button bt4;
        private System.Windows.Forms.Button bt9;
        private System.Windows.Forms.Button bt8;
        private System.Windows.Forms.Button bt7;
        private System.Windows.Forms.Button Mmasbtn;
        private System.Windows.Forms.Button expbtn;
        private System.Windows.Forms.Button raizbtn;
        private System.Windows.Forms.Button pibtn;
        private System.Windows.Forms.Button Mmenosbtn;
        private System.Windows.Forms.Button logbtn;
        private System.Windows.Forms.Button MemoryClearbtn;
        private System.Windows.Forms.Button Mrbton;
        private System.Windows.Forms.Button FaCbtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button porcentajebtn;
    }
}

