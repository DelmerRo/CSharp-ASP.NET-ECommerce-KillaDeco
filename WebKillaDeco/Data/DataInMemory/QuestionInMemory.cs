using WebKillaDeco.Models;

namespace WebKillaDeco.Data.DataInMemory
{
    public class QuestionInMemory
    {
        public static List<Question> GetQuestions()
        {
            List<Question> questions = new()
            {
                new Question
                {
                    ClientId = 1,
                    ProductId = 1,
                    description = "¿Cuál es el material de este producto?",
                    publicationDate = DateTime.Now.AddDays(-10)
                },
                new Question
                {
                    ClientId = 2,
                    ProductId = 2,
                    description = "¿Tiene garantía este producto?",
                    publicationDate = DateTime.Now.AddDays(-8)
                },
                new Question
                {
                    ClientId = 3,
                    ProductId = 3,
                    description = "¿Cuánto tiempo tarda en llegar el envío?",
                    publicationDate = DateTime.Now.AddDays(-6)
                },
                new Question
                {
                    ClientId = 4,
                    ProductId = 4,
                    description = "¿Es apto para lavavajillas?",
                    publicationDate = DateTime.Now.AddDays(-4)
                },
                new Question
                {
                    ClientId = 5,
                    ProductId = 5,
                    description = "¿Viene con pilas incluidas?",
                    publicationDate = DateTime.Now.AddDays(-2)
                }
            };

            return questions;
        }
    }
}
