using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;

namespace Colors
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            CurrColor.HSL = new HSLColor(Color.FromArgb(255, 255, 255, 255));
            CurrColor.Lightness = 0.8d;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public static class CurrPointer
    {
        public static PointF MainPoint;
        public static double Radius;
        public static PointF Center;

        public static int Mode;

        public static PointF GetRotaredpoint(double angleIn)
        {
            PointF rotatedPoint = new PointF(0,0);
            double angle = Math.PI * angleIn / 180.0;



            rotatedPoint.X = (float)(((MainPoint.X - Center.X) * Math.Cos(angle)) - ((MainPoint.Y - Center.Y) * Math.Sin(angle)));
            rotatedPoint.Y = (float)(((MainPoint.Y - Center.Y) * Math.Cos(angle)) + ((MainPoint.X - Center.X) * Math.Sin(angle)));

            rotatedPoint.X += Center.X - 10;
            rotatedPoint.Y += Center.Y - 10;
            
            return rotatedPoint;
        }
    }

    public static class CurrColor
    {
        public delegate void ColorAction();
        public static event ColorAction SelectedColorChanged;
        public static Color[] Colors = new Color[4];

        public static void ResetColors()
        {
            Colors[1] = Color.Transparent;
            Colors[2] = Color.Transparent;
            Colors[3] = Color.Transparent;
        }

        public static void SelectedColorChangedInvike()
        {
            if (SelectedColorChanged != null)
                SelectedColorChanged.Invoke();
        }

        private static HSLColor hsl;
        public static HSLColor HSL
        {
            get
            {
                return hsl;
            }
            set
            {
                double lightness = hsl.Lightness;
                hsl = value;
                hsl.Lightness = lightness;
                rgb = hsl.Color;
                SelectedColorChangedInvike();
            }
        }

        public static double Saturation
        {
            get { return hsl.Saturation; }
            set
            {
                hsl.Saturation = value;
                rgb = hsl.Color;
                SelectedColorChangedInvike();
            }
        }

        public static double Lightness
        {
            get { return hsl.Lightness; }
            set
            {
                hsl.Lightness = value;
                rgb = hsl.Color;
                SelectedColorChangedInvike();
            }
        }

        private static double alpha = 1;
        public static double Alpha
        {
            get { return alpha; }
            set
            {
                alpha = value;
                SelectedColorChangedInvike();
            }
        }

        private static Color rgb;
        public static Color RGB
        {
            set { rgb = value; }
            get
            {
                return rgb;
            }
        }

        public static Color RGBAlpha
        {
            get
            {
                return Color.FromArgb((int)Alpha, rgb.R, rgb.G, rgb.B);
            }
        }

        public static Color RGB_Alpha(Color rgbP)
        {
            if (rgbP == Color.Transparent)
                return Color.Transparent;
            return Color.FromArgb((int)(Alpha * 255), rgbP.R, rgbP.G, rgbP.B);
        }

        public static string GetFullColorText(int ColorIndex)
        {

            StringBuilder stringBuilder = new StringBuilder(40);
            stringBuilder.Append("ARGB [");
            Color CurrFullColor = RGB_Alpha(Colors[ColorIndex]);
            if (CurrFullColor != Color.Transparent)
            {
                stringBuilder.Append(CurrFullColor.A);
                stringBuilder.Append(",");
                stringBuilder.Append(CurrFullColor.R);
                stringBuilder.Append(",");
                stringBuilder.Append(CurrFullColor.G);
                stringBuilder.Append(",");
                stringBuilder.Append(CurrFullColor.B);
            }
            else
            {
                stringBuilder.Append("Empty");
            }
            stringBuilder.Append("]");

            stringBuilder.Append(" HEX [");
            if (CurrFullColor != Color.Transparent)
            {
                stringBuilder.Append("#");
                stringBuilder.AppendFormat("{0:x2}", CurrFullColor.A * 255);
                stringBuilder.AppendFormat("{0:x2}", CurrFullColor.R);
                stringBuilder.AppendFormat("{0:x2}", CurrFullColor.G);
                stringBuilder.AppendFormat("{0:x2}", CurrFullColor.B);
            }
            else
            {
                stringBuilder.Append("Empty");
            }
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }

        public static Color RGBClear
        {
            get
            {


                double hue = hsl.Hue;
                hue = hue / 60;
                if ((hue <= 1d) | (5d < hue) & (hue <= 7d))
                {
                    if (hue <= 1d)
                        return Color.FromArgb(255, 255, (int)(hue * 255), 0);
                    else
                    {
                        hue -= 5d;
                        return Color.FromArgb(255, 255, 0, (int)((1 - hue) * 255));
                    }
                }

                if ((hue <= 3d))
                {
                    hue -= 1d;
                    if (hue <= 1d)
                        return Color.FromArgb(255, (int)((1 - hue) * 255), 255, 0);
                    else
                    {
                        hue -= 1d;
                        return Color.FromArgb(255, 0, 255, (int)(hue * 255));
                    }
                }

                if ((hue <= 5d))
                {
                    hue -= 3d;
                    if (hue <= 1d)
                        return Color.FromArgb(255, 0, (int)((1 - hue) * 255), 255);
                    else
                    {
                        hue -= 1d;
                        return Color.FromArgb(255, (int)(hue * 255), 0, 255);
                    }
                }
                return Color.FromArgb(255, (int)( 255), (int)( 255), (int)(255));
            }
        }
    }
}
