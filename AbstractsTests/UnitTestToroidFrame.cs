﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.AbstractsTests
{
    [TestClass]
    public class UnitTestToroidFrame
    {
        [TestMethod]
        public void TestToroidFrameBasic()
        {
            // 0 0 0 0
            // 1 1 1 1
            // 0 0 0 0
            // 0 0 0 0

            // 1 1 1 1
            // 1 1 1 1
            // 1 1 1 1
            // 0 0 0 0

            // 0 0 0 0
            // 0 0 0 0
            // 0 0 0 0
            // 0 0 0 0

            // 0 0 0 0
            // 0 0 0 0
            // 0 0 0 0
            // 0 0 0 0
            UImock UI = new UImock() { FrameType = "Toroid", U = 4, V = 4 };

            for (int i = 0; i < 4; ++i) UI.frame[i, 1] = true;

            Abstracts.GameOfLife game = new Abstracts.GameOfLife(UI);
            game.Next();
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 3; ++j)
                    Assert.IsTrue(UI.frame[i, j]);

            for (int i = 0; i < 4; ++i) Assert.IsFalse(UI.frame[i, 3]);

            for (int k = 0; k < 3; ++k)
            {
                game.Next();
                for (int i = 0; i < 4; ++i)
                    for (int j = 0; j < 4; ++j)
                        Assert.IsFalse(UI.frame[i, j]);
            }
        }
    }
}
