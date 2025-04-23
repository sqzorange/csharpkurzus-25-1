using System.Text.Json;

namespace QO1APY.services
{
    public class FileService
    {
        public static List<Question> loadQuestions()
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "json", "question.json");
                FileStream fs = new(path, FileMode.Open, FileAccess.Read);
                StreamReader sr = new(fs);
                string json = sr.ReadToEnd();
                return JsonSerializer.Deserialize<List<Question>>(json) ?? new();
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
    }
}