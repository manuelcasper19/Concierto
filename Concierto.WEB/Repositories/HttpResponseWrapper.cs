using System.Net;

namespace Concierto.WEB.Repositories
{
    public class HttpResponseWrapper<T>
    {
        //Constructor
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }

        //Properties
        public bool Error { get; set; }

        public T? Response { get; set; }

        public HttpResponseMessage HttpResponseMessage { get; set; }

        //Methods publics
        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null;
            }

            var StatusCode = HttpResponseMessage.StatusCode;

            switch (StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return "Recurso no encontrado";
                case HttpStatusCode.BadRequest:
                    return await HttpResponseMessage.Content.ReadAsStringAsync();
                case HttpStatusCode.Unauthorized:
                    return "Tienes que logearte para hacer esta operación";
                case HttpStatusCode.Forbidden:
                    return "No tienes permisos para hacer esta operación";
                default:
                    return "Ha ocurrido un error inesperado";

            }
        }


    }
}
