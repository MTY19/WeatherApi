using System;
namespace WeatherApp.Application.Wrappers
{
    public class PagedResponse<T> : ServiceResponse<T>
    {

        public PagedResponse(T value, int pageSize, int pageNumber) : base(value)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public PagedResponse()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

    }
}

