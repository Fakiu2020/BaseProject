using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Whoever.Common;
using Whoever.Common.Result;

namespace Whoever.Web.Responses
{
    public class ServiceErrorResult
    {

        #region Constructors

        public ServiceErrorResult()
        {
            ModelState = new ModelStateDictionary();
            Notifications = new Dictionary<string, ICollection<string>>();
        }

        public ServiceErrorResult(ModelStateDictionary modelState)
        {
            ModelState = modelState;
            Notifications = new Dictionary<string, ICollection<string>>();
        }

        public ServiceErrorResult(Dictionary<string, ICollection<string>> errors)
        {
            ModelState = new ModelStateDictionary();
            Notifications = new Dictionary<string, ICollection<string>>();
            AddErrors(errors);
        }

        public ServiceErrorResult(ServiceResultBase result)
        {
            ModelState = new ModelStateDictionary();
            Notifications = new Dictionary<string, ICollection<string>>();
            AddNotifications(result.Notifications);
            AddErrors(result.Errors);
        }

        

        #endregion

        #region Properties

        [JsonIgnore]
        public readonly ModelStateDictionary ModelState;

        public Dictionary<string, IEnumerable<string>> Errors
        {
            get
            {
                return ModelState.ToDictionary(kvp => kvp.Key.Substring(kvp.Key.IndexOf('.') + 1),
                                             kvp => kvp.Value.Errors.Select(y => y.ErrorMessage));
            }
        }

        public Dictionary<string, ICollection<string>> Notifications { get; set; }

        [JsonIgnore]
        public bool HasErrors => Errors.Count > 0;

        #endregion

        #region Methods

        public void AddErrors(ModelStateDictionary modelState)
        {
            ModelState.Merge(modelState);
        }

        public void AddErrors(Dictionary<string, ICollection<string>> errors)
        {
            foreach (var err in errors)
            {
                foreach (var message in err.Value)
                {
                    ModelState.AddModelError(err.Key, message);
                }
            }
        }

        public void AddError(string key, string value)
        {
            ModelState.AddModelError(key, value);
        }

        private void AddNotifications(List<KeyValuePair<NotificationType, string>> notifications)
        {
            foreach (var keyValue in notifications)
            {
                if (Notifications.ContainsKey(keyValue.Key.ToString()))
                {
                    Notifications[keyValue.Key.ToString()].Add(keyValue.Value);
                    return;
                }

                Notifications.Add(keyValue.Key.ToString(), new List<string>() { keyValue.Value });
            }
        }

        #endregion
    }
}
