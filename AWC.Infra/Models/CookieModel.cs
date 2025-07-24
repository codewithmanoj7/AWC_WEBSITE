namespace AWC.Infra.Models
{
    public class CookieModel
    {
        public string Token { get; set; }
        public DateTime ExpireAt { get; set; }

        public CookieModel(string token, DateTime expireAt)
        {
            Token = token;
            ExpireAt = expireAt;
        }
    }
}
