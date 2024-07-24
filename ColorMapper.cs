using System;
using System.Drawing;
namespace TelCo.ColorCoder
{
    public static class ColorMapper
    {
        private static Color[] colorMapMajor;
        private static Color[] colorMapMinor;
        static ColorMapper()
        {
            colorMapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            colorMapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }

        public static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            if (pairNumber < 1 || pairNumber > colorMapMinor.Length * colorMapMajor.Length)
            {
                throw new ArgumentOutOfRangeException(
                string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }

            int majorIndex = (pairNumber - 1) / colorMapMinor.Length;
            int minorIndex = (pairNumber - 1) % colorMapMinor.Length;
            ColorPair pair = new ColorPair()
            {
                MajorColor = colorMapMajor[majorIndex],
                MinorColor = colorMapMinor[minorIndex]
            };
            return pair;
        }

        public static int GetPairNumberFromColor(ColorPair pair)
        {
            int majorIndex = Array.IndexOf(colorMapMajor, pair.MajorColor);
            int minorIndex = Array.IndexOf(colorMapMinor, pair.MinorColor);

            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException(
                string.Format("Unknown Colors: {0}", pair.ToString()));
            }

            return (majorIndex * colorMapMinor.Length) + (minorIndex + 1);
        }
    }
}
