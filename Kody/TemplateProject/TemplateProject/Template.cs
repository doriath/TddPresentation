using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TemplateProject
{
    public class Template
    {
        private readonly Dictionary<string, string> _variables;
        private readonly string _templateText;
        private string _value;

        public Template(string templateText)
        {
            _templateText = templateText;
            _variables = new Dictionary<string, string>();
        }

        public void Set(string name, string value)
        {
            _variables.Add(name, value);
        }

        public string Evaluate()
        {
            string result = ReplaceVariables();
            CheckForMissingVariables(result);
            return result;
        }

        private string ReplaceVariables()
        {
            string result = _templateText;
            foreach(var variable in _variables)
            {
                result = result.Replace("${" + variable.Key + "}", variable.Value);
            }
            return result;
        }

        private void CheckForMissingVariables(string result)
        {
            Match regex = Regex.Match(result, @"\$\{([^\}]*)\}");
            if (regex.Success)
            {
                throw new MissingValueException(regex.Groups[1].Value);
            }
        }
    }
}