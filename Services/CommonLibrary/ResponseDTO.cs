namespace CommonLibrary
{
    public class ResponseDTO
    {
        public object Result { get; set; } = null!;
        public bool IsSuccessful { get; set; } = false;
        public string Message { get; set; } = string.Empty;

    }
}
