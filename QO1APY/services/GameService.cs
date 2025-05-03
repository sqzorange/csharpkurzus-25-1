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

            string startGame = "I";
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
            FileService service = new();
            service.SaveLeaderboard(new PlayerResult(playerName, score, DateTime.Now));
        }


        public static void ShowLeaderboard()
        {
            Console.Clear();
            Console.WriteLine("=== Leaderboard ===");

            FileService leaderBoard = new FileService();
            List<PlayerResult> leaderboard = leaderBoard.LoadLeaderboard();

            if (leaderboard.Count == 0)
            {
                Console.WriteLine("A leaderboard üres.");
            }
            else
            {
                foreach (var player in leaderboard.OrderByDescending(x => x.Score))
                {
                    Console.WriteLine($"{player.Name}: {player.Score} pont , {player.Date.ToString("yyyy-MM-dd HH:mm:ss")}");
                }
            }

            Console.WriteLine("\nNyomjon Entert a visszatéréshez a menübe...");
            Console.ReadLine();
        }
    }
}
