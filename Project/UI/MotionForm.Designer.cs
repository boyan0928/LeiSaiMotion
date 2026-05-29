namespace Project.UI
{
    partial class MotionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MotionForm));
            this.label7 = new System.Windows.Forms.Label();
            this.Axis = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.S_Type = new System.Windows.Forms.RadioButton();
            this.T_Type = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CCW = new System.Windows.Forms.RadioButton();
            this.CW = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sdf = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.S_Tacc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Dist_pos = new System.Windows.Forms.TextBox();
            this.Tacc = new System.Windows.Forms.TextBox();
            this.Max_speed = new System.Windows.Forms.TextBox();
            this.Start_speed = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.Axis)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.sdf.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 74;
            this.label7.Text = "轴号选择：";
            // 
            // Axis
            // 
            this.Axis.Font = new System.Drawing.Font("新宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Axis.Location = new System.Drawing.Point(131, 17);
            this.Axis.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.Axis.Name = "Axis";
            this.Axis.Size = new System.Drawing.Size(62, 31);
            this.Axis.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 72;
            this.label3.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.S_Type);
            this.groupBox3.Controls.Add(this.T_Type);
            this.groupBox3.Location = new System.Drawing.Point(131, 279);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(99, 41);
            this.groupBox3.TabIndex = 71;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "速度曲线";
            // 
            // S_Type
            // 
            this.S_Type.AutoSize = true;
            this.S_Type.Location = new System.Drawing.Point(53, 20);
            this.S_Type.Name = "S_Type";
            this.S_Type.Size = new System.Drawing.Size(41, 16);
            this.S_Type.TabIndex = 1;
            this.S_Type.Text = "S型";
            this.S_Type.UseVisualStyleBackColor = true;
            this.S_Type.CheckedChanged += new System.EventHandler(this.S_Type_CheckedChanged);
            // 
            // T_Type
            // 
            this.T_Type.AutoSize = true;
            this.T_Type.Checked = true;
            this.T_Type.Location = new System.Drawing.Point(6, 20);
            this.T_Type.Name = "T_Type";
            this.T_Type.Size = new System.Drawing.Size(41, 16);
            this.T_Type.TabIndex = 0;
            this.T_Type.TabStop = true;
            this.T_Type.Text = "T型";
            this.T_Type.UseVisualStyleBackColor = true;
            this.T_Type.CheckedChanged += new System.EventHandler(this.T_Type_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CCW);
            this.groupBox4.Controls.Add(this.CW);
            this.groupBox4.Location = new System.Drawing.Point(15, 276);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(110, 44);
            this.groupBox4.TabIndex = 70;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "方向";
            // 
            // CCW
            // 
            this.CCW.AutoSize = true;
            this.CCW.Location = new System.Drawing.Point(58, 20);
            this.CCW.Name = "CCW";
            this.CCW.Size = new System.Drawing.Size(47, 16);
            this.CCW.TabIndex = 1;
            this.CCW.Text = "反向";
            this.CCW.UseVisualStyleBackColor = true;
            this.CCW.CheckedChanged += new System.EventHandler(this.CCW_CheckedChanged);
            // 
            // CW
            // 
            this.CW.AutoSize = true;
            this.CW.Checked = true;
            this.CW.Location = new System.Drawing.Point(6, 20);
            this.CW.Name = "CW";
            this.CW.Size = new System.Drawing.Size(47, 16);
            this.CW.TabIndex = 0;
            this.CW.TabStop = true;
            this.CW.Text = "正向";
            this.CW.UseVisualStyleBackColor = true;
            this.CW.CheckedChanged += new System.EventHandler(this.CW_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(265, 232);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(79, 35);
            this.button4.TabIndex = 69;
            this.button4.Text = "位置清零";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(265, 126);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 35);
            this.button3.TabIndex = 68;
            this.button3.Text = "急停";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(265, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 35);
            this.button2.TabIndex = 67;
            this.button2.Text = "减速停";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(265, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 35);
            this.button1.TabIndex = 66;
            this.button1.Text = "启动";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sdf
            // 
            this.sdf.Controls.Add(this.label6);
            this.sdf.Controls.Add(this.S_Tacc);
            this.sdf.Controls.Add(this.label5);
            this.sdf.Controls.Add(this.label4);
            this.sdf.Controls.Add(this.label8);
            this.sdf.Controls.Add(this.Dist_pos);
            this.sdf.Controls.Add(this.Tacc);
            this.sdf.Controls.Add(this.Max_speed);
            this.sdf.Controls.Add(this.Start_speed);
            this.sdf.Controls.Add(this.label9);
            this.sdf.Location = new System.Drawing.Point(22, 69);
            this.sdf.Name = "sdf";
            this.sdf.Size = new System.Drawing.Size(202, 201);
            this.sdf.TabIndex = 65;
            this.sdf.TabStop = false;
            this.sdf.Text = "参数设置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "S段比例：";
            // 
            // S_Tacc
            // 
            this.S_Tacc.Location = new System.Drawing.Point(81, 132);
            this.S_Tacc.Name = "S_Tacc";
            this.S_Tacc.Size = new System.Drawing.Size(73, 21);
            this.S_Tacc.TabIndex = 28;
            this.S_Tacc.Text = "0.05";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "定长位移：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "加速度：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "运行速度：";
            // 
            // Dist_pos
            // 
            this.Dist_pos.Location = new System.Drawing.Point(81, 163);
            this.Dist_pos.Name = "Dist_pos";
            this.Dist_pos.Size = new System.Drawing.Size(73, 21);
            this.Dist_pos.TabIndex = 22;
            this.Dist_pos.Text = "5000";
            // 
            // Tacc
            // 
            this.Tacc.Location = new System.Drawing.Point(81, 93);
            this.Tacc.Name = "Tacc";
            this.Tacc.Size = new System.Drawing.Size(73, 21);
            this.Tacc.TabIndex = 23;
            this.Tacc.Text = "100000";
            // 
            // Max_speed
            // 
            this.Max_speed.Location = new System.Drawing.Point(81, 57);
            this.Max_speed.Name = "Max_speed";
            this.Max_speed.Size = new System.Drawing.Size(73, 21);
            this.Max_speed.TabIndex = 24;
            this.Max_speed.Text = "2000";
            // 
            // Start_speed
            // 
            this.Start_speed.Location = new System.Drawing.Point(81, 20);
            this.Start_speed.Name = "Start_speed";
            this.Start_speed.Size = new System.Drawing.Size(73, 21);
            this.Start_speed.TabIndex = 21;
            this.Start_speed.Text = "200";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "初速度：";
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 399);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Axis);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sdf);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MotionForm";
            this.Text = "运动控制";
            ((System.ComponentModel.ISupportInitialize)(this.Axis)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.sdf.ResumeLayout(false);
            this.sdf.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown Axis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton S_Type;
        private System.Windows.Forms.RadioButton T_Type;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton CCW;
        private System.Windows.Forms.RadioButton CW;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox sdf;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox S_Tacc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Dist_pos;
        private System.Windows.Forms.TextBox Tacc;
        private System.Windows.Forms.TextBox Max_speed;
        private System.Windows.Forms.TextBox Start_speed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer1;
    }
}