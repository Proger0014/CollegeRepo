using System.Collections.Generic;
using System.Linq;

/******************
 * Тип, есть движок для тестов. Он хранит кол-во очков.
 * Можно будет в этот движок передать, сколько процентов от общего кол-вол вопросов решено
 * И на основе этого выдавать нужную оценку.
 * Тип, если Score = 10, а вопросов 100, то это будет плохо. Тип, ты ничего не знаешь
 ******************/
namespace ConsoleTest
{
    public class Questions
    {
        public string Question { get; private set; }
        public List<string> Answers { get; private set; }
        public List<int> AnswerIndex { get; private set; }

        public Questions(string question, List<int> answerIndex, params string[] answers)
        {
            Question = question;

            Answers = new List<string>(answers);
            AnswerIndex = answerIndex;
        }

        public override bool Equals(object? obj)
        {
            List<int> answerIndexes = (List<int>)obj;
            if ((List<int>)obj is null || answerIndexes.Count < AnswerIndex.Count)
            {
                return false;
            }
            else
            {
                if (answerIndexes.Count == 1)
                {
                    return answerIndexes.First() == AnswerIndex.First() ? true : false;
                }

                foreach (int answerIndex in answerIndexes)
                {
                    if (!Contains(AnswerIndex, answerIndex))
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private bool Contains(List<int> expectedAnswer, int actualAnswer) => expectedAnswer.Contains(actualAnswer);
    }
}
