using Microsoft.AspNetCore.Mvc;

namespace HomeworkOne.Models.Result
{
    public class Result : IResult
    {
        public bool Success { get; set; }
        public string Error { get; set; }

        public string Data { get; set; }
    }
}
