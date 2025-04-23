namespace QO1APY;
public record Question(string text, List<string> listAnswers, int correctIndex, string difficulty);