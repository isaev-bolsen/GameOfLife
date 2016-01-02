using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Abstracts
{
    public abstract class GameOfLifeFrame : IEnumerable<IEnumerable<bool>>
    {
        private class enumerator : IEnumerator<IEnumerable<bool>>
        {
            public GameOfLifeFrame frame;

            private int y = 0;

            public enumerator(GameOfLifeFrame frame)
            {
                this.frame = frame;
            }

            public IEnumerable<bool> Current
            {
                get { return GetCurrent(); }
            }

            object IEnumerator.Current
            {
                get { return GetCurrent(); }
            }

            private IEnumerable<bool> GetCurrent()
            {
                return Enumerable.Range(0, frame.U).Select(x => frame[x, y]);
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                ++y;
                return y <= frame.V;
            }

            public void Reset()
            {
                y = 0;
            }
        }


        protected bool[,] frame;

        public GameOfLifeFrame(int U, int V)
        {
            frame = new bool[U, V];
        }

        public int U
        {
            get { return frame.GetLength(0); }
        }

        public int V
        {
            get { return frame.GetLength(1); }
        }

        public abstract GameOfLifeFrame New();

        public IEnumerator<IEnumerable<bool>> GetEnumerator()
        {
            return new enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new enumerator(this);
        }

        public abstract bool this[int i, int j] { get; set; }
    }
}
