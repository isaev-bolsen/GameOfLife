namespace GameOfLifeFrame.Frames
{
    public class ToroidFrame : GameOfLifeFrame.Frames.LoopedFrame
    {
        public ToroidFrame(int U, int V) : base(U, V) { }

        public override bool this[int i, int j]
        {
            get { return frame[CorrectIndex(i, U), CorrectIndex(j, V)]; }
            set { frame[CorrectIndex(i, U), CorrectIndex(j, V)] = value; }
        }

        public override Abstracts.GameOfLifeFrame New()
        {
            return new ToroidFrame(U, V);
        }
    }
}
