using System;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    public static class ColorPairNumberTests
    {

        public static void ExecuteTests()
        {
            TestGetColorFromPairNumber();
            TestGetPairNumberFromColor();

        }
        public static void TestGetColorFromPairNumber()
        {
            int pairNumber = 4;
            Color expectedMajor = Color.White;
            Color expectedMinor = Color.Brown;

            ColorPair testPair = ColorMapper.GetColorFromPairNumber(pairNumber);

            Console.WriteLine("[In] Pair Number: {0}, [Out] Colors: {1}\n", pairNumber, testPair);
            Debug.Assert(testPair.MajorColor == expectedMajor);
            Debug.Assert(testPair.MinorColor == expectedMinor);
        }

        public static void TestGetPairNumberFromColor()
        {
            Color major = Color.Yellow;
            Color minor = Color.Green;
            int expectedPairNumber = 18;

            ColorPair testPair = new ColorPair() { MajorColor = major, MinorColor = minor };
            int pairNumber = ColorMapper.GetPairNumberFromColor(testPair);

            Console.WriteLine("[In] Colors: {0}, [Out] PairNumber: {1}\n", testPair, pairNumber);
            Debug.Assert(pairNumber == expectedPairNumber);
        }
    }
}
