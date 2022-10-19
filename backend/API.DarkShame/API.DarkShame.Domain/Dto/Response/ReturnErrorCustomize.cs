using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Dto.Response
{
    public class ReturnErrorCustomize
    {
        public ReturnErrorCustomize(string codeLogErro, string objects, string method)
        {
            CodeLogErro = codeLogErro;
            Object = objects;
            Method = method;
        }

        public string? CodeLogErro { get; set; }
        public string? Object { get; set; }
        public string? Method { get; set; }
    }
}
