using System.Text;

namespace RestaurantAppWpf.BL.Services
{
    public class PasswordEncryptor
    {
        private static List<string> upper = new List<string>()
        {
            "A","B","C","D","E","F","G","H","I","J","K","L","M","N",
            "O","P","Q","R","S","T","U","V","W","X","Y","Z"
        };
        private static List<string> lower = new List<string>()
        {
            "a","b","c","d","e","f","g","h","i","j","k","l","m","n",
            "o","p","q","r","s","t","u","v","w","x","y","z"
        };
        public static string PasswordEncrypt(string password)
        {
            StringBuilder builder = new();
            for (int i = 0; i < 8; i++)
            {
                builder.Append($"{upper[256 * i * password.Length % 26]}{upper[128 * i * password.Length % 26]}");
                if (i < password.Length - 1)
                {
                    builder.Append($"{password[i]}");
                }
                else
                {
                    builder.Append($"{0}");
                }
                builder.Append($"{lower[64 * i * password.Length % 26]}{lower[32 * i * password.Length % 26]}");
            }
            return builder.ToString();
        }
    }
}
