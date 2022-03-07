using Microsoft.AspNetCore.Mvc;

namespace HomeworkOne.Models.Result
{
    public interface IResult
    {
        public bool Success { get; set; }
        public string Error { get; set; }

        public string Data { get; }
        
    }
}
