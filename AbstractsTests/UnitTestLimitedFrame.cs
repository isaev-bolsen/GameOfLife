using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

            // 0 1 1 0
            // 1 0 0 1
            // 0 1 1 0
            // 0 0 0 0

            // 0 1 1 0
            // 1 0 0 1
            // 0 1 1 0
            // 0 0 0 0
            UImock UI = new UImock() { FrameType = "Flat", U = 4, V = 4 };

            for (int i = 0; i < 4; ++i) UI.frame[i, 1] = true;

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

            var frameRepresentation = UI.frame.Select(r => r.ToArray()).ToArray();

            for (int j = 0; j < 4; ++j)
            {
                Assert.IsFalse(frameRepresentation[0][j]);
                Assert.IsFalse(frameRepresentation[3][j]);
            }

            for (int j = 0; j < 3; ++j)
            {
                Assert.IsTrue(frameRepresentation[1][j]);
                Assert.IsTrue(frameRepresentation[2][j]);
            }

            Assert.IsFalse(frameRepresentation[1][ 3]);
            Assert.IsFalse(frameRepresentation[2][3]);

            for (int k = 0; k < 3; ++k)
            {
                game.Next();

                Assert.IsFalse(UI.frame[0, 0]);
                Assert.IsTrue(UI.frame[1, 0]);
                Assert.IsTrue(UI.frame[2, 0]);
                Assert.IsFalse(UI.frame[3, 0]);

                Assert.IsTrue(UI.frame[0, 1]);
                Assert.IsFalse(UI.frame[1, 1]);
                Assert.IsFalse(UI.frame[2, 1]);
                Assert.IsTrue(UI.frame[3, 1]);

                Assert.IsFalse(UI.frame[0, 2]);
                Assert.IsTrue(UI.frame[1, 2]);
                Assert.IsTrue(UI.frame[2, 2]);
                Assert.IsFalse(UI.frame[3, 2]);

                for (int i = 0; i < 4; ++i) Assert.IsFalse(UI.frame[i, 3]);
            }
        }
    }
}
