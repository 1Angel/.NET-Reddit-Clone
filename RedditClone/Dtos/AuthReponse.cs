namespace RedditClone.Dtos
{
    public class AuthReponse
    {
        public int StatusCode {  get; set; }
        public string Message { get; set; }
        public bool IsSucceed { get; set; }

        public string? Errors { get; set; }
    }
}
