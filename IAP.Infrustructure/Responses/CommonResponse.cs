using IAP.Infrustructure.Enums;

namespace IAP.Infrustructure.Responses
{
    public class CommonResponse<T>
    {
        public ResponseStatus Status { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
    }
}
