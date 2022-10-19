using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Dto.Response
{
    public class ReturnDto
    {
        public bool ThereError { get; set; }
        public string? TitleError { get; set; }
        public string? MessageError { get; set; }
        public string? CodeError { get; set; }
        public string? ObjectReturn { get; set; }
        public ReturnErrorCustomize? ReturnErrorCustomize { get; set; }

        public CreatedResult ReturnResult(string roteRequest)
        {
            ProblemDetails problemDetails = new ProblemDetails();
            problemDetails.Status = int.Parse(CodeError);
            problemDetails.Type = "";
            problemDetails.Detail = MessageError;
            problemDetails.Title = TitleError;
            problemDetails.Instance = roteRequest;

            CreatedResult createdResult = new("", null);
            createdResult.StatusCode = int.Parse(CodeError);
            createdResult.Value = problemDetails;

            return createdResult;
        }
    }
}
