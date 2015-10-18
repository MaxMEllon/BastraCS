using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BustraCS.Stone
{
    /// <summary>
    /// 石の色の列挙体
    /// </summary>
    public struct StoneColor
    {
        public static readonly Brush RED = Brushes.Red;
        public static readonly Brush BLUE  = Brushes.Blue;
        public static readonly Brush GREEN = Brushes.Green;
        public static readonly Brush DARK  = Brushes.DarkMagenta;
        public static readonly Brush LIGHT = Brushes.LightYellow;
        public static readonly Brush HEAL  = Brushes.LightPink;

        public static Brush random()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var buffer = new byte[sizeof(int)];
                rng.GetBytes(buffer);
                var seed = BitConverter.ToInt32(buffer, 0);
                var random = new Random(seed);
                int number = random.Next(6);
                switch (number)
                {
                    case 0: return RED;
                    case 1: return BLUE;
                    case 2: return GREEN;
                    case 3: return DARK;
                    case 4: return LIGHT;
                    case 5: return HEAL;
                    default: return HEAL;
                }
            }
        }
    }
}
