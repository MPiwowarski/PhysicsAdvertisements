// DataAnnotationValidator.cs
//http://www.ipreferjim.com/2010/05/system-componentmodel-dataannotations-for-asp-net-web-forms/
namespace Validatable
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    [ToolboxData("<{0}:DataAnnotationValidator runat=\"server\" ControlToValidate=\"[Required]\" Display=\"Dynamic\" Text=\"*\" SourceTypeName=\"[FullyQualifiedTypeName]\" PropertyToValidate=\"[PropertyName]\" />")]
    public class DataAnnotationValidator : BaseValidator
    {
        /// <summary>
        /// THe Property that should be checked
        /// </summary>
        public string PropertyToValidate { get; set; }

        /// <summary>
        /// The object's type
        /// </summary>
        public string SourceTypeName { get; set; }

        protected override bool EvaluateIsValid()
        {
            Type source = GetValidatedType();
            PropertyInfo property = GetValidatedProperty(source);
            string value = GetControlValidationValue(ControlToValidate);

            foreach (ValidationAttribute va in property
                .GetCustomAttributes(typeof(ValidationAttribute), true)
                .OfType<ValidationAttribute>())
            {
                if (!va.IsValid(value))
                {
                    if (ErrorMessage!=null)
                    {
                        this.ErrorMessage = va.ErrorMessage;
                        this.Text= va.ErrorMessage;
                    }
                    return false;
                }
            }

            return true;
        }

        private Type GetValidatedType()
        {
            if (string.IsNullOrEmpty(SourceTypeName))
            {
                throw new InvalidOperationException("Null SourceTypeName can't be validated");
            }

            Type validatedType = Type.GetType(SourceTypeName);
            if (validatedType == null)
            {
                throw new InvalidOperationException(
                    string.Format("{0}:{1}", "Invalid SourceTypeName", SourceTypeName));
            }

            return validatedType;
        }

        private PropertyInfo GetValidatedProperty(Type source)
        {
            PropertyInfo property = source.GetProperty(PropertyToValidate,
              BindingFlags.Public | BindingFlags.Instance);

            if (property == null)
            {
                throw new InvalidOperationException(
                  string.Format("{0}:{1}", "Validated Property Does Not Exists", PropertyToValidate));
            }
            return property;
        }
    }
}
