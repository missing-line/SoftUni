namespace DP_Demo
{
    using DP_Demo.Composite;
    using DP_Demo.Prototype;
    using DP_Demo.Template;
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // => ** ProtoType ** <= //
            //SandwichMenu sandwichMenu = new SandwichMenu();

            //sandwichMenu["BLT"] = new Sandwich("product1" ,"products2" , "product3" , "product4");
            //sandwichMenu["defaulTwo"] = new Sandwich("product5" ,"products6" , "product7" , "product8");
            //sandwichMenu["defaulThree"] = new Sandwich("product9" ,"products10" , "product11" , "product12");

            //sandwichMenu["LoadedBTL"] = new Sandwich("Wheat", "Tyrkey", "America", "Tomato");
            //sandwichMenu["MeatCombo"] = new Sandwich("Rye", "Ham, Salami", "Provolone", "Onion");
            //sandwichMenu["Vegetarian"] = new Sandwich("Wheat", "products10", "Tomato, Olives", "product12");

            //Sandwich sandwich1 = sandwichMenu["BLT"].Clone() as Sandwich;
            //Sandwich sandwich2 = sandwichMenu["LoadedBTL"].Clone() as Sandwich;
            //Sandwich sandwich3 = sandwichMenu["MeatCombo"].Clone() as Sandwich;

            // => ** Composite ** <= //
            //GiftSingle giftSingle = new GiftSingle("singleGift", 1.10m);
            //giftSingle.CalculaTotalPrice();
            //Console.WriteLine();

            //var giftBox = new Gift("Box", 0);
            //GiftSingle truck = new GiftSingle("truckToy", 12.10m);
            //GiftSingle plane = new GiftSingle("planeToy", 16.16m);
            //giftBox.Add(truck);
            //giftBox.Add(plane);

            //decimal totalPriceBox = giftBox.CalculaTotalPrice();
            //Console.WriteLine(totalPriceBox);

            // => ** Tempate ** <= //
            Sourdough sourdough = new Sourdough();
            sourdough.Make();
            Console.WriteLine();

            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();
        }
    }
}
