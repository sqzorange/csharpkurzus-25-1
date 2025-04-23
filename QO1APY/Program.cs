using System.Text.Json;

using QO1APY;
using QO1APY.services;


List<Question> listQuestions = FileService.loadQuestions();

Console.WriteLine(listQuestions[0].text);


Console.ReadKey();

