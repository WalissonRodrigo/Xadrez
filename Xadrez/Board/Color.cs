using System.ComponentModel;

namespace Xadrez.Board
{
    /// <summary>
    /// Cor das Peças do Tabuleiro
    /// </summary>
    public enum Color
    {
        [Description("Branca")]
        White,
        [Description("Preta")]
        Black,
        [Description("Amarela")]
        Yellow,
        [Description("Azul")]
        Blue,
        [Description("Vermelha")]
        Red,
        [Description("Verde")]
        Green,
        [Description("Laranja")]
        Orange
    }
    public static class ColorExtensions
    {
        public static string ToFriendlyString(this Color me)
        {
            switch (me)
            {
                case Color.White:
                    return "Branca";
                case Color.Black:
                    return "Preta";
                case Color.Yellow:
                    return "Amarela";
                case Color.Blue:
                    return "Azul";
                case Color.Red:
                    return "Vermelha";
                case Color.Green:
                    return "Verde";
                case Color.Orange:
                    return "Laranja";

                default:
                    return me.ToString();
            }
        }
    }
}
