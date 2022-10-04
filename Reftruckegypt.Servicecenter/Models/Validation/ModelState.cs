using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class ModelState : IDataErrorInfo
    {
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public bool HasErrors => _errors.Count > 0;
        public ModelState()
        {

        }
        public ModelState(ModelState other)
        {
            foreach (KeyValuePair<string, List<string>> kvp in other._errors)
            {
                _errors.Add(kvp.Key, kvp.Value);
            }
        }
        public void AddErrors(ModelState modelState)
        {
            foreach (KeyValuePair<string, List<string>> kvp in modelState._errors)
            {
                if (!_errors.ContainsKey(kvp.Key))
                    _errors.Add(kvp.Key, kvp.Value);
                else
                    _errors[kvp.Key].AddRange(kvp.Value);
            }
        }
        public string Error
        {
            get
            {
                return GetError();
            }
        }

        public string this[string columnName] => GetError(columnName);

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
        public IList<string> GetProperties()
        {
            List<string> keys = new List<string>();
            foreach(var k in _errors.Keys)
            {
                keys.Add(k);
            }
            return keys;
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
        public void RemoveErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors[propertyName].Clear();
            }
        }
        public IList<string> GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }
            else
            {
                return new List<string>();
            }
        }
        public string GetError(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach(string str in _errors[propertyName])
                {
                    stringBuilder.AppendLine(str);
                }
                return stringBuilder.ToString();
            }
            return string.Empty;
        }
        public string GetError()
        {
            if (_errors.Count == 0)
                return string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var kvp in _errors)
            {
                foreach (var err in kvp.Value)
                    stringBuilder.AppendLine(err);
            }
            return stringBuilder.ToString();
        }
        public void Clear(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors[propertyName].Clear();
            }
        }
        public void Clear()
        {
            _errors.Clear();
        }
    }
}
