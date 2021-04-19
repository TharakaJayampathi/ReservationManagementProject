using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationManagement.Application
{
    public class Result
    {
        public object Data { get; set; }

        public int StatusCode { get; set; }

        public string Message { get; set; }





        public static Result Success(object data)
        {
            return new Result()
            {
                Data = data,
                StatusCode = 200,
                Message = "Success"
            };


        }

        public static Result Unsuccess(string message, int code = 400)
        {
            return new Result()
            {
                Data = null,
                StatusCode = code,
                Message = message
            };

        }


        public static Result Failed(string message = "Fail")
        {
            return new Result()
            {
                Data = null,
                StatusCode = 500,
                Message = message

            };

        }

        public static Result NotFound()
        {
            return new Result()
            {
                Data = null,
                StatusCode = 404,
                Message = "Not Found"
            };
        }

    }
}
