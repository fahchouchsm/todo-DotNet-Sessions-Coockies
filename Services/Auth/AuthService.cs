using todoV2.Services.SessionManager;

namespace todoV2.Services.Auth
{
    public class AuthService: IAuthService
    {
        private readonly ISessionManagerService _sessionManagerService;

        public AuthService(ISessionManagerService sessionManager) 
        {
            _sessionManagerService = sessionManager;
        }

        public bool isAuth()
        {
          return _sessionManagerService.getFromSession<string>("auth") == null ? false : true; 
        }

        public void setAuth(bool auth)
        {
            if (auth)
            {
                 _sessionManagerService.addSession("", "auth");
            }
            else
            {
                 _sessionManagerService.deleteSession("auth");
            }
        }
    }
}
