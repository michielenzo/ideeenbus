namespace ideeenbus.Exceptions;

public class BusinessLogicException: Exception
{
    public List<string> errors { get; set; }

    public BusinessLogicException(List<string> errors) {
        this.errors = errors;
    }
}

