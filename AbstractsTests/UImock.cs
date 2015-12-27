namespace GameOfLife.AbstractsTests
{
    class UImock : Abstracts.GameOfLifeUI
    {
        public Abstracts.GameOfLifeFrame frame;

        public override Abstracts.GameOfLifeFrame GetCurrentFrame()
        {
            return frame;
        }

        public override void SetNewFrame(Abstracts.GameOfLifeFrame frame)
        {
            this.frame = frame;
        }
    }
}
