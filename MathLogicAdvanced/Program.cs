using MathLogicAdvanced.Resolutions;

var clauses = new List<Clause>();
////clauses = new List<Clause>()
////    {
////        new Clause(new List<string>{"!S", "H"}),
////        new Clause(new List<string>{"!H", "A"}),
////        new Clause(new List<string>{"!A", "D"})
////    };
////Clause query = new Clause(new List<string> { "!S", "!D" });
//clauses = new List<Clause>()
//    {
//        new Clause(new List<string>{"!N", "S"}),
//        new Clause(new List<string>{"!P", "M"}),
//        new Clause(new List<string>{"!S", "!G"}),
//        new Clause(new List<string>{"!M", "N"}),
//    };
//Clause query = new Clause(new List<string> { "!M", "!G" });

//Resolution resolution = new Resolution();
//query.Literals[1] = Resolution.Negate(query.Literals[1]);
//bool result = resolution.Resolve(clauses, query);

//query.Literals[1] = Resolution.Negate(query.Literals[1]);
//Console.WriteLine($"Результат резолютивного вывода для запроса {string.Join(" | ",query.Literals)}: {result}");

Console.WriteLine("Введите импликации в формате 'A -> B' (введите 'done' для завершения ввода):");

while (true)
{
    var input = Console.ReadLine();
    if (input.ToLower() == "done")
    {
        break;
    }

    var parts = input.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length == 2)
    {
        var premise = parts[0].Trim();
        var conclusion = parts[1].Trim();
        clauses.Add(new Clause(new List<string> { "!" + premise, conclusion }));
    }
    else
    {
        Console.WriteLine("Неверный ввод. Пожалуйста, используйте формат 'A -> B'.");
    }
}

Console.WriteLine("Введите запрос в формате 'A -> B':");

var queryInput = Console.ReadLine();
var queryParts = queryInput.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);

if (queryParts.Length == 2)
{
    var queryPremise = queryParts[0].Trim();
    var queryConclusion = queryParts[1].Trim();
    var query = new Clause(new List<string> { "!" + queryPremise, queryConclusion });
    Resolution resolution = new Resolution();
    query.Literals[1] = Resolution.Negate(query.Literals[1]);
    bool result = resolution.Resolve(clauses, query);

    query.Literals[1] = Resolution.Negate(query.Literals[1]);
    Console.WriteLine($"Результат резолютивного вывода для запроса {string.Join(" | ", query.Literals)}: {result}");

}
else
{
    Console.WriteLine("Неверный запрос. Пожалуйста, используйте формат 'A -> B'.");
}
