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
        private int SolveAnswers { get; set; } = 0;

        private void AddResults()
        {
            Score++;
            SolveAnswers++;
        }

        public void PrintQuestions(List<Questions> questions)
        {
            foreach (var question in questions)
            {
                Console.WriteLine(question.Question + "\n");
                ShowQuestionAndAnswers(question);
            }

            PrintResult(questions.Count);
        }

        private void ShowQuestionAndAnswers(Questions question)
        {
            // Типо, теперь он должен вывести все вопросы
            // По оформлению можно выбрать: 2 вопроса  на столбец
            for (int i = 0; i < question.Answers.Count; i++)
            {
                Console.Write($"{i + 1}. {question.Answers[i]}\t\t");

                // Чтоб печатать по 2 в строке
                if (i % 3 == 0)
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
            Console.Write(String.Empty.PadLeft(6, ' '));
            Console.SetCursorPosition(cursosPosition.Item1, cursosPosition.Item2);
        }

        // Штука, которая будет просто выводиться
        private (int, int) PrintAnswerField()
        {
            (int, int) cursorPositions = (0, 0);

            Console.Write("\n" + String.Empty.PadLeft(20, '='));
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
            List<int> actualAnswer = new List<int>();

            int countChance = 3;
            do
            {
                ClearAnswerField(cursorPositions);
                countChance--;

                if (countChance < 0)
                {
                    return;
                }

                string actualAnswerString = Console.ReadLine();
                actualAnswer = actualAnswerString.Split(' ').Select(num => int.Parse(num) - 1).ToList();
            } while (!question.IsAnswer(actualAnswer));

            AddResults();
            Console.WriteLine();
        }

        private void PrintResult(int questionsCount)
        {
            Console.WriteLine(String.Empty.PadLeft(20, '='));
            if ((double)Score / questionsCount * 1.00 >= 0.9)
            {
                Console.WriteLine($"Поздравляем, вы решили все {SolveAnswers}/{questionsCount} вопросов и набрали {Score} очков!");
            }
            else if ((double)Score / questionsCount >= 0.5 && (double)Score / questionsCount < 0.9)
            {
                Console.WriteLine($"Поздравляем, вы решили {SolveAnswers}/{questionsCount} вопросов и набрали {Score} очков!");
            }
            else
            {
                Console.WriteLine($"Плохо, вы решили всего {SolveAnswers}/{questionsCount} вопросов и набрали {Score} очков!");
            }
            Console.WriteLine(String.Empty.PadLeft(20, '='));
        }
    }
}
