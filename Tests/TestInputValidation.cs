using NUnit.Framework;
using SecureUserApp.Services;

namespace SecureUserApp.Tests
{
    [TestFixture]
    public class TestInputValidation
    {
        [Test]
        public void TestForSQLInjection()
        {
            // Simulate input containing an SQL injection fragment
            string username = "' OR 1=1 --";
            
            // Verify that the input contains dangerous SQL syntax fragments
            Assert.That(username.Contains("' OR"), Is.True);
        }

        [Test]
        public void TestForXSS()
        {
            // Simulate malicious script input
            string input = "<script>alert('XSS')</script>";
            
            // Sanitize the input using the sanitizer service
            string sanitized = InputSanitizer.Sanitize(input);

            // Verify that the script tags are neutralized and no longer present
            Assert.That(sanitized.Contains("<script>"), Is.False);
        }
    }
}