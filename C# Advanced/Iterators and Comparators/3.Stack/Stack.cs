namespace _3.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Stack<T> : IEnumerable<T>
    {
        private List<T> stack;

        public Stack(params T[] data)
        {
            this.stack = data.ToList();
        }

        public void Pop()
        {
            if (stack.Count > 0)
            {
                stack.RemoveAt(stack.Count - 1);
            }
            else
            {
                Console.WriteLine(("No elements"));
            }
        }
        public void Push(T[] element)
        {
            for (int i = 0; i < element.Length; i++)
            {
                this.stack.Add((T)element[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.stack.Count - 1; i >= 0; i--)
            {
                yield return this.stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
