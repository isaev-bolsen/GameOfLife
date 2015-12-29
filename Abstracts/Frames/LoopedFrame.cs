namespace GameOfLife.Frames
{
    abstract class LoopedFrame : GameOfLife.Abstracts.GameOfLifeFrame
    {
        public LoopedFrame(int U, int V) : base(U, V) { }

        protected int CorrectIndex(int index, int arrayLength)
        {
            if (index >= 0) return index % arrayLength;
            else return CorrectIndex(arrayLength + index, arrayLength);
        }
    }
}
