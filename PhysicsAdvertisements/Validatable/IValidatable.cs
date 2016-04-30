namespace Validatable
{
    interface IValidatable
    {
        System.Type EntityType { get; set; }
        System.Collections.Generic.List<object> Errors { get; set; }

        /// <summary>
        /// Determine whether the object is valid.  If invalid, errors are added to item.Errors
        /// </summary>
        /// <returns>true if valid, false if invalid</returns>
        bool IsValid();

        /// <summary>
        /// Validate this item against a supplied action
        /// </summary>
        /// <param name="action">The action to use for validation</param>
        void Validate(System.Action action);

        /// <summary>
        /// Validate this object against a Repository.
        /// <example>
        /// Item a = new Item();
        /// a.Validate(new ItemRepository());
        /// </example>
        /// Note: Repository must have a Validate(T item) method
        /// </summary>
        /// <param name="repository">The Repository to use for validation</param>
        void Validate(object repository);
    }
}
