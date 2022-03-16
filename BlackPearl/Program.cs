using BlackPearl;

int totalNecklaceCount = 1000;
var r = new Random();
var db = new BlackPearl.BlackPearl();

db.PearlLists.RemoveRange(db.PearlLists);
db.Pearls.RemoveRange(db.Pearls);
db.SaveChanges();

Console.WriteLine("DB tables cleared.");

Console.WriteLine($"Generating {totalNecklaceCount} necklaces..");

for (int i = 0; i < totalNecklaceCount; i++)
{
    var necklace = PearlList.Factory.CreateRandomList(r.Next(10, 50));
    db.PearlLists.Add(necklace);
    db.Pearls.AddRange(necklace._pearllist);
}

db.SaveChanges();

Console.WriteLine("Done.");

Console.WriteLine("Finding the most expensive necklace..");

var necklaces = db.PearlLists.ToList();
var expensive = necklaces.OrderByDescending(price => price.totalPrice).First();

Console.WriteLine($"The most expensive necklace is {expensive.totalPrice} SEK.");
