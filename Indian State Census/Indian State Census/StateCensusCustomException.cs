using System;
using System.Collections.Generic;
using System.Text;

namespace Indian_State_Census
{
    public class StateCensusCustomException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            FileNotExists,
            ImproperExtension,
            ImproperHeader,
            DelimiterNotFound
        }

        public StateCensusCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
