using TietokantaHarjoitus;



AddProduct(1, "Haulikko", 120, 50);
QueringProducts();


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