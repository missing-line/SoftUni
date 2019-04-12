namespace ExplicitInterfaces
{
    public interface IPerson : IGetName
    {
         string Name { get; set; }
         int Age { get; set; }
      
    }
}
