using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class ModelState
    {
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public bool HasErrors => _errors.Count > 0;
        public void AddError(string propertyName, string errorMessage)
        {
            if (_errors.ContainsKey(propertyName))
            {
                if (_errors[propertyName] == null)
                    _errors[propertyName] = new List<string>();
                _errors[propertyName].Add(errorMessage);
            }
            else
            {
                _errors.Add(propertyName, new List<string>() { errorMessage });
            }
        }
        public void AddErrors(string propertyName, IEnumerable<string> errors)
        {
            if (_errors.ContainsKey(propertyName))
            {
                if (_errors[propertyName] == null)
                    _errors[propertyName] = new List<string>();
                _errors[propertyName].AddRange(errors);
            }
            else
            {
                _errors.Add(propertyName, new List<string>(errors) {});
            }
        }
    }
}
