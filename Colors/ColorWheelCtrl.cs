using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Colors
{
	public partial class ColorWheelCtrl : UserControl
	{

		public ColorWheelCtrl()
		{
			
			InitializeComponent();

            CurrColor.SelectedColorChanged += RefreshLabelText;

            CurrPointer.Center = Util.Center(m_colorWheel.ClientRectangle);
            CurrPointer.Radius = m_colorWheel.Radius(m_colorWheel.ColorWheelRectangle) * CurrColor.Saturation;
            CurrPointer.MainPoint = Util.Center(m_colorWheel.ClientRectangle);

            m_colorSlider.ValueOrientation = ColorSlider.eValueOrientation.MaxToMin;
		}


		public void RefreshLabelText()
		{
            MainColorLabel.Text = CurrColor.GetFullColorText(0);
            MainColorLabel.Update();
            LeftColorLabel.Text = CurrColor.GetFullColorText(2);
            LeftColorLabel.Update();
            RightColorLabel.Text = CurrColor.GetFullColorText(1);
            RightColorLabel.Update();
            BackwardColorLabel.Text = CurrColor.GetFullColorText(3);
            BackwardColorLabel.Update();
        }
	}
}
