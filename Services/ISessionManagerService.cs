namespace todoV2.Services
{
    public interface ISessionManagerService
    {
        public void addSession(Object obj, String sessionName);
        public T? getFromSession<T>(string sessionName);
    }
}
