namespace GameOfLife.Abstracts
{
    public abstract class GameOfLifeUI
    {
        public abstract GameOfLifeFrame GetCurrentFrame();
        public abstract void SetNewFrame(GameOfLifeFrame frame);
    }
}
