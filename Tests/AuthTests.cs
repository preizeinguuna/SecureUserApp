using NUnit.Framework;
using SecureUserApp.Services;

namespace SecureUserApp.Tests
{
    [TestFixture]
    public class AuthTests
    {
        [Test]
        public void InvalidPasswordShouldFail()
        {
            var service = new AuthService();

            string hash = service.HashPassword("Password123");

            bool result = service.VerifyPassword("WrongPassword", hash);

            Assert.That(result, Is.False);
        }

        [Test]
        public void CorrectPasswordShouldPass()
        {
            var service = new AuthService();

            string hash = service.HashPassword("Password123");

            bool result = service.VerifyPassword("Password123", hash);

            Assert.That(result, Is.True);
        }
    }
}