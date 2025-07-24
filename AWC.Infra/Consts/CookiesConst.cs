namespace AWC.Infra.Consts
{
    public static class CookiesConst
    {
        public const string AccessCookie = "College-Authentication-Token";
        public const string SecretTokenKey = "2LOlWqBkSZXboA6Qnk9pgBoFM23NBgssoEHssjpBWENJuAkpb0fADjanyZxvLamqucds2dxoAm";
        public const string IssuerAndAudience = "my-college";
        public static TimeSpan AccessCookieExpireTemp = TimeSpan.FromHours(6);
        public static TimeSpan AccessCookieExpire = TimeSpan.FromDays(14);
    }
}
