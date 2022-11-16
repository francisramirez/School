using System;

namespace School.DAL.Exceptions
{
    public class CourseDataException : Exception
    {
        public CourseDataException(string message) : base(message)
        {
            // X Logica para guardar o enviar la exception
        }
    }
}
