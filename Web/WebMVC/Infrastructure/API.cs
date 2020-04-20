namespace WebMVC.Infrastructure
{
    public class API
    {
        public static class Book
        {
            public static string Home(string baseUri) => $"{baseUri}/Home";
            public static string DoSomething(string baseUri, string name, string email)
                => $"{baseUri}/Home/DoSomething?name={name}&email={email}";
        }
    }
}
