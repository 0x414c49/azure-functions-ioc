namespace AzureFunctions.Ioc.Services
{
    public class HelloWorld : IHelloWorld
    {
        public string SayHello(string name) => $"Welcome, {name}";
    }
}