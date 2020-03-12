namespace Xadrez.Board
{
    /// <summary>
    /// Posição de uma Peça qualquer do Xadrez
    /// </summary>
    public class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }
        public void DefineValue(int line, int column)
        {
            Line = line;
            Column = column;
        }
        public override string ToString()
        {
            return $"{Line}, {Column}";
        }
    }
}
