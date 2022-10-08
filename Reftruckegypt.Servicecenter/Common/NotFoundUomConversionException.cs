using System;

namespace Reftruckegypt.Servicecenter.Common
{
    public class NotFoundUomConversionException : Exception
    {
        public NotFoundUomConversionException()
            : base()
        {
        }
        public NotFoundUomConversionException(string message)
            : base(message)
        {

        }
        public NotFoundUomConversionException(string message, Exception innerException)
            : base(message, innerException)
        { 
        }

    }
   
}
