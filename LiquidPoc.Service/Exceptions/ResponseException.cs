using Liquid.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPoc.Service.Exceptions
{
    public class ResponseException : LightCustomException
    {
        public ResponseException(string message, ExceptionCustomCodes responseCode) : base(message, responseCode)
        {
        }
    }
}
