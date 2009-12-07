using System;

namespace TemplateProject
{
    public class MissingValueException : Exception
    {
        public MissingValueException(string variableName)
            : base("No value for ${" + variableName + "}")
        {
        }
    }
}