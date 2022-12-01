using System;
using MediatR;

namespace WeatherApp.Application.Exception
{
    public class NotFoundUserException : SystemException
    {

        public NotFoundUserException() : this("Error Occured")
        {

        }

        public NotFoundUserException(string message) : base(message)
        {

        }

        public NotFoundUserException(SystemException ex) : base(ex.Message)
        {

        }

    }
}

