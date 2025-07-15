using CSCPA.Core;
using Newtonsoft.Json;
using System.Linq;

namespace CSCPA.Model
{
    public enum ResponseType
    {
        Error = 0,
        Success = 1,
        Info = 2,
        Warning = 3,
        Custom = 4
    }

    public class JsonResponse
    {
        public JsonResponse()
        {
        }

        public JsonResponse(ResponseType responseType, string message, object data = null)
        {
            ResponseType = responseType;
            Message = message;
            Data = data;
        }

        public string Status => ResponseType.ToString();

        /*[ScriptIgnore]*/
        public ResponseType ResponseType { get; set; }

        public string Message { get; set; }
        public object Data { get; set; }

        public static JsonResponse DeleteSuccess(string name)
        {
            return new JsonResponse(Model.ResponseType.Success, string.Empty, name + " " + GlobalConstant.Deleted);
        }
        public static JsonResponse DeleteFailed(string name)
        {
            return new JsonResponse(Model.ResponseType.Error, string.Empty, name + " " + GlobalConstant.DeleteFailed);
        }
        public static JsonResponse UpdateSuccess(string name)
        {
            return new JsonResponse(Model.ResponseType.Success, string.Empty, name + " " + GlobalConstant.Updated);
        }
        public static JsonResponse UpdateFailed(string name)
        {
            return new JsonResponse(Model.ResponseType.Error, string.Empty, name + " " + GlobalConstant.UpdateFailed);
        }
        public static JsonResponse CreateSuccess(string name)
        {
            return new JsonResponse(Model.ResponseType.Success, string.Empty, name + " " + GlobalConstant.Created);
        }
        public static JsonResponse CreateFailed(string name)
        {
            return new JsonResponse(Model.ResponseType.Error, string.Empty, name + " " + GlobalConstant.CreateFailed);
        }

        public static JsonResponse ModelStateError(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState)
        {
            string errors = JsonConvert.SerializeObject(modelState.Values
                .SelectMany(state => state.Errors)
                .Select(error => error.ErrorMessage));
            return new JsonResponse(Model.ResponseType.Error, errors);
        }
    }
}
