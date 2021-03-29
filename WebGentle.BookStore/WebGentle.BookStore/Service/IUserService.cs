namespace WebGentle.BookStore.Service
{
    public interface IUserService
    {
        string GetUserID();
        bool IsLogged();
    }
}