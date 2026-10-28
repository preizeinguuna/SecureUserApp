using System.Net;

namespace SecureUserApp.Services
{
    public static class InputSanitizer
    {
        // Sanitize user input to prevent XSS attacks
        public static string Sanitize(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            // Encode HTML characters to neutralize potential malicious scripts
            return WebUtility.HtmlEncode(input);
        }
    }
}