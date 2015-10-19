using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        #region public static Collection<Brush> COLORS { get; }
        private static readonly Brush[] COLORS
            = new Brush[] {RED, BLUE, GREEN, DARK, LIGHT, HEAL};
        #endregion

        public static Brush Random()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var buffer = new byte[sizeof(int)];
                rng.GetBytes(buffer);
                var seed = BitConverter.ToInt32(buffer, 0);
                return COLORS[new Random(seed).Next(COLORS.Length)];
            }
        }
    }
}
