using TietokantaHarjoitus;



AddProduct(1, "Haulikko", 120, 50);
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
        int affected = varastonHallinta?.SaveChanges();
        return affected;
    }
}
static bool ChangeProductName(string newProductName, int id)
{
    using VarastonHallinta varastonHallinta = new();
    Tuote productUpdate = varastonHallinta.Tuotteet.FirstOrDefault(tuote => tuote.id == id)
}