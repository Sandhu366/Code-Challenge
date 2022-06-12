using System;

namespace Common.Errors
{
    public class RemarkNotSavedException: Exception
    {
        public RemarkNotSavedException(string message): base(message)
        {
        }
    }
}
