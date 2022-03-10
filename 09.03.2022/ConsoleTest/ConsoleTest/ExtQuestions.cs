using System.Collections.Generic;

/******************
 * Тип, есть движок для тестов. Он хранит кол-во очков.
 * Можно будет в этот движок передать, сколько процентов от общего кол-вол вопросов решено
 * И на основе этого выдавать нужную оценку.
 * Тип, если Score = 10, а вопросов 100, то это будет плохо. Тип, ты ничего не знаешь
 ******************/
namespace ConsoleTest
{
    public static class ExtQuestions
    {
        public static bool IsAnswer(this Questions question, List<int> actualAnswer) => question.Equals(actualAnswer) ? true : false;
    }
}
