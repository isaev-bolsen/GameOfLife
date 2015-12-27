namespace GameOfLife.Abstracts
{
    public abstract class GameOfLifeFrame
    {
        protected bool[,] frame;

        public GameOfLifeFrame(int U, int V)
        {
            frame = new bool[U, V];
        }

        public int U
        {
            get { return frame.GetLength(0); }
        }

        public int V
        {
            get { return frame.GetLength(1); }
        }

        public abstract GameOfLifeFrame New();

        public abstract bool this[int i, int j] { get; set; }
    }
}
