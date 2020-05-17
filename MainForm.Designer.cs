namespace RayTracing
{
    partial class MainForm
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
            this.tbPosX = new System.Windows.Forms.TrackBar();
            this.tbPosY = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioCamera = new System.Windows.Forms.RadioButton();
            this.radioLight = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAddCube = new System.Windows.Forms.Button();
            this.textCubePosX = new System.Windows.Forms.TextBox();
            this.textCubePosY = new System.Windows.Forms.TextBox();
            this.textCubePosZ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboColor = new System.Windows.Forms.ComboBox();
            this.comboSize = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.trackRayTrDepth = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPosY)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackRayTrDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPosX
            // 
            this.tbPosX.Location = new System.Drawing.Point(12, 613);
            this.tbPosX.Maximum = 50;
            this.tbPosX.Minimum = -50;
            this.tbPosX.Name = "tbPosX";
            this.tbPosX.Size = new System.Drawing.Size(595, 45);
            this.tbPosX.TabIndex = 2;
            this.tbPosX.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbPosX.Value = 2;
            this.tbPosX.Scroll += new System.EventHandler(this.tbPosX_Scroll);
            // 
            // tbPosY
            // 
            this.tbPosY.Location = new System.Drawing.Point(613, 12);
            this.tbPosY.Maximum = 50;
            this.tbPosY.Minimum = -50;
            this.tbPosY.Name = "tbPosY";
            this.tbPosY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbPosY.Size = new System.Drawing.Size(45, 595);
            this.tbPosY.TabIndex = 3;
            this.tbPosY.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbPosY.Value = 2;
            this.tbPosY.Scroll += new System.EventHandler(this.tbPosY_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioCamera);
            this.groupBox1.Controls.Add(this.radioLight);
            this.groupBox1.Location = new System.Drawing.Point(664, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 44);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Positions";
            // 
            // radioCamera
            // 
            this.radioCamera.AutoSize = true;
            this.radioCamera.Location = new System.Drawing.Point(64, 19);
            this.radioCamera.Name = "radioCamera";
            this.radioCamera.Size = new System.Drawing.Size(61, 17);
            this.radioCamera.TabIndex = 1;
            this.radioCamera.Text = "Camera";
            this.radioCamera.UseVisualStyleBackColor = true;
            this.radioCamera.CheckedChanged += new System.EventHandler(this.radioPositionChanged);
            // 
            // radioLight
            // 
            this.radioLight.AutoSize = true;
            this.radioLight.Checked = true;
            this.radioLight.Location = new System.Drawing.Point(10, 19);
            this.radioLight.Name = "radioLight";
            this.radioLight.Size = new System.Drawing.Size(48, 17);
            this.radioLight.TabIndex = 0;
            this.radioLight.TabStop = true;
            this.radioLight.Text = "Light";
            this.radioLight.UseVisualStyleBackColor = true;
            this.radioLight.CheckedChanged += new System.EventHandler(this.radioPositionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboSize);
            this.groupBox2.Controls.Add(this.comboColor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textCubePosZ);
            this.groupBox2.Controls.Add(this.textCubePosY);
            this.groupBox2.Controls.Add(this.textCubePosX);
            this.groupBox2.Controls.Add(this.buttonAddCube);
            this.groupBox2.Location = new System.Drawing.Point(664, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 79);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cubes";
            // 
            // buttonAddCube
            // 
            this.buttonAddCube.Location = new System.Drawing.Point(295, 17);
            this.buttonAddCube.Name = "buttonAddCube";
            this.buttonAddCube.Size = new System.Drawing.Size(125, 49);
            this.buttonAddCube.TabIndex = 0;
            this.buttonAddCube.Text = "Add cube";
            this.buttonAddCube.UseVisualStyleBackColor = true;
            this.buttonAddCube.Click += new System.EventHandler(this.buttonAddCube_Click);
            // 
            // textCubePosX
            // 
            this.textCubePosX.Location = new System.Drawing.Point(30, 19);
            this.textCubePosX.Name = "textCubePosX";
            this.textCubePosX.Size = new System.Drawing.Size(67, 20);
            this.textCubePosX.TabIndex = 1;
            this.textCubePosX.Text = "0";
            this.textCubePosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textCubePosY
            // 
            this.textCubePosY.Location = new System.Drawing.Point(126, 19);
            this.textCubePosY.Name = "textCubePosY";
            this.textCubePosY.Size = new System.Drawing.Size(67, 20);
            this.textCubePosY.TabIndex = 2;
            this.textCubePosY.Text = "0";
            this.textCubePosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textCubePosZ
            // 
            this.textCubePosZ.Location = new System.Drawing.Point(222, 19);
            this.textCubePosZ.Name = "textCubePosZ";
            this.textCubePosZ.Size = new System.Drawing.Size(67, 20);
            this.textCubePosZ.TabIndex = 3;
            this.textCubePosZ.Text = "0";
            this.textCubePosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "X:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Z:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboColor
            // 
            this.comboColor.FormattingEnabled = true;
            this.comboColor.Items.AddRange(new object[] {
            "RED",
            "GREEN",
            "BLUE",
            "YELLOW",
            "WHITE"});
            this.comboColor.Location = new System.Drawing.Point(10, 45);
            this.comboColor.Name = "comboColor";
            this.comboColor.Size = new System.Drawing.Size(136, 21);
            this.comboColor.TabIndex = 7;
            this.comboColor.Text = "Color";
            // 
            // comboSize
            // 
            this.comboSize.FormattingEnabled = true;
            this.comboSize.Items.AddRange(new object[] {
            "0.1",
            "0.3",
            "0.5",
            "1",
            "2",
            "3"});
            this.comboSize.Location = new System.Drawing.Point(153, 45);
            this.comboSize.Name = "comboSize";
            this.comboSize.Size = new System.Drawing.Size(136, 21);
            this.comboSize.TabIndex = 8;
            this.comboSize.Text = "Size";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.trackRayTrDepth);
            this.groupBox3.Location = new System.Drawing.Point(664, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(426, 71);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RayTracing Depth";
            // 
            // trackRayTrDepth
            // 
            this.trackRayTrDepth.Location = new System.Drawing.Point(10, 19);
            this.trackRayTrDepth.Minimum = 1;
            this.trackRayTrDepth.Name = "trackRayTrDepth";
            this.trackRayTrDepth.Size = new System.Drawing.Size(410, 45);
            this.trackRayTrDepth.TabIndex = 7;
            this.trackRayTrDepth.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackRayTrDepth.Value = 10;
            this.trackRayTrDepth.Scroll += new System.EventHandler(this.SetRayTracingDepth);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 668);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbPosY);
            this.Controls.Add(this.tbPosX);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPosY)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackRayTrDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl GLView;
        private System.Windows.Forms.TrackBar tbPosX;
        private System.Windows.Forms.TrackBar tbPosY;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioCamera;
        private System.Windows.Forms.RadioButton radioLight;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textCubePosZ;
        private System.Windows.Forms.TextBox textCubePosY;
        private System.Windows.Forms.TextBox textCubePosX;
        private System.Windows.Forms.Button buttonAddCube;
        private System.Windows.Forms.ComboBox comboSize;
        private System.Windows.Forms.ComboBox comboColor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar trackRayTrDepth;
    }
}

