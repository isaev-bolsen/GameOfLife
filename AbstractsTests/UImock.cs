namespace GameOfLife.AbstractsTests
{
    class UImock : Abstracts.GameOfLifeUI
    {
        private Abstracts.GameOfLifeFrame _frame;

        public Abstracts.GameOfLifeFrame frame
        {
            get
            {
                if (_frame == null) _frame = CreateNewFrame();
                return _frame;
            }
        }

        public override Abstracts.GameOfLifeFrame GetCurrentFrame()
        {
            return frame;
        }

        public override void SetNewFrame(Abstracts.GameOfLifeFrame frame)
        {
            this._frame = frame;
        }
    }
}
