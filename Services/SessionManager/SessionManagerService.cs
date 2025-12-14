using System.Text.Json;

namespace todoV2.Services.SessionManager
{
    public class SessionManagerService: ISessionManagerService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public SessionManagerService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void addSession(object obj,string sessionName)
        {

            _contextAccessor.HttpContext!.Session.SetString(sessionName, JsonSerializer.Serialize(obj));
        }
          
        public T? getFromSession<T>(string sessionName)
        {
            if (_contextAccessor.HttpContext!.Session.GetString(sessionName) == null) return default;
            return JsonSerializer.Deserialize<T>(_contextAccessor.HttpContext!.Session.GetString(sessionName)!);
        }


        public void deleteSession(string sessionName)
        {
            _contextAccessor.HttpContext!.Session.Remove(sessionName);
        }
    }
}