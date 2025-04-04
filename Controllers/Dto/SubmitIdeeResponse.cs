namespace ideeenbus.Controllers.Dto
{
    public class SubmitIdeeResponse
    {
        public string[] errors { get; } = [];
        public Boolean success { get; } = true;

        public Object? data { get; }

        public SubmitIdeeResponse(List<string> errors)
        {
            this.errors = errors.ToArray();
            this.success = false;
        }

        public SubmitIdeeResponse(object? data)
        {
            this.data = data;
        }
    }
}
