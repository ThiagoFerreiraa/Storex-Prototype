using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorexWebAPI.Services
{
    public class ServiceResponse<T>
    {
        private bool Success {get; set;}
        public string? Message {get; private set;}
        public T? Data {get; set;}
        
        public void SuccessResponse(T? data = default, string? message = default)
        {
            Data = data;
            Message = message;
            Success = true;
        }

        public void FailResponse(T? data = default, string? message = default)
        {
            Data = data;
            Message = message;
            Success = false;
        }

        public bool IsFail()
        {
            return !Success;
        }
    }
}