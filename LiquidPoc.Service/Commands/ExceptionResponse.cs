using Liquid.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPoc.Service.Commands
{
    public class ExceptionResponse : LightCustomException
    {
        public ExceptionResponse() : base("Movie not found.", ExceptionCustomCodes.NotFound)
        {
        }
    }
}
