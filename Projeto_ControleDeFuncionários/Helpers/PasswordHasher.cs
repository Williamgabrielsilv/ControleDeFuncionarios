namespace Projeto_ControleDeFuncionários.Helpers
{
    public static class PasswordHasher
    {
        private const int WorkFactor = 12;

        public static string ToBcrypt(string plainPassword)
        {
            if(plainPassword is null)
                throw new ArgumentNullException(nameof(plainPassword));
            return BCrypt.Net.BCrypt.HashPassword(plainPassword, WorkFactor);
        }
        public static bool Verify(string plainPassword, string hashedPassword)
        {
            if(string.IsNullOrEmpty(plainPassword))
                throw new ArgumentNullException(nameof(plainPassword));
            if(string.IsNullOrEmpty(hashedPassword))
                throw new ArgumentNullException(nameof(hashedPassword));
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}
