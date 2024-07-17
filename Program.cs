using System;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    /// <summary>
    /// The 25-pair color code, originally known as even-count color code, 
    /// is a color code used to identify individual conductors in twisted-pair 
    /// wiring for telecommunications.
    /// This class provides the color coding and 
    /// mapping of pair number to color and color to pair number.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Array of Major colors
        /// </summary>
        private static Color[] colorMapMajor;
        /// <summary>
        /// Array of minor colors
        /// </summary>
        private static Color[] colorMapMinor;
        /// <summary>
        /// data type defined to hold the two colors of clor pair
        /// </summary>
        internal class ColorPair
        {
            internal Color majorColor;
            internal Color minorColor;
            public override string ToString()
            {
                return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
            }
        }
        /// <summary>
        /// Static constructor required to initialize static variable
        /// </summary>
        static Program()
        {
            colorMapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            colorMapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }

        /// <summary>
        /// Given a pair number function returns the major and minor colors in that order
        /// </summary>
        /// <param name="pairNumber">Pair number of the color to be fetched</param>
        /// <returns></returns>
        private static ColorPair GetColorFromPairNumber(int pairNumber)
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
                    majorColor = colorMapMajor[majorIndex],
                    minorColor = colorMapMinor[minorIndex]
                };
                
                return pair;
        }
        /// <summary>
        /// Given the two colors the function returns the pair number corresponding to them
        /// </summary>
        /// <param name="pair">Color pair with major and minor color</param>
        /// <returns></returns>
        private static int GetPairNumberFromColor(ColorPair pair)
        {
            int majorIndex = Array.IndexOf(colorMapMajor, pair.majorColor);
            int minorIndex = Array.IndexOf(colorMapMinor, pair.minorColor);

             if (majorIndex == -1 || minorIndex == -1)
             {
                 throw new ArgumentException(
                 string.Format("Unknown Colors: {0}", pair.ToString()));
             }

                 return (majorIndex * colorMapMinor.Length) + (minorIndex + 1);
        }
        /// <summary>
        /// Test code for the class
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
             TestGetColorFromPairNumber(4, Color.White, Color.Brown);
             TestGetColorFromPairNumber(5, Color.White, Color.SlateGray);
             TestGetColorFromPairNumber(23, Color.Violet, Color.Green);
             TestGetPairNumberFromColor(Color.Yellow, Color.Green, 18);
             TestGetPairNumberFromColor(Color.Red, Color.Blue, 6);            
        }

         private static void TestGetColorFromPairNumber(int pairNumber, Color expectedMajor, Color expectedMinor)
         {
             ColorPair testPair = GetColorFromPairNumber(pairNumber);
             Console.WriteLine("[In] Pair Number: {0}, [Out] Colors: {1}\n", pairNumber, testPair);
             Debug.Assert(testPair.majorColor == expectedMajor);
             Debug.Assert(testPair.minorColor == expectedMinor);
         }

         private static void TestGetPairNumberFromColor(Color major, Color minor, int expectedPairNumber)
         {
             ColorPair testPair = new ColorPair() { majorColor = major, minorColor = minor };
             int pairNumber = GetPairNumberFromColor(testPair);
             Console.WriteLine("[In] Colors: {0}, [Out] PairNumber: {1}\n", testPair, pairNumber);
             Debug.Assert(pairNumber == expectedPairNumber);
         }
    }
}
