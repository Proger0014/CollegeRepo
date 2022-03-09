using System;
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
    /// <summary>
    /// Содержит Методы, для работы с вопросами
    /// </summary>
    public class TestingEngine
    {
        public int Score { get; private set; } = 0;
        public int SolveAnswers { get; private set; } = 0;

        private void AddResults()
        {
            Score++;
            SolveAnswers++;
        }

        public void PrintQuestions(List<Questions> questions)
        {
            foreach (var question in questions)
            {
                ShowQuestionAndAnswers(question);
            }

            PrintResult(questions.Count);
        }

        private void ShowQuestionAndAnswers(Questions question)
        {
            // Типо, теперь он должен вывести все вопросы
            // По оформлению можно выбрать: 2 вопроса  на столбец
            var quest = question.Question;
            var answers = question.Answers;
            var answerIndex = question.AnswerIndex;

            //int countShow = 0;

            //Console.WriteLine(quest);
            //foreach (var answer in answers)
            //{
            //    Console.Write($"* {answer}");
            //    countShow++;

            //    if (countShow == 2)
            //    {
            //        countShow = 0;
            //        Console.WriteLine();
            //    }
            //}

            for (int i = 0; i < answers.Count; i++)
            {
                Console.Write($"{i + 1}. {answers[i]}");

                // Чтоб печатать по 2 в строке
                if (i % 2 == 0)
                {
                    Console.WriteLine();
                }
            }

            // теперь нужно перенаправить в метод, в котором уже будет осуществляться выбор ответа
            DoAnswer(question);
        }

        // Очистка Поля ввода вопроса и установка курсора в точке ввода
        private void ClearAnswerField((int, int) cursosPosition)
        {
            Console.SetCursorPosition(cursosPosition.Item1, cursosPosition.Item2);
            Console.Write(String.Empty.PadLeft(4, ' '));
            Console.SetCursorPosition(cursosPosition.Item1, cursosPosition.Item2);
        }

        // Штука, которая будет просто выводиться
        private (int, int) PrintAnswerField()
        {
            (int, int) cursorPositions = (0, 0);

            Console.Write(String.Empty.PadLeft(20, '='));
            Console.Write("\n=\tВведите ответ:  \t=");
            cursorPositions = (Console.CursorLeft - 10, Console.CursorTop);
            Console.Write("\n" + String.Empty.PadLeft(20, '='));

            Console.SetCursorPosition(cursorPositions.Item1, cursorPositions.Item2);

            return cursorPositions;
        }
        private void DoAnswer(Questions question)
        {
            // Сделать цикл, который будет предлагать ввести правильный ответ, пока не введешь правильный
            // Также, чтоб с каждым неправильным вводом очищалось только поле, где ты вводил
            var cursorPositions = PrintAnswerField();
            string actualAnswerString =  Console.ReadLine();
            List<int> actualAnswer = actualAnswerString.Split(' ').Select(num => int.Parse(num)).ToList();

            int countChance = 3;
            while (!question.IsAnswer(actualAnswer))
            {
                countChance--;

                if (countChance <= 0)
                {
                    return;
                }

                ClearAnswerField(cursorPositions);
            }

            AddResults();
        }

        private void PrintResult(int questionsCount)
        {
            Console.WriteLine('=' * 20);
            if (Score >= questionsCount / 25)
            {
                Console.WriteLine($"Поздравляем, вы решили все {SolveAnswers}/{questionsCount} вопросов и набрали {Score} очков!");
            }
            else if (Score >= questionsCount / 50)
            {
                Console.WriteLine($"Поздравляем, вы решили {SolveAnswers}/{questionsCount} вопросов и набрали {Score} очков!");
            }
            else if (Score >= questionsCount / 75)
            {
                Console.WriteLine($"Неплохо, вы решили {SolveAnswers}/{questionsCount} вопросов и набрали {Score} очков!");
            }
            else
            {
                Console.WriteLine($"Плохо, вы решили всего {SolveAnswers}/{questionsCount} вопросов и набрали {Score} очков!");
            }
            Console.WriteLine('=' * 20);
        }
    }

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
    }

    public static class ExtQuestions
    {
        public static bool IsAnswer(this Questions question, List<int> actualAnswer) => actualAnswer.Equals(question.AnswerIndex) ? true : false;
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var questions = new List<Questions>();

            // А это радиобатон
            questions.Add(new Questions(
                "Какие есть ящики тестирования",
                new List<int>() { 1 },
                "3 ящика тестирования: белый, черный и серый",
                "1 ящик тестирования: красный",
                "13 ящиков тестирования"));
            
            // типо, это будет чек бокс
            questions.Add(new Questions(
                "Какие есть методы тестирования",
                new List<int>() { 1, 2, 3},
                "Тестирование системы",
                "Тестирование интеграции",
                "Приемочные испытания системы",
                "Водоемочные испытания системы"
                ));

            TestingEngine testingEngine = new TestingEngine();
            testingEngine.PrintQuestions(questions);
        }
    }
}
