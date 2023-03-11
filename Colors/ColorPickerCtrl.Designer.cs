namespace Colors
{
	partial class ColorPickerCtrl
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
            this.components = new System.ComponentModel.Container();
            this.m_colorWheel = new Colors.ColorWheelCtrl();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // m_colorWheel
            // 
            this.m_colorWheel.BackColor = System.Drawing.Color.Transparent;
            this.m_colorWheel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_colorWheel.Location = new System.Drawing.Point(10, 4);
            this.m_colorWheel.Name = "m_colorWheel";
            this.m_colorWheel.Size = new System.Drawing.Size(313, 207);
            this.m_colorWheel.TabIndex = 0;
            // 
            // ColorPickerCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.m_colorWheel);
            this.Name = "ColorPickerCtrl";
            this.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.Size = new System.Drawing.Size(324, 213);
            this.ResumeLayout(false);

		}

		#endregion

		private ColorWheelCtrl m_colorWheel;
		private System.Windows.Forms.ToolTip m_tooltip;
	}
}
