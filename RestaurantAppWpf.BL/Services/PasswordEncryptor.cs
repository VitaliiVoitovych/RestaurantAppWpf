using System.Text;

namespace RestaurantAppWpf.BL.Services
{
    public class PasswordEncryptor
    {
        public static string PasswordEncrypt(string password)
        {
            StringBuilder builder = new();
            foreach (char s in password)
            {
                builder.Append((int)s);
            }
            return builder.ToString();
        }
    }
}
