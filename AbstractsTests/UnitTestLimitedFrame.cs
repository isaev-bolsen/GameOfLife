using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.AbstractsTests
{
    [TestClass]
    public class UnitTestLimitedFrame
    {
        [TestMethod]
        public void TestLimitedFrameBasic()
        {
            // 0 0 0 0
            // 1 1 1 1
            // 0 0 0 0
            // 0 0 0 0

            // 0 1 1 0
            // 0 1 1 0
            // 0 1 1 0
            // 0 0 0 0

            Abstracts.GameOfLifeFrame frame = new Frames.LimitedFrame(4, 4);
            for (int i = 0; i < 4; ++i) frame[i, 1] = true;
            UImock UI = new UImock() { frame = frame };

            Abstracts.GameOfLife game = new Abstracts.GameOfLife(UI);
            game.Next();
            for (int j = 0; j < 4; ++j)
            {
                Assert.IsFalse(UI.frame[0, j]);
                Assert.IsFalse(UI.frame[3, j]);
            }

            for (int j = 0; j < 3; ++j)
            {
                Assert.IsTrue(UI.frame[1, j]);
                Assert.IsTrue(UI.frame[2, j]);
            }

            Assert.IsFalse(UI.frame[1, 3]);
            Assert.IsFalse(UI.frame[2, 3]);
        }
    }
}
