using System;
using System.Drawing;

namespace TelCo.ColorCoder
{
    public static class ColorMapper
    {

        /// <summary>
        /// Array of Major colors
        /// </summary>
        private static Color[] colorMapMajor;
        /// <summary>
        /// Array of minor colors
        /// </summary>
        private static Color[] colorMapMinor;
        static ColorMapper()
        {
            colorMapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            colorMapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }
        /// <summary>
        /// Given a pair number function returns the major and minor colors in that order
        /// </summary>
        /// <param name="pairNumber">Pair number of the color to be fetched</param>
        /// <returns></returns>
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
        /// <summary>
        /// Given the two colors the function returns the pair number corresponding to them
        /// </summary>
        /// <param name="pair">Color pair with major and minor color</param>
        /// <returns></returns>
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
