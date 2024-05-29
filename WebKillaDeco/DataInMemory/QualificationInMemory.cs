using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public class QualificationInMemory
    {
        public static List<Qualification> GetQualifications()
        {
            List<Qualification> qualifications = new()
            {
                new Qualification
                {
                    ProductId = 1,
                    ClientId = 1,
                    Rating = 5,
                    Comment = "Excelente producto",
                    DateQualification = DateTime.Now.AddDays(-5)
                },
                new Qualification
                {
                    ProductId = 2,
                    ClientId = 2,
                    Rating = 4,
                    Comment = "Buen producto",
                    DateQualification = DateTime.Now.AddDays(-3)
                },
                new Qualification
                {
                    ProductId = 3,
                    ClientId = 3,
                    Rating = 3,
                    Comment = "Producto aceptable",
                    DateQualification = DateTime.Now.AddDays(-2)
                },
                new Qualification
                {
                    ProductId = 4,
                    ClientId = 4,
                    Rating = 2,
                    Comment = "Producto regular",
                    DateQualification = DateTime.Now.AddDays(-1)
                },
                new Qualification
                {
                    ProductId = 5,
                    ClientId = 5,
                    Rating = 1,
                    Comment = "Producto insatisfactorio",
                    DateQualification = DateTime.Now
                }
            };

            return qualifications;
        }
    }
}
