namespace ExplicitInterfaces
{
    public interface IResident: IGetName
    {
         string Name { get; set; }
         string Country { get; set; }
      
    }
}
