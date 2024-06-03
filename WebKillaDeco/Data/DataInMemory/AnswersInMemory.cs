using WebKillaDeco.Models;

namespace WebKillaDeco.Data.DataInMemory
{
    public class AnswerInMemory
    {
        public static List<Answer> GetAnswers()
        {
            List<Answer> answers = new()
            {
                new Answer
                {
                    EmployeeId = 1,
                    QuestionId = 1,
                    description = "El material de este producto es acero inoxidable.",
                    publicationDate = DateTime.Now.AddDays(-10)
                },
                new Answer
                {
                    EmployeeId = 2,
                    QuestionId = 2,
                    description = "Sí, este producto tiene garantía de 1 año.",
                    publicationDate = DateTime.Now.AddDays(-8)
                },
                new Answer
                {
                    EmployeeId = 3,
                    QuestionId = 3,
                    description = "El tiempo de envío estimado es de 5 a 7 días hábiles.",
                    publicationDate = DateTime.Now.AddDays(-6)
                },
                new Answer
                {
                    EmployeeId = 4,
                    QuestionId = 4,
                    description = "Sí, este producto es apto para lavavajillas.",
                    publicationDate = DateTime.Now.AddDays(-4)
                },
                new Answer
                {
                    EmployeeId = 5,
                    QuestionId = 5,
                    description = "No, este producto no incluye pilas.",
                    publicationDate = DateTime.Now.AddDays(-2)
                },
                new Answer
                {
                    EmployeeId = 6,
                    QuestionId = 4,
                    description = "Este producto está disponible en varios colores: rojo, azul y verde.",
                    publicationDate = DateTime.Now.AddDays(-1)
                },
                new Answer
                {
                    EmployeeId = 7,
                    QuestionId = 3,
                    description = "La capacidad de este producto es de 500 ml.",
                    publicationDate = DateTime.Now.AddDays(-7)
                },
                new Answer
                {
                    EmployeeId = 8,
                    QuestionId = 2,
                    description = "Sí, este producto es resistente al agua.",
                    publicationDate = DateTime.Now.AddDays(-5)
                },
                new Answer
                {
                    EmployeeId = 9,
                    QuestionId = 1,
                    description = "No, este producto no requiere montaje.",
                    publicationDate = DateTime.Now.AddDays(-3)
                },
                new Answer
                {
                    EmployeeId = 10,
                    QuestionId = 4,
                    description = "Sí, este producto viene con garantía extendida de 2 años.",
                    publicationDate = DateTime.Now
                }
            };

            return answers;
        }
    }
}
