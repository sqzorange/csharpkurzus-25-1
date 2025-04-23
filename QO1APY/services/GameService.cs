

namespace QO1APY.Services
{
    public static class GameService
    {
        public static void StartGame()
        {
            Console.WriteLine("Üdvözöljük a Kvízjátékban!");
            Console.Write("Kérjük, adja meg a nevét:");
            string playerName = Console.ReadLine() ?? "Név nélkül";
            Console.Clear();

            Console.WriteLine($"Üdvözöljük, {playerName}! Készen áll a játékra? (I/N)");
            string startGame = Console.ReadLine() ?? "N";

            Console.Clear();

            if (startGame.ToUpper() != "I")
            {
                Console.WriteLine("A játék leállt.");
                return;
            }

            List<Question> questions = FileService.LoadQuestions();
            if (questions.Count == 0)
            {
                Console.WriteLine("Nincsenek kérdések betöltve.");
                return;
            }

            Random random = new();
            List<Question> randomQuestions = questions.OrderBy(x => random.Next()).Take(5).ToList();
            int score = 0;

            foreach (var question in randomQuestions)
            {
                Console.WriteLine("\n" + question.text);
                Console.WriteLine("Válaszok:");
                for (int j = 0; j < question.listAnswers.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {question.listAnswers[j]}");
                }

                Console.Write("Kérem, válassza ki a helyes választ (1-4): ");
                bool valid = int.TryParse(Console.ReadLine(), out int answerIndex);
                answerIndex--;

                if (!valid || answerIndex < 0 || answerIndex >= question.listAnswers.Count)
                {
                    Console.WriteLine($"Érvénytelen válasz! A helyes válasz: {question.listAnswers[question.correctIndex]}");
                }
                else if (answerIndex == question.correctIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    score++;
                    Console.WriteLine("Helyes válasz!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Hibás válasz! A helyes válasz: {question.listAnswers[question.correctIndex]}");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.ResetColor();
                }
            }
            Console.WriteLine($"\nJáték vége! Elért pontszám: {score} / {randomQuestions.Count}");
        }
    }
}
