using TietokantaHarjoitus;


while (true)
{
    Console.WriteLine("Haluatko ");
    Console.WriteLine(" 1 lisätä tuotetietoja ");
    Console.WriteLine(" 2 poistaa tuotetietoja ");
    Console.WriteLine(" 3 muokata tuotetietoja ");
    Console.WriteLine(" 4 Tulostaa tuotelistan ");
    Console.WriteLine(" 0 Sulkea sovelluksen");

    string userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            Console.WriteLine("Tuote tietojen lisääminen");
            Console.WriteLine("lisää id");
            int userId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Lisää tuoteNimi");
            string userTuoteNimi = Console.ReadLine();

            Console.WriteLine("Lisää Hinta");
            int userHinta = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Lisää VarastoSaldo");
            int userVarastoSaldo = Convert.ToInt32(Console.ReadLine());


            AddProduct(userId, userTuoteNimi, userHinta, userVarastoSaldo); 

            Console.WriteLine("Tuote lisätty");

            break;

        case "2":
            Console.WriteLine("Kerro tuotteen id jonka haluat poistaa");
            int inputId = Convert.ToInt32(Console.ReadLine());

            DeleteProduct(inputId);
            Console.WriteLine("Tuote poistettu");
            break;



        case "3":
            Console.WriteLine("Mitä haluasit muokata. kerro id");
            int userInputId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kerro tuotteen uusi nimi");
            string tuotteenUusiNimi = Console.ReadLine();

            ChangeProductName(userInputId, tuotteenUusiNimi);
            Console.WriteLine("Tuotteen nimi muokattu");
            break;


        case "4":
            QueringProducts();
            break;


        case "0":
            Environment.Exit(0);
            break;
    }
} 






//AddProduct(1, "Haulikko", 120, 50);
//ChangeProductName(1, "Kirves");
//DeleteProduct(5);
//QueringProducts();


static void QueringProducts()
{
    using VarastonHallinta varastonHallinta = new();

    Console.WriteLine("All products on the list: ");
    IQueryable<Tuote> allProducts = varastonHallinta.Tuotteet;

    foreach(Tuote tuote in allProducts)
    {
        Console.WriteLine($"{tuote.id}, {tuote.tuoteNimi}, {tuote.hinta}, {tuote.varastoSaldo}");
    }

}

static bool AddProduct(int newID, string newTuoteNimi, int newHinta, int newVarastoSaldo)
{
    using VarastonHallinta varastonHallinta = new();
    Tuote tuote = new()
    {
        id = newID,
        tuoteNimi = newTuoteNimi,
        hinta = newHinta,
        varastoSaldo = newVarastoSaldo
    };
    varastonHallinta.Tuotteet?.Add(tuote);
    int affected = varastonHallinta.SaveChanges();
    return affected == 1;
}

static int DeleteProduct(int id)
{
    using VarastonHallinta varastonHallinta = new();
    Tuote ProductDelete = varastonHallinta.Tuotteet.Find(id);

    if(ProductDelete is null)
    {
        return 0;
    }
    else
    {
        varastonHallinta.Remove(ProductDelete);
        int affected = varastonHallinta.SaveChanges();
        return affected;
    }
}
static bool ChangeProductName(int id, string newProductName)
{
    using VarastonHallinta varastonHallinta = new();
    Tuote productUpdate = varastonHallinta.Tuotteet.FirstOrDefault(tuote => tuote.id == id);
    
    if(productUpdate is null)
    {
        return false;
    }
    else
    {
        productUpdate.tuoteNimi = newProductName;
        int affected = varastonHallinta.SaveChanges();
        return affected == 1;
    }
}