
namespace WebKillaDeco.Helpers
{
    public static class MessageTemplates
    {
        public static string GetDeleteMessage(string entityName)
        {
            return $"¿Realmente desea eliminar {GetArticle(entityName)} {entityName}?";

        }
        
        public static string GetCategoryDetails(string entityName)
        {
            return $"¿Detalles de {entityName}?";
        }

        private static String GetArticle(String entityName)
        {
            return entityName[entityName.Length - 1] == 'o' ? "este" : "esta";
            
        }

       
    }
}
