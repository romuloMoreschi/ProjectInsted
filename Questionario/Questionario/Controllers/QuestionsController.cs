using Microsoft.AspNetCore.Mvc;
using Questionario.Models;
using Questionario.Services;
using System.Diagnostics;

namespace Questionario.Controllers;

public class QuestionsController : Controller
{
    private static JsonDataManager jsonDataManager = null!;
    private static List<QuestionModel> questions = null!;

    private readonly ILogger<QuestionsController> _logger;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public QuestionsController(ILogger<QuestionsController> logger, IWebHostEnvironment webHostEnvironment)
    {
        _logger = logger;
        _webHostEnvironment = webHostEnvironment;

        if (jsonDataManager == null)
        {
            var jsonFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", "questions.json");
            jsonDataManager = new JsonDataManager(jsonFilePath);
        }

        questions ??= jsonDataManager.ReadData();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(QuestionModel question)
    {
        questions.Add(question);
        jsonDataManager.WriteData(questions);
        return RedirectToAction("Display");
    }

    public IActionResult Display()
    {
        questions = jsonDataManager.ReadData();
        return View(questions);
    }

    [HttpGet]
    public JsonResult CheckAnswer(int questionId, int optionId, bool isChecked)
    {
        var question = questions.FirstOrDefault(q => q.Id == questionId);

        if (question == null)
            return Json(new { isCorrect = false });

        var selectedOption = question.Options.FirstOrDefault(o => o.Id == optionId);

        if (selectedOption == null)
            return Json(new { isCorrect = false });

        var isCorrect = selectedOption.IsCorrect && isChecked;

        return Json(new { isCorrect });
    }

    [HttpGet]
    public JsonResult GetCorrectAnswer(int questionId)
    {
        var question = questions.FirstOrDefault(q => q.Id == questionId);

        var correctAnswer = question!.Options.FirstOrDefault(o => o.IsCorrect == true)!.Id;

        return Json(new { correctAnswer });
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
