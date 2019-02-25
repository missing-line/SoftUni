namespace _4.Froggy
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    public class Lake : IEnumerable<int>
    {
        private List<int> lake;

        public Lake(params int[] stones)
        {
            this.lake = stones.ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.lake.Count; i += 2)
            {
                yield return this.lake[i];
            }

            var startIndex = this.lake.Count % 2 == 0
                ? this.lake.Count - 1
                : this.lake.Count - 2;

            for (int i = startIndex; i >= 0; i -= 2)
            {
                yield return this.lake[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
         => GetEnumerator();
    }
}
