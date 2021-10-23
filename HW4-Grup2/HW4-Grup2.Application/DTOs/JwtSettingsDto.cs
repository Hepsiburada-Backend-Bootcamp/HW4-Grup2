namespace HW4_Grup2.Application.DTOs
{
    public class JwtSettingsDto
    {
        public string Issuer { get; set; }

        public string Secret { get; set; }

        public int ExpirationInDays { get; set; }
    }
}
