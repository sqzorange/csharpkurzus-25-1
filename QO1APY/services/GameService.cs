

namespace QO1APY.Services
{
    public static class GameService
    {
        public static void StartGame()
        {
            Console.Clear();
            Console.WriteLine("=== Kvízjáték ===");
            Console.Write("Kérjük, adja meg a nevét: ");
            string playerName = Console.ReadLine() ?? "Névtelen";
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
            Random random = new();
            List<Question> randomQuestions = questions.OrderBy(x => random.Next()).Take(5).ToList();
            int score = 0;

            foreach (var question in randomQuestions)
            {
                int selectedAnswer = 0;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(question.text);
                    Console.WriteLine("\nVálaszok:");

                    for (int i = 0; i < question.listAnswers.Count; i++)
                    {
                        if (i == selectedAnswer)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"> {question.listAnswers[i]}");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine($"  {question.listAnswers[i]}");
                        }
                    }

                    ConsoleKey key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.UpArrow)
                        selectedAnswer = (selectedAnswer - 1 + question.listAnswers.Count) % question.listAnswers.Count;
                    else if (key == ConsoleKey.DownArrow)
                        selectedAnswer = (selectedAnswer + 1) % question.listAnswers.Count;
                    else if (key == ConsoleKey.Enter)
                        break;
                }

                if (selectedAnswer == question.correctIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nHelyes válasz!");
                    score++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nHibás válasz! A helyes válasz: {question.listAnswers[question.correctIndex]}");
                }

                Console.ResetColor();
                Thread.Sleep(2000);
            }

            Console.Clear();
            Console.WriteLine($"\nJáték vége! {playerName}, az elért pontszámod: {score} / {randomQuestions.Count}");
        }


        public static void ShowLeaderboard()
        {
        }
    }
}
