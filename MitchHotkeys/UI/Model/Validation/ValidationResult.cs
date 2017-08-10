using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchHotkeys.UI.Model.Validation
{
    public class ValidationResults : List<ValidationResult>
    {
        
    }

    public class ValidationResult
    {
        private List<ValidationException> _errors;
        private ValidationResultStatus _status = ValidationResultStatus.Invalidated;

        public List<ValidationException> Errors
        {
            get { return _errors; }
            set { _errors = value; }
        }

        public ValidationResultStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public ValidationResult()
        {
            Errors = new List<ValidationException>();
        }

        public bool HasErrors()
        {
            return Status == ValidationResultStatus.Error || Errors.Count > 0;
        }

        public string CommaDelimErrors()
        {
            string finalString = "";
            for(int i = 0; i < Errors.Count; i++)
            {
                ValidationException error = Errors[i];
                finalString += error.Message;
                if (Errors.Count > 1 && i == Errors.Count - 2)
                {
                    finalString += " and ";
                }
                if (i != Errors.Count - 1 && !(Errors.Count > 1 && i == Errors.Count - 2))
                {
                    finalString += ", ";
                }
            }
            return finalString;
        }
    }

    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
           
        }
    }

    public enum ValidationResultStatus
    {
        Invalidated = 0,
        Success = 1,
        Error = 2
    }
}
