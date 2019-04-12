namespace Animals
{
    using System;
    public class Animal : ISoundProducable
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        private string Gender
        {
            set
            {
                if (value == "Male" || value == "Female")
                {
                    this.gender = value;
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }

        private int Age
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }

        private string Name
        {
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            }
        }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}" + Environment.NewLine +
                    $"{this.name} {this.age} {this.gender}" + Environment.NewLine +
                    $"{ProduceSound()}";
        }
    }
}
