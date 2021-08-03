namespace Mumbi.Application.Parameters
{
    public class RequestParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 10;

        public RequestParameter()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public RequestParameter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize;
        }
    }
}