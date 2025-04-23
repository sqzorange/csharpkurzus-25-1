using QO1APY;


Console.WriteLine("Hello, World!");

Question question = new Question("Kérdés", new List<string> { "a", "b", "c" }, 1, "easy");
Console.WriteLine(question.text);
Console.WriteLine(question.listAnswers[0]);
Console.WriteLine(question.listAnswers[1]);
Console.WriteLine(question.listAnswers[2]);

Console.WriteLine(question.correctIndex);
Console.WriteLine(question.difficulty);

PlayerResult playerResult = new PlayerResult("Név", 100, DateTime.Now);
Console.WriteLine(playerResult.Name);
Console.WriteLine(playerResult.Score);
Console.WriteLine(playerResult.Date);

Console.ReadKey();