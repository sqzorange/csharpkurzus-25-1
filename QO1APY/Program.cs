
Console.WriteLine("Hello, World!");

Question question = new Question("Kérdés", new List<string> { "a", "b", "c" }, 1, "easy");
Console.WriteLine(question.text);
Console.WriteLine(question.listAnswers);
Console.WriteLine(question.correctIndex);
Console.WriteLine(question.difficulty);