// See https://aka.ms/new-console-template for more information
using MathLogicAdvanced.Chains;
using MathLogicAdvanced.Resolutions;

Console.WriteLine("Hello, World!");

var engine = new Production();

engine.AddFact(new Fact("A", true));
engine.AddFact(new Fact("B", false));

engine.AddRule(new Rule("Rule1",
    facts => facts[0].Value == true && facts[1].Value == false,
    facts => facts[1].Value = true
));

engine.ForwardChain();
System.Console.WriteLine("Факты после прямого вывода:");
engine.DisplayFacts();

string goal = "B";
bool result = engine.BackwardChain(goal);
System.Console.WriteLine($"Обратный вывод: Цель '{goal}' подтверждена? {result}");


var clauses = new List<Clause>
            {
                new Clause(new List<string> { "A", "B" }),   // A ∨ B
                new Clause(new List<string> { "¬A", "C" }), // ¬A ∨ C
                new Clause(new List<string> { "¬B" })        // ¬B
            };

var query = new Clause(new List<string> { "¬C" }); // Запрос ¬C для проверки

bool result = Resolve(clauses, query);
Console.WriteLine($"Результат резолютивного вывода для запроса {string.Join(", ", query.Literals)}: {result}");