namespace Generic_Box_of_String
{
    public class Box<T>
    {
        private T value;

        public  T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }


        public override string ToString()
        {
            return $"{value.GetType()}: {this.value}";
        }
    }
}
