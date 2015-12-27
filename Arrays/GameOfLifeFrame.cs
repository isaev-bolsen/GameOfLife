namespace GameOfLifeFrame.Abstracts
{
    public abstract class GameOfLifeFrame
    {
        protected bool[,] frame;

        protected GameOfLifeFrame(bool[,] frame)
        {
            this.frame = frame;
        }

        public GameOfLifeFrame(int U, int V) : this(new bool[U, V]) { }

        public int U
        {
            get { return frame.GetLength(0); }
        }

        public int V
        {
            get { return frame.GetLength(1); }
        }

        public abstract GameOfLifeFrame Clone();

        public virtual bool this[int i, int j]
        {
            get { return frame[i, j]; }
            set { frame[i, j] = value; }
        }
    }
}
