using System.Reflection.Emit;

namespace Colors
{ 

    partial class ColorWheelCtrl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_colorWheel = new Colors.ColorWheel();
            this.m_colorSlider = new Colors.HSLColorSlider();
            this.m_transparencySlider = new Colors.ColorSlider();
            this.MainColor = new Colors.LabelRotate();
            this.LeftColor = new Colors.LabelRotate();
            this.RightColor = new Colors.LabelRotate();
            this.BackwardColor = new Colors.LabelRotate();
            this.MainColorLabel = new System.Windows.Forms.TextBox();
            this.BackwardColorLabel = new System.Windows.Forms.TextBox();
            this.RightColorLabel = new System.Windows.Forms.TextBox();
            this.LeftColorLabel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_colorWheel
            // 
            this.m_colorWheel.Location = new System.Drawing.Point(3, 3);
            this.m_colorWheel.Name = "m_colorWheel";
            this.m_colorWheel.Size = new System.Drawing.Size(200, 200);
            this.m_colorWheel.TabIndex = 0;
            this.m_colorWheel.Text = "colorWheel1";
            // 
            // m_colorSlider
            // 
            this.m_colorSlider.BarPadding = new System.Windows.Forms.Padding(10, 10, 30, 20);
            this.m_colorSlider.Color1 = System.Drawing.Color.Black;
            this.m_colorSlider.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.m_colorSlider.Color3 = System.Drawing.Color.White;
            this.m_colorSlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_colorSlider.ForeColor = System.Drawing.Color.Black;
            this.m_colorSlider.Location = new System.Drawing.Point(210, 3);
            this.m_colorSlider.Name = "m_colorSlider";
            this.m_colorSlider.NumberOfColors = Colors.ColorSlider.eNumberOfColors.Use3Colors;
            this.m_colorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.m_colorSlider.Percent = 0F;
            this.m_colorSlider.RotatePointAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.m_colorSlider.Size = new System.Drawing.Size(46, 200);
            this.m_colorSlider.TabIndex = 1;
            this.m_colorSlider.Text = "Яркость";
            this.m_colorSlider.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.m_colorSlider.TextAngle = 270F;
            this.m_colorSlider.ValueOrientation = Colors.ColorSlider.eValueOrientation.MinToMax;
            // 
            // m_transparencySlider
            // 
            this.m_transparencySlider.BarPadding = new System.Windows.Forms.Padding(10, 10, 30, 20);
            this.m_transparencySlider.Color1 = System.Drawing.Color.White;
            this.m_transparencySlider.Color2 = System.Drawing.Color.Black;
            this.m_transparencySlider.Color3 = System.Drawing.Color.Black;
            this.m_transparencySlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_transparencySlider.ForeColor = System.Drawing.Color.Black;
            this.m_transparencySlider.Location = new System.Drawing.Point(261, 3);
            this.m_transparencySlider.Name = "m_transparencySlider";
            this.m_transparencySlider.IsAlphaH = true;
            this.m_transparencySlider.NumberOfColors = Colors.ColorSlider.eNumberOfColors.Use2Colors;
            this.m_transparencySlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.m_transparencySlider.Percent = 1F;
            this.m_transparencySlider.RotatePointAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.m_transparencySlider.Size = new System.Drawing.Size(46, 200);
            this.m_transparencySlider.TabIndex = 2;
            this.m_transparencySlider.Text = "Прозрачность";
            this.m_transparencySlider.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.m_transparencySlider.TextAngle = 270F;
            this.m_transparencySlider.ValueOrientation = Colors.ColorSlider.eValueOrientation.MinToMax;
            // 
            // MainColor
            // 
            this.MainColor.Location = new System.Drawing.Point(3, 200);
            this.MainColor.Name = "MainColor";
            this.MainColor.MyColorIndex = 0;
            this.MainColor.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.MainColor.RotatePointAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.MainColor.Size = new System.Drawing.Size(200, 40);
            this.MainColor.TabIndex = 5;
            this.MainColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MainColor.TextAngle = 0F;
            // 
            // MainColorLabel
            //
            MainColorLabel.Location = new System.Drawing.Point(206, 220);
            MainColorLabel.Size = new System.Drawing.Size(250, 40);
            MainColorLabel.ReadOnly = true;
            // 
            // BackwardColor
            // 
            this.BackwardColor.Location = new System.Drawing.Point(3, 250);
            this.BackwardColor.Name = "BackwardColor";
            this.BackwardColor.MyColorIndex = 3;
            this.BackwardColor.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.BackwardColor.RotatePointAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.BackwardColor.Size = new System.Drawing.Size(200, 40);
            this.BackwardColor.TabIndex = 5;
            this.BackwardColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackwardColor.TextAngle = 0F;
            // 
            // BackwardColorLabel
            //
            BackwardColorLabel.Location = new System.Drawing.Point(206, 270);
            BackwardColorLabel.Size = new System.Drawing.Size(250, 40);
            BackwardColorLabel.ReadOnly = true;
            // 
            // LeftColor
            // 
            this.LeftColor.Location = new System.Drawing.Point(3, 300);
            this.LeftColor.Name = "LeftColor";
            this.LeftColor.MyColorIndex = 2;
            this.LeftColor.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.LeftColor.RotatePointAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.LeftColor.Size = new System.Drawing.Size(200, 40);
            this.LeftColor.TabIndex = 5;
            this.LeftColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LeftColor.TextAngle = 0F;
            // 
            // LeftColorLabel
            //
            LeftColorLabel.Location = new System.Drawing.Point(206, 320);
            LeftColorLabel.Size = new System.Drawing.Size(250, 40);
            LeftColorLabel.ReadOnly = true;
            // 
            // RightColor
            // 
            this.RightColor.Location = new System.Drawing.Point(3, 350);
            this.RightColor.Name = "RightColor";
            this.RightColor.MyColorIndex = 1;
            this.RightColor.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.RightColor.RotatePointAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.RightColor.Size = new System.Drawing.Size(200, 40);
            this.RightColor.TabIndex = 5;
            this.RightColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RightColor.TextAngle = 0F;
            // 
            // RightColorColorLabel
            //
            RightColorLabel.Location = new System.Drawing.Point(206, 370);
            RightColorLabel.Size = new System.Drawing.Size(250, 40);
            RightColorLabel.ReadOnly = true;
            // 
            // ColorWheelCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.m_transparencySlider);
            this.Controls.Add(this.m_colorWheel);
            this.Controls.Add(this.m_colorSlider);
            this.Controls.Add(MainColor);
            this.Controls.Add(MainColorLabel);
            this.Controls.Add(BackwardColor);
            this.Controls.Add(BackwardColorLabel);
            this.Controls.Add(RightColor);
            this.Controls.Add(RightColorLabel);
            this.Controls.Add(LeftColor);
            this.Controls.Add(LeftColorLabel);
            this.Name = "ColorWheelCtrl";
            this.Size = new System.Drawing.Size(460, 420);
            this.ResumeLayout(false);

		}

        #endregion

        private LabelRotate MainColor;
        private LabelRotate LeftColor;
        private LabelRotate RightColor;
        private LabelRotate BackwardColor;

        private System.Windows.Forms.TextBox MainColorLabel;
        private System.Windows.Forms.TextBox LeftColorLabel;
        private System.Windows.Forms.TextBox RightColorLabel;
        private System.Windows.Forms.TextBox BackwardColorLabel;

        private HSLColorSlider m_colorSlider;
		private ColorWheel m_colorWheel;
        private ColorSlider m_transparencySlider;
    }
}
