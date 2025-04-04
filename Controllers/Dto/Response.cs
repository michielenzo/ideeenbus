namespace ideeenbus.Controllers.Dto
{
    public class Response
    {
        public string[] errors { get; } = [];
        public Boolean success { get; set; }

        public Object? data { get; set; }

        public Response(List<string> errors, bool success, object? data)
        {
            this.errors = errors.ToArray();
            this.success = success;
            this.data = data;
        }
    }
}
