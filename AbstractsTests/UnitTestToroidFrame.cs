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
            // 1 1 1 1

            // 1 1 1 1
            // 0 0 0 0
            // 1 1 1 1
            // 1 1 1 1

            Abstracts.GameOfLifeFrame frame = new Frames.CylinderFrame(4, 4);
            for (int i = 0; i < 4; ++i) frame[i, 1] = true;
            UImock UI = new UImock() { frame = frame };

            Abstracts.GameOfLife game = new Abstracts.GameOfLife(UI);
            game.Next();
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 3; ++j)
                    Assert.IsTrue(UI.frame[i, j]);

            for (int i = 0; i < 4; ++i) Assert.IsFalse(UI.frame[i, 3]);

            game.Next();

            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 3; ++j)
                    Assert.IsFalse(UI.frame[i, j]);

            for (int i = 0; i < 4; ++i) Assert.IsTrue(UI.frame[i, 3]);

            game.Next();

            for (int i = 3; i < 5; ++i)
                for (int j = 0; j < 3; ++j)
                    Assert.IsTrue(UI.frame[i, j]);

            for (int i = 0; i < 4; ++i) Assert.IsFalse(UI.frame[i, 2]);

        }
    }
}
