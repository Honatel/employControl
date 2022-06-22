using System.Text;

namespace employesControl_V2.Helper
{
    public static class DataProtection
    {
        public static string EncriptiStringValue(this string value)
        {
            byte[] encode = new byte[value.Length];
            encode = System.Text.Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(encode);
        }

        public static string DecodeBase64(this string value)
        {
            var valueBytes = System.Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(valueBytes);
        }
    }
}