using System.Text.Json;
namespace QO1APY.Services
{
    public class FileService
    {
        public int Count { get; internal set; }

        public static List<Question> LoadQuestions()
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "json", "question.json");
                using (FileStream fs = new(path, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new(fs))
                {
                    string json = sr.ReadToEnd();
                    return JsonSerializer.Deserialize<List<Question>>(json) ?? new();
                }
            }
            catch (IOException)
            {
                throw new IOException("Nem található a kérdések fájlja!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Hiba történt a fájl beolvasásakor: {ex.Message}");
            }

        }

        public void SaveLeaderboard(PlayerResult playerResult)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "json", "leaderboard.json");
            List<PlayerResult> leaderboard = new();

            // Ha létezik már leaderboard, töltsük be
            if (File.Exists(path))
            {
                string jsonRead = File.ReadAllText(path);
                leaderboard = JsonSerializer.Deserialize<List<PlayerResult>>(jsonRead) ?? new();
            }

            leaderboard.Add(playerResult);

            string jsonWrite = JsonSerializer.Serialize(leaderboard, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonWrite);
        }


        public List<PlayerResult> LoadLeaderboard()
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "json", "leaderboard.json");
                using (FileStream fs = new(path, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new(fs))
                {
                    string json = sr.ReadToEnd();
                    return JsonSerializer.Deserialize<List<PlayerResult>>(json) ?? new();
                }

            }
            catch (IOException)
            {
                throw new IOException("Nem található a leaderboard fájlja!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Hiba történt a fájl beolvasásakor: {ex.Message}");
            }
        }
    }
}