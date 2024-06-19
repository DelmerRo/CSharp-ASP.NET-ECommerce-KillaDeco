
using Microsoft.AspNetCore.Mvc;

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

        internal static string GetPropertyIsRequired(string propertyName)
        {
            return $" {propertyName} es requerido?";
        }

        internal static string GetErrorSaving(string entityName)
        {
            return $"Se produjo un error al intentar guardar el/la {entityName}. Por favor, inténtelo de nuevo más tarde. Si el problema persiste, contacte al soporte técnico.";

        }
    }
}
