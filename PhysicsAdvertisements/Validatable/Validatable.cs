// Validatable.cs
namespace Validatable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Adds validation methods to objects using <see cref="System.ComponentModel.DataAnnotations"/>.
    /// </summary>
    /// <typeparam name="T">Type of the inheriting object</typeparam>
    [Serializable]
    public abstract class Validatable<T> : IValidatable where T : class, new()
    {
        public virtual Type EntityType { get; set; }
        public virtual List<object> Errors { get; set; }
        protected Validatable()
        {
            Errors = new List<object>();
            EntityType = typeof(T);
        }
        public virtual bool IsValid()
        {
            Errors = new List<object>();
            PropertyInfo[] props = this.GetType().GetProperties();

            foreach (PropertyInfo property in props)
            {
                foreach (ValidationAttribute va in
                    property.GetCustomAttributes(true).OfType<ValidationAttribute>())
                {
                    var value = property.GetValue(this, null);
                    if (!va.IsValid(value))
                    {
                        Errors.Add(va.ErrorMessage);
                    }
                }
            }

            return Errors.Count <= 0;
        }

        public virtual void Validate(Action action)
        {
            if (IsValid())
            {
                action();
            }
        }

        public virtual void Validate(object repository)
        {
            MethodInfo method = repository.GetType().GetMethods()
                .Where(x => x.Name.Equals("Validate")).FirstOrDefault();
            if (method != null)
            {
                object[] parameters = new object[] { this };
                Validate(() => method.Invoke(repository, parameters));
            }
        }
    }
}