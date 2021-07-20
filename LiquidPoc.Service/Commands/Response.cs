namespace LiquidPoc.Service.Commands
{
    public partial class Response
    {
        public Response(object data)
        {
            Data = data;
            Success = true;
        }

        public Response(object data, bool success)
        {
            Data = data;
            Success = success;
        }

        public bool Success { get; private set; }
        public object Data { get; private set; }
    }
}
