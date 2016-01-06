using System.Threading;

namespace GameOfLife.Abstracts
{
    public class GameOfLife
    {
        private Timer timer;
        private GameOfLifeUI UI;

        public int delay = 1000;

        public GameOfLife(GameOfLifeUI UI)
        {
            this.UI = UI;
        }

        private void Next(object state)
        {
            Next();
        }

        public void Next()
        {
            GameOfLifeFrame CurrentFrame = UI.GetCurrentFrame() ?? UI.CreateNewFrame();
            GameOfLifeFrame NewFrame = UI.CreateNewFrame();

            for (int i = 0; i < CurrentFrame.U; ++i)
                for (int j = 0; j < CurrentFrame.V; ++j)
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

        public void StartStop()
        {
            if (timer == null) timer = new Timer(Next, null, 0, delay);
            else
            {
                timer.Dispose();
                timer = null;
            }
        }
    }
}
