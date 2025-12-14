using todoV2.Services.SessionManager;

namespace todoV2.Services.Auth
{
    public interface IAuthService
    {
        public bool isAuth();
        public void setAuth(bool auth);

    }
}
