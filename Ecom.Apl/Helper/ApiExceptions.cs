﻿namespace Ecom.Apl.Helper
{
    public class ApiExceptions :ResponseApi
    {
        public ApiExceptions(int statusCode, string message = null, string details = null)
            : base(statusCode, message)
        {
            this.Details = details;
        }

        public string Details { get; set; }
    }

}
