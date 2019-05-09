using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Whoever.Common.Exceptions
{
    public class ValidationException : NotificationException
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, ICollection<string>>();
        }

        public ValidationException(ICollection<ValidationFailure> failures)
            : this()
        {
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                AddErrors(propertyName, propertyFailures);
            }
        }

        public IDictionary<string, ICollection<string>> Errors { get; set; }

        #region Methods 

        public void AddError(string key, string message)
        {
            if (Errors.ContainsKey(key))
            {
                Errors[key].Add(message);
                return;
            }

            Errors.Add(key, new List<string>() { message });
        }

        public void AddErrors(string key, ICollection<string> errors)
        {
            AddErrors(new Dictionary<string, ICollection<string>>() { { key, errors } });
        }

        public void AddErrors(IDictionary<string, ICollection<string>> errors)
        {
            foreach (var error in errors)
            {
                foreach (var message in error.Value)
                {
                    AddError(error.Key, message);
                }
            }
        }

       

        #endregion
    }
}
