﻿namespace GenericSwapMethodInteger
{
    using System.Collections.Generic;
    public class Swap<T>
    {
        private List<T> box;

        public Swap()
        {
            this.Box = new List<T>();
        }
        public List<T> Box
        {
            get { return this.box; }
            set { this.box = value; }
        }

        public void Swaping(int firstIndex, int secondIndex)
        {
            var firstElement = box[firstIndex];
            box[firstIndex] = box[secondIndex];
            box[secondIndex] = firstElement;
        }
    }
}
