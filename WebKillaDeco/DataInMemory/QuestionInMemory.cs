using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
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
                    Description = "¿Cuál es el material de este producto?",
                    PublicationDate = DateTime.Now.AddDays(-10)
                },
                new Question
                {
                    ClientId = 2,
                    ProductId = 2,
                    Description = "¿Tiene garantía este producto?",
                    PublicationDate = DateTime.Now.AddDays(-8)
                },
                new Question
                {
                    ClientId = 3,
                    ProductId = 3,
                    Description = "¿Cuánto tiempo tarda en llegar el envío?",
                    PublicationDate = DateTime.Now.AddDays(-6)
                },
                new Question
                {
                    ClientId = 4,
                    ProductId = 4,
                    Description = "¿Es apto para lavavajillas?",
                    PublicationDate = DateTime.Now.AddDays(-4)
                },
                new Question
                {
                    ClientId = 5,
                    ProductId = 5,
                    Description = "¿Viene con pilas incluidas?",
                    PublicationDate = DateTime.Now.AddDays(-2)
                }
            };

            return questions;
        }
    }
}
