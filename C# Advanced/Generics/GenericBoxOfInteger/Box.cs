namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        private T value;

        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }


        public override string ToString()
        {
            return $"{value.GetType()}: {value}"; 
        }
    }
}
