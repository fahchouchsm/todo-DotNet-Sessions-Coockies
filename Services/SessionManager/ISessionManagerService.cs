namespace todoV2.Services.SessionManager
{
    public interface ISessionManagerService
    {
        public void addSession(object obj, string sessionName);
        public T? getFromSession<T>(string sessionName);
        public void deleteSession(string sessionName);

    }
}
