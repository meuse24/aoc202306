List<long> getList(string line)
{   // gibt eine Liste von Zahlen im String zurück
    return new System.Text.RegularExpressions.Regex(@"\d+")
        .Matches(line)
        .Select(m => long.Parse(m.Value))
        .ToList();
}

long solve(List<long> tRace, List<long> dRecord)
{   // berechnet die Anzahl der Siege für jedes Rennen in der tRace-Liste und multipliziert sie
    return tRace
        .AsParallel () //  Liste in eine parallele Sequenz umzuwandeln (PLINQ)
        .Select     ((t, game)         => Enumerable.Range(0, (int)t + 1)
        .Count      (v                 => v * (t - v) > dRecord[game]))
        .Aggregate  (1L, (beats, wins) => beats * wins);
}

string[] lines = System.IO.File.ReadAllLines(@"C:\Users\guent\OneDrive\anp_GF07\aoc2023\C#\aoc06\Input6.txt");
Console.WriteLine($"AoC2023 Day6 Part1 {solve(getList(lines[0])                 , getList(lines[1]))                 }");
Console.WriteLine($"AoC2023 Day6 Part2 {solve(getList(lines[0].Replace(" ", "")), getList(lines[1].Replace(" ", "")))}");