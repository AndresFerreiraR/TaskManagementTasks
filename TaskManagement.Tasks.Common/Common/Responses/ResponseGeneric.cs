using TaskManagement.Tasks.Common.Common.Errors;

namespace TaskManagement.Tasks.Common.Common.Responses
{
    public class ResponseGeneric<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public IEnumerable<BaseError> Errors { get; set; }
    }
}