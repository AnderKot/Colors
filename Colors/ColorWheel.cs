using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Colors
{
	class ColorWheel : Control
	{
		Color m_frameColor = Color.CadetBlue;
		HSLColor m_selectedColor = new HSLColor(Color.BlanchedAlmond);
		List<PointF> m_path = new List<PointF>();
		List<Color> m_colors = new List<Color>();
		double m_wheelLightness = 0.5;
		double lastLightness;

        public HSLColor SelectedHSLColor
		{
			get { return m_selectedColor; }
			set 
			{
				if (m_selectedColor == value)
					return;
				Invalidate(Util.Rect(ColorSelectorRectangle));
				m_selectedColor = value;
				//Refresh();//Invalidate(Util.Rect(ColorSelectorRectangle));
			}
		}
		
		public ColorWheel() : base()
		{
            CurrColor.SelectedColorChanged += this.Update;

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			DoubleBuffered = true;
			SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
		}



    // --Отрисовка-- <<
        // Перегрузка отрисовки элемента
        protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);

			if (lastLightness != CurrColor.Lightness)
				RecalcWheelPoints();

			using (SolidBrush b = new SolidBrush(BackColor))
			{
				e.Graphics.FillRectangle(b, ClientRectangle);
			}
			RectangleF wheelrect = WheelRectangle;
			Util.DrawFrame(e.Graphics, wheelrect, 6, m_frameColor);

			wheelrect = ColorWheelRectangle;
			PointF center = Util.Center(wheelrect);
			e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
			PathGradientBrush m_brush = new PathGradientBrush(m_path.ToArray(), WrapMode.Clamp);
			m_brush.CenterPoint = center;
			m_brush.CenterColor = new HSLColor(0, 0, lastLightness).Color;
			m_brush.SurroundColors = m_colors.ToArray();
			e.Graphics.FillPie(m_brush, Util.Rect(wheelrect), 0, 360);
        }

        protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			DrawColorSelector(e.Graphics);
        }

        // Отрисовка поинтера выбраного цвета
        void DrawColorSelector(Graphics dc)
		{
            CurrColor.ResetColors();
            RectangleF rect = new RectangleF(( - 10 + CurrPointer.MainPoint.X), ( - 10 + CurrPointer.MainPoint.Y), 20.0f, 20.0f);
            // Заполнение
            rect.Size = new Size(19, 19);
            SolidBrush CurrColorBrush = new SolidBrush(CurrColor.RGB);
			CurrColor.Colors[0] = CurrColor.RGBAlpha;
            dc.FillEllipse(CurrColorBrush, rect);
            // Рамка
			Pen MyPen = new Pen(Color.Gold, 2);
			dc.DrawEllipse(MyPen, rect);

            

            switch (CurrPointer.Mode)
			{
                case 2:
                    rect.Location = CurrPointer.GetRotaredpoint(180d);
                    CurrColor.Colors[3] = CalcColor(rect.Location);
                    CurrColorBrush = new SolidBrush(CurrColor.Colors[3]);
                    dc.FillEllipse(CurrColorBrush, rect);
                    MyPen = new Pen(Color.Silver, 2);
                    dc.DrawEllipse(MyPen, rect);
                break;

                case 3:
                    rect.Location = CurrPointer.GetRotaredpoint(120d);
                    CurrColor.Colors[2] = CalcColor(rect.Location);
                    CurrColorBrush = new SolidBrush(CurrColor.Colors[2]);
                    dc.FillEllipse(CurrColorBrush, rect);
                    MyPen = new Pen(Color.Silver, 2);
                    dc.DrawEllipse(MyPen, rect);

                    rect.Location = CurrPointer.GetRotaredpoint(-120d);
                    CurrColor.Colors[1] = CalcColor(rect.Location);
                    CurrColorBrush = new SolidBrush(CurrColor.Colors[1]);
                    dc.FillEllipse(CurrColorBrush, rect);
                    dc.DrawEllipse(MyPen, rect);
                break;

                case 4:
                    rect.Location = CurrPointer.GetRotaredpoint(180d);
                    CurrColor.Colors[3] = CalcColor(rect.Location);
                    CurrColorBrush = new SolidBrush(CurrColor.Colors[3]);
                    dc.FillEllipse(CurrColorBrush, rect);
                    MyPen = new Pen(Color.Silver, 2);
                    dc.DrawEllipse(MyPen, rect);

                    rect.Location = CurrPointer.GetRotaredpoint(90d);
                    CurrColor.Colors[1] = CalcColor(rect.Location);
                    CurrColorBrush = new SolidBrush(CurrColor.Colors[1]);
                    dc.FillEllipse(CurrColorBrush, rect);
                    dc.DrawEllipse(MyPen, rect);

                    rect.Location = CurrPointer.GetRotaredpoint(-90d);
                    CurrColor.Colors[2] = CalcColor(rect.Location);
                    CurrColorBrush = new SolidBrush(CurrColor.Colors[2]);
                    dc.FillEllipse(CurrColorBrush, rect);
                    dc.DrawEllipse(MyPen, rect);
                    break;

                default: break;
			}

			Invalidate();
        }



    // --Отрисовка-- >>

    // --Тригерры на действия пользователя-- <<

        protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (e.Button == MouseButtons.Left)
            {
                SetColor(new PointF(e.X, e.Y));
            }
            
		}
		
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			Focus();
			if (e.Button == MouseButtons.Left)
            {
                SetColor(new PointF(e.X, e.Y));
            }
		}
    // --Тригерры на действия пользователя-- >>
		
		RectangleF ColorSelectorRectangle
		{
			get
			{
				HSLColor color = m_selectedColor;
				double angleR = color.Hue * Math.PI / 180;
				PointF center = Util.Center(ColorWheelRectangle);
				double radius = Radius(ColorWheelRectangle);
				radius *= color.Saturation;
				double x = center.X + Math.Cos(angleR) * radius;
				double y = center.Y - Math.Sin(angleR) * radius;
				Rectangle colrect = new Rectangle(new Point((int)x, (int)y), new Size(0, 0));
				colrect.Inflate(12, 12);
				return colrect;
			}
		}


		RectangleF WheelRectangle
		{
			get 
			{ 
				Rectangle r = ClientRectangle;
				r.Width -= 1;
				r.Height -= 1;
				return r; 
			}
		}

		public RectangleF ColorWheelRectangle
		{
			get
			{
				RectangleF r = WheelRectangle;
				r.Inflate(-5, -5);
				return r;
			}
		}

		public float Radius(RectangleF r)
		{
			PointF center = Util.Center(r);
			float radius = Math.Min((r.Width / 2), (r.Height / 2));
			return radius;
		}

		void RecalcWheelPoints()
		{
			lastLightness = CurrColor.Lightness;

            m_path.Clear();
			m_colors.Clear();

			PointF center = Util.Center(ColorWheelRectangle);
			float radius = Radius(ColorWheelRectangle);
			double angle = 0;
			double fullcircle = 360;
			double step = 5;
			while (angle < fullcircle)
			{
				double angleR = angle * (Math.PI/180);
				double x = center.X + Math.Cos(angleR) * radius;
				double y = center.Y - Math.Sin(angleR) * radius;
				m_path.Add(new PointF((float)x,(float)y));
				m_colors.Add(new HSLColor(angle, 1, lastLightness).Color);
				angle += step; 
			}
		}

		private Color CalcColor(PointF mousepoint)
		{

            PointF center = Util.Center(ColorWheelRectangle);
            double dx = Math.Abs(mousepoint.X - center.X);
            double dy = Math.Abs(mousepoint.Y - center.Y);
            double angle = Math.Atan(dy / dx) / Math.PI * 180;
            double saturation = CurrColor.Saturation;

            if (mousepoint.X < center.X)
                angle = 180 - angle;
            if (mousepoint.Y > center.Y)
                angle = 360 - angle;

            return new HSLColor(angle, saturation, CurrColor.Lightness).Color;
        }

		private void SetColor(PointF mousepoint)
		{	
			if (WheelRectangle.Contains(mousepoint) == false)
				return;

			PointF center = Util.Center(ColorWheelRectangle);
			double radius = Radius(ColorWheelRectangle);
			double dx = Math.Abs(mousepoint.X - center.X);
			double dy = Math.Abs(mousepoint.Y - center.Y);
			double angle = Math.Atan(dy / dx) / Math.PI * 180;
			double dist = Math.Pow((Math.Pow(dx, 2) + (Math.Pow(dy, 2))), 0.5);
			double saturation = dist/radius;

			if (dist > radius) // give 5 pixels slack
				return;
			if (dist < 3)
				return; // snap to center

            CurrPointer.MainPoint = mousepoint;
            CurrPointer.Radius = Radius(ColorWheelRectangle) * CurrColor.Saturation;

            if (mousepoint.X < center.X)
				angle = 180 - angle;
			if (mousepoint.Y > center.Y)
				angle = 360 - angle;

            CurrColor.HSL = new HSLColor(angle, saturation, SelectedHSLColor.Lightness);
        }
	}
}
