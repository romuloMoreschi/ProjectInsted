using Newtonsoft.Json;
using Questionario.Models;

namespace Questionario.Services;

public class JsonDataManager
{
    private string jsonFilePath;

    public JsonDataManager(string filePath)
    {
        jsonFilePath = filePath;
    }

    public List<QuestionModel> ReadData()
    {
        if (File.Exists(jsonFilePath))
        {
            try
            {
                var json = File.ReadAllText(jsonFilePath);
                var questions = JsonConvert.DeserializeObject<List<QuestionModel>>(json)!;
                ShuffleQuestionsAndOptions(questions);
                return questions;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao ler o arquivo JSON: {ex.Message}");
            }
        }
        else
        {
            return new List<QuestionModel>();
        }
    }

    public void WriteData(List<QuestionModel> questions)
    {
        try
        {
            var json = JsonConvert.SerializeObject(questions, Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao escrever no arquivo JSON: {ex.Message}");
        }
    }

    private static void ShuffleQuestionsAndOptions(List<QuestionModel> questions)
    {
        var random = new Random();
        var n = questions.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            var value = questions[k];
            questions[k] = questions[n];
            questions[n] = value;

            ShuffleOptions(value.Options);
        }
    }

    private static void ShuffleOptions(List<OptionModel> options)
    {
        Random random = new Random();
        int n = options.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            var value = options[k];
            options[k] = options[n];
            options[n] = value;
        }
    }
}
