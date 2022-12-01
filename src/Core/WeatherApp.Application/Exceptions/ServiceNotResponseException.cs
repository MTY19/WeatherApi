using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Application.Exception
{
	public class ServiceNotResponseException: SystemException
    {

		public ServiceNotResponseException():this("Service get error occured")
		{

		}

        public ServiceNotResponseException(string message) : base(message)
        {

        }

        public ServiceNotResponseException(SystemException ex) : base(ex.Message)
        {

        }

    }
}

