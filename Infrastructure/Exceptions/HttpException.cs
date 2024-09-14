using System.Net;
using System.Runtime.Serialization;
using ExpenseCase.Common.Dto;
using Newtonsoft.Json;

namespace ExpenseCase.Infrastructure.Exceptions;

    [Serializable]
    public abstract class HttpException : Exception
    {
        public abstract HttpStatusCode GetHttpStatusCode();

        public IList<ExceptionDto> Errors { get; private set; }

        protected HttpException()
        {
        }

        protected HttpException(string message) : base(message)
        {
            Errors = new List<ExceptionDto> { new ExceptionDto(message) };
        }

        protected HttpException(string message, Exception innerException) : base(message, innerException)
        {
            Errors = new List<ExceptionDto> { new ExceptionDto(message) };
        }
        protected HttpException(ExceptionDto error) : base(JsonConvert.SerializeObject(error))
        {
            Errors = new List<ExceptionDto> { error };
        }

        protected HttpException(ExceptionDto error, Exception innerException) : base(JsonConvert.SerializeObject(error), innerException)
        {
            Errors = new List<ExceptionDto> { error };
        }
        protected HttpException(IList<ExceptionDto> errors) : base(JsonConvert.SerializeObject(errors))
        {
            Errors = errors;
        }

        protected HttpException(IList<ExceptionDto> errors, Exception innerException) : base(JsonConvert.SerializeObject(errors), innerException)
        {
            Errors = errors;
        }

        protected HttpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable]
    public abstract class WritableBodyException : HttpException
    {
        protected WritableBodyException()
        {
        }

        protected WritableBodyException(string message) : base(message)
        {
        }

        protected WritableBodyException(IList<ExceptionDto> errors) : base(errors)
        {
        }
        protected WritableBodyException(IList<ExceptionDto> errors, Exception innerException) : base(errors, innerException)
        {
        }
        protected WritableBodyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WritableBodyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected WritableBodyException(ExceptionDto error) : base(error)
        {
        }

        protected WritableBodyException(ExceptionDto error, Exception innerException) : base(error, innerException)
        {
        }
    }


    [Serializable]
    public class NotFoundException : WritableBodyException
    {

        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(IList<ExceptionDto> errors) : base(errors)
        {
        }

        public NotFoundException(IList<ExceptionDto> errors, Exception innerException) : base(errors, innerException)
        {
        }
        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NotFoundException(ExceptionDto error) : base(error)
        {
        }

        public NotFoundException(ExceptionDto error, Exception innerException) : base(error, innerException)
        {
        }



        public override HttpStatusCode GetHttpStatusCode()
        {
            return System.Net.HttpStatusCode.NotFound;
        }

    }

    [Serializable]
    public class InternalServerErrorException : WritableBodyException
    {

        public InternalServerErrorException()
        {
        }

        public InternalServerErrorException(string message) : base(message)
        {
        }

        public InternalServerErrorException(IList<ExceptionDto> errors) : base(errors)
        {
        }

        public InternalServerErrorException(IList<ExceptionDto> errors, Exception innerException) : base(errors, innerException)
        {
        }
        public InternalServerErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InternalServerErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InternalServerErrorException(ExceptionDto error) : base(error)
        {
        }

        public InternalServerErrorException(ExceptionDto error, Exception innerException) : base(error, innerException)
        {
        }
        public override HttpStatusCode GetHttpStatusCode()
        {
            return System.Net.HttpStatusCode.InternalServerError;
        }

    }

    [Serializable]
    public class ServiceUnavailableException : WritableBodyException
    {

        public ServiceUnavailableException()
        {
        }

        public ServiceUnavailableException(string message) : base(message)
        {
        }

        public ServiceUnavailableException(IList<ExceptionDto> errors) : base(errors)
        {
        }
        public ServiceUnavailableException(IList<ExceptionDto> errors, Exception innerException) : base(errors, innerException)
        {
        }
        public ServiceUnavailableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ServiceUnavailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ServiceUnavailableException(ExceptionDto error) : base(error)
        {
        }

        public ServiceUnavailableException(ExceptionDto error, Exception innerException) : base(error, innerException)
        {
        }
        public override HttpStatusCode GetHttpStatusCode()
        {
            return System.Net.HttpStatusCode.ServiceUnavailable;
        }

    }

    [Serializable]
    public class BadRequestException : WritableBodyException
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(IList<ExceptionDto> errors) : base(errors)
        {
        }
        public BadRequestException(IList<ExceptionDto> errors, Exception innerException) : base(errors, innerException)
        {
        }
        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BadRequestException(ExceptionDto error) : base(error)
        {
        }

        public BadRequestException(ExceptionDto error, Exception innerException) : base(error, innerException)
        {
        }
        public override HttpStatusCode GetHttpStatusCode()
        {
            return System.Net.HttpStatusCode.BadRequest;
        }
    }
    [Serializable]
    public class UnauthorizedException : WritableBodyException
    {
        public UnauthorizedException()
        {
        }

        public UnauthorizedException(string message) : base(message)
        {
        }

        public UnauthorizedException(IList<ExceptionDto> errors) : base(errors)
        {
        }
        public UnauthorizedException(IList<ExceptionDto> errors, Exception innerException) : base(errors, innerException)
        {
        }
        public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnauthorizedException(ExceptionDto error) : base(error)
        {
        }

        public UnauthorizedException(ExceptionDto error, Exception innerException) : base(error, innerException)
        {
        }
        public override HttpStatusCode GetHttpStatusCode()
        {
            return System.Net.HttpStatusCode.Unauthorized;
        }
    }
    [Serializable]
    public class ForbiddenException : WritableBodyException
    {
        public ForbiddenException()
        {
        }

        public ForbiddenException(string message) : base(message)
        {
        }

        public ForbiddenException(IList<ExceptionDto> errors) : base(errors)
        {
        }
        public ForbiddenException(IList<ExceptionDto> errors, Exception innerException) : base(errors, innerException)
        {
        }
        public ForbiddenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ForbiddenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public ForbiddenException(ExceptionDto error) : base(error)
        {
        }

        public ForbiddenException(ExceptionDto error, Exception innerException) : base(error, innerException)
        {
        }
        public override HttpStatusCode GetHttpStatusCode()
        {
            return System.Net.HttpStatusCode.Forbidden;
        }
    }