using System.Drawing;

namespace TelCo.ColorCoder
{
    public class ColorPair
    {
        public Color MajorColor { get; set; }
        public Color MinorColor { get; set; }
        public ColorPair()
        {

        }
        public ColorPair(Color majorColor, Color minorColor)
        {
            MajorColor = majorColor;
            MinorColor = minorColor;
        }
        public override string ToString()
        {
            return string.Format("MajorColor:{0}, MinorColor:{1}", MajorColor.Name, MinorColor.Name);
        }

    }
}
