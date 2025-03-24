using Olimpia.Models;

List<OlimpiaiAdat> adatok = new List<OlimpiaiAdat>();

var sorok = File.ReadAllLines("olimpia.csv").Skip(1);
foreach (var line in sorok)
{
    adatok.Add(new OlimpiaiAdat(line));
}

//foreach (var dij in adatok)
//{
//Console.WriteLine(dij);
//}

Console.WriteLine($"3. A listában {adatok.Count()} fő szerepel.");

var uszok = adatok
    .Where(x => x.Sportag.Equals("úszás"))
    .OrderByDescending(x => x.Ev);


Console.WriteLine("\n4. Úszók: ");

foreach (var item in uszok)
{
    Console.WriteLine($"\t{item}");
}

var nok = adatok
    .Where(x => x.Nem.Equals("Nő") && x.Ev == 2020);


Console.WriteLine("\n6. Nők(2020):");

foreach (var item in nok)
{
    Console.WriteLine($"\t{item}");
}

Console.WriteLine("\n7. Aranyérmek sportáganként:");

//var arany = adatok
    //.GroupBy(x => x.Sportag)
    //.Select(x => new { x.Key, db = x.Count() })
    //.OrderByDescending(x => x.db)
    //.First();

//Console.WriteLine($"\t{arany.Key} - {arany.db} db");

var arany = adatok
    .GroupBy(x => x.Sportag)
    .OrderByDescending(x => x.Count())
    .First();

Console.WriteLine($"\t{arany.Key} - {arany.Count()} db");

//foreach (var item in arany)
//{
//Console.WriteLine(item);
//}

var filebe = uszok
    .Select(x => x.Ev + " - " + x.Versenyzo);

//File.WriteAllLines("uszas.txt", filebe);

//File.WriteAllLines(@"c:\adat\uszas.txt", filebe);

var sportagSzam = adatok
    .Select(x => x.Sportag)
    .Distinct()
    .Count();

Console.WriteLine($"\nA sportágak száma: {sportagSzam}");

var tobbarany = adatok
    .GroupBy(x => x.Versenyzo)
    .Select(x => new { x.Key, Db = x.Count() })
    .Where(x => x.Db > 1);

