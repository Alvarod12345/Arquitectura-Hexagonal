using API.Infrastructure.Extensions;
using Domain.Core.OxiServi.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static CrossCutting.Utility.OxiServi.Constants.ApplicationConstants;

namespace API.Infrastructure.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment env;
        private readonly ILogger<HttpGlobalExceptionFilter> logger;
        public HttpGlobalExceptionFilter(IHostingEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);
            if (context.Exception.GetType() == typeof(OxiServiDomainException))
            {
                JsonErrorResponse json = null;
                var innerException = context.Exception.InnerException;

                if (innerException == null)
                {
                    json = new JsonErrorResponse
                    {
                        Messages = new string[] { context.Exception.Message }
                        //MessageType = NotificationMessageType.BUSINESSLOGIC
                    };
                }
                else
                {
                    var errors = ((FluentValidation.ValidationException)innerException).Errors.Select(x => x.ErrorMessage).ToArray();
                    json = new JsonErrorResponse
                    {
                        Messages = errors
                        //MessageType = NotificationMessageType.FORMFIELDS
                    };
                }
                JsonResponse jr = new JsonResponse();
                string[] nuevo = new string[100];
                string ms = null;
                jr.Id = 0;
                jr.Result = false;
                List<string> listError = ((from s in json.Messages.ToList() select s).Distinct()).ToList();
                foreach (var item in listError)
                {
                    ms += " - " + item;
                }
                jr.Message = ms;
                context.Result = new BadRequestObjectResult(jr);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context.Exception.GetType() == typeof(SqlException))
            {
                JsonErrorResponse json = null;
                var innerException = context.Exception.InnerException;

                SqlException sqlException = context.Exception as SqlException;
                if (innerException == null)
                {
                    json = new JsonErrorResponse
                    {
                        Procedure = sqlException.Procedure,
                        Messages = new string[] { context.Exception.Message },
                        MessageType = NotificationMessageType.BD_ERROR
                    };
                }
                else
                {
                    var errors = ((FluentValidation.ValidationException)innerException).Errors.Select(x => x.ErrorMessage).ToArray();
                    json = new JsonErrorResponse
                    {
                        Messages = errors,
                        MessageType = NotificationMessageType.BD_ERROR
                    };
                }
                JsonResponse jr = new JsonResponse();
                string[] nuevo = new string[100];
                string ms = null;
                jr.Id = 0;
                jr.Result = false;
                List<string> listError = ((from s in json.Messages.ToList() select s).Distinct()).ToList();
                foreach (var item in listError)
                {
                    ms += " - " + item;
                }
                jr.Message = ms;
                context.Result = new BadRequestObjectResult(jr);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var json = new JsonErrorResponse
                {
                    Messages = new[] { "Ocurrió un error interno, intente nuevamente por favor."+ context.Exception.Message },
                    MessageType = NotificationMessageType.INTERNALERROR
                };
                JsonResponse jr = new JsonResponse();
                string[] nuevo = new string[100];
                string ms = null;
                jr.Id = 0;
                jr.Result = false;
                List<string> listError = ((from s in json.Messages.ToList() select s).Distinct()).ToList();
                foreach (var item in listError)
                {
                    ms += " - " + item;
                }
                jr.Message = ms;
                context.Result = new InternalServerErrorObjectResult(jr);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.ExceptionHandled = true;
        }

        private class JsonErrorResponse
        {
            public string[] Messages { get; set; }
            public string MessageType { get; set; }
            public object DeveloperMessage { get; set; }
            public string Procedure { get; set; }
        }
    }

    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object error)
            : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
