
namespace Server.Response
{
    public class Responses : IResponse
    {
        public string Message { get; set; }
        public int Id { get; set; }
        public bool DidError { get; set; }

        public string ErrorMessage { get; set; }
    }

}