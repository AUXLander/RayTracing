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
            this.buttonProcess = new System.Windows.Forms.Button();
            this.tbLightPosX = new System.Windows.Forms.TrackBar();
            this.tbLightPosY = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbLightPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLightPosY)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(789, 506);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(301, 38);
            this.buttonProcess.TabIndex = 1;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // tbLightPosX
            // 
            this.tbLightPosX.Location = new System.Drawing.Point(12, 613);
            this.tbLightPosX.Maximum = 50;
            this.tbLightPosX.Minimum = -50;
            this.tbLightPosX.Name = "tbLightPosX";
            this.tbLightPosX.Size = new System.Drawing.Size(595, 45);
            this.tbLightPosX.TabIndex = 2;
            this.tbLightPosX.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbLightPosX.Value = 2;
            this.tbLightPosX.Scroll += new System.EventHandler(this.tbLightPosX_Scroll);
            // 
            // tbLightPosY
            // 
            this.tbLightPosY.Location = new System.Drawing.Point(613, 12);
            this.tbLightPosY.Maximum = 50;
            this.tbLightPosY.Minimum = -50;
            this.tbLightPosY.Name = "tbLightPosY";
            this.tbLightPosY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbLightPosY.Size = new System.Drawing.Size(45, 595);
            this.tbLightPosY.TabIndex = 3;
            this.tbLightPosY.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbLightPosY.Value = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 668);
            this.Controls.Add(this.tbLightPosY);
            this.Controls.Add(this.tbLightPosX);
            this.Controls.Add(this.buttonProcess);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbLightPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLightPosY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl GLView;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.TrackBar tbLightPosX;
        private System.Windows.Forms.TrackBar tbLightPosY;
    }
}

