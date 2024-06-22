
namespace WebKillaDeco.Helpers
{
    public static class ErrorMsgs
    {
        public const string Required = "El campo {0} es requerido";
        public const string RangeMinMax = "El campo {0} debe estar comprendido entre {1} y {2}";
        public const string StrMaxMin = "El campo {0}, debe tener un mínimo de {2} y un máximo de {1}";
        public const string DniSize = "El campo {0}, debe tener un máximo de {1}";
        public const string CuilSize = "El campo {0}, debe tener un máximo de {1}";
        public const string CuitSize = "El campo {0}, debe tener un máximo de {1}";
        public const string Generic = "Verifique el ingreso del campo {0}";
        public const string NotValid = "El campo {0} no es válido";
        public const string ErrMsgNotValid = "El ingreso en el campo {0} no es válido";
        public const string PassMismatch = "Las contraseñas no coinciden!!";

        public const string ErrMsgStrLen = "El campo {0} debería tener como mínimo {2} y  como máximo {1} caracteres.";
        public const string ErrMsgRequired = "Este campo es requerido.";
        public const string ErrMsgNotNumeric = "El valor ingresado en el campo {0} debe ser numérico.";
        public const string FormatCelularInvalid = "El numero de celular debe tener un formato 11-1111-1111.";
        public const string QuantityInvalidFiles = "La cantidad de imágenes excede el máximo que es de 4.";

        // New error messages
        public const string EmailFormat = "El formato de {0} no es válido";
        public const string Duplicate = "El campo {0} ya existe";
        public const string MaxLength = "El campo {0} no debe exceder {1} caracteres";
        public const string MinLength = "El campo {0} debe tener al menos {1} caracteres";
        public const string InvalidDate = "El campo {0} debe ser una fecha válida";
        public const string DateRange = "El campo {0} debe estar comprendido entre {1} y {2}";
        public const string PositiveNumber = "El campo {0} debe ser un número positivo";
        public const string IntegerNumber = "El campo {0} debe ser un número entero";
        public const string MinimumValue = "El valor del campo {0} debe ser al menos {1}";
        public const string MaximumValue = "El valor del campo {0} no debe ser mayor que {1}";
        public const string SelectionRequired = "Debe seleccionar un valor para el campo {0}";
        public const string InvalidFormat = "El campo {0} tiene un formato no válido";
        public const string UniqueValue = "El valor del campo {0} debe ser único";
        public const string ComparisonError = "El campo {0} debe ser mayor que {1}";
    }
}
