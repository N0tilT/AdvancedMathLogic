using MathLogicAdvanced.Resolutions;

var clauses = new List<Clause>();

Console.WriteLine("Введите импликации в формате 'A -> B' или просто утверждения (например, 'A'). Нажмите Enter для завершения ввода):");

while (true)
{
    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
    {
        break;
    }

    var parts = input.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length == 2)
    {
        // Обрабатываем импликацию
        var premise = parts[0].Trim();
        var conclusion = parts[1].Trim();
        clauses.Add(new Clause(new List<string> { "!" + premise, conclusion }));
    }
    else if (parts.Length == 1)
    {
        // Обрабатываем утверждение
        var statement = parts[0].Trim();
        clauses.Add(new Clause(new List<string> { statement }));
    }
    else
    {
        Console.WriteLine("Неверный ввод. Пожалуйста, используйте формат 'A -> B' или просто 'A'.");
    }
}

Console.WriteLine("Введите запрос в формате 'A -> B' или просто 'A':");

var queryInput = Console.ReadLine();
var queryParts = queryInput.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);

Clause query;
if (queryParts.Length == 2)
{
    var queryPremise = queryParts[0].Trim();
    var queryConclusion = queryParts[1].Trim();
    query = new Clause(new List<string> { "!" + queryPremise, queryConclusion });
}
else if (queryParts.Length == 1)
{
    var statement = queryParts[0].Trim();
    query = new Clause(new List<string> { statement });
}
else
{
    Console.WriteLine("Неверный запрос. Пожалуйста, используйте формат 'A -> B' или просто 'A'.");
    return; // Выходим из программы при неверном запросе
}

Resolution resolution = new Resolution();
if (query.Literals.Count > 1)
{
    query.Literals[1] = Resolution.Negate(query.Literals[1]);
}
bool result = resolution.Resolve(clauses, query);

if (query.Literals.Count > 1)
{
    query.Literals[1] = Resolution.Negate(query.Literals[1]);
}
Console.WriteLine($"\nРезультат резолютивного вывода для запроса {string.Join(" | ", query.Literals)}: {result}");
