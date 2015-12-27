namespace GameOfLife.Abstracts
{
    public class GameOfLife
    {
        private GameOfLifeUI UI;

        public GameOfLife(GameOfLifeUI UI)
        {
            this.UI = UI;
        }

        public void Next()
        {
            GameOfLifeFrame CurrentFrame = UI.GetCurrentFrame();
            GameOfLifeFrame NewFrame = CurrentFrame.New();

            for (int i = 0; i < CurrentFrame.U; ++i)
                for (int j = 0; j < CurrentFrame.V; ++i)
                    NewFrame[i, j] = Decide(CurrentFrame, i, j);

            UI.SetNewFrame(NewFrame);
        }

        private bool Decide(GameOfLifeFrame CurrentFrame, int i, int j)
        {
            int LiveNeighbors = 0;
            if (CurrentFrame[i - 1, j - 1]) ++LiveNeighbors;
            if (CurrentFrame[i - 1, j]) ++LiveNeighbors;
            if (CurrentFrame[i - 1, j + 1]) ++LiveNeighbors;

            if (CurrentFrame[i + 1, j - 1]) ++LiveNeighbors;
            if (CurrentFrame[i + 1, j]) ++LiveNeighbors;
            if (CurrentFrame[i + 1, j + 1]) ++LiveNeighbors;

            if (CurrentFrame[i, j - 1]) ++LiveNeighbors;
            if (CurrentFrame[i, j + 1]) ++LiveNeighbors;

            if (LiveNeighbors == 3) return true;
            if (CurrentFrame[i, j] && LiveNeighbors == 2) return true;
            return false;
        }
    }
}
