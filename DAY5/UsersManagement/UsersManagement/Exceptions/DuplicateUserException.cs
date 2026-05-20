using System;
using System.Collections.Generic;
using System.Text;

namespace UsersManagement.Exceptions
{
    public class MatafException : Exception
    {
        public MatafException(string message) : base(message)
        {

        }
    }
    public class DuplicateUserException : MatafException
    {
        public string DuplicateUserId { get; set; }
        public DuplicateUserException(string message) : base(message)
        {

        }
    }
}
