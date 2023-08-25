using TietokantaHarjoitus;



Console.WriteLine("Haluatko lisätä, poistaa vai muokata tuotetietoja");
string userInput = Console.ReadLine();

if(userInput == "lisätä")
{
    Console.WriteLine("Mitä haluat lisätä tuotetietoihin");
    Console.WriteLine("id, tuotenimi, hinta, varastosaldo");
    string lisäämisenUserInput = Console.ReadLine();
    
}
if (userInput == "poistaa")
{
    Console.WriteLine("Kerro id tuotteesta, minkä haluat poistaa");
    string poistoUserInput = Console.ReadLine();
}
if(userInput == "muokata")
{
    Console.WriteLine("Minkä tuotteen tuote tietoja haluaisit muokata. Kerro tuotteen id");
   string muokkaamisenUserInput = Console.ReadLine();
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