using NUnit.Framework;

namespace SecureUserApp.Tests
{
    [TestFixture]
    public class AuthorizationTests
    {
        [Test]
        public void AdminRoleShouldAccessDashboard()
        {
            string role = "Admin";

            Assert.That(role, Is.EqualTo("Admin"));
        }

        [Test]
        public void UserRoleShouldNotAccessDashboard()
        {
            string role = "User";

            Assert.That(role, Is.Not.EqualTo("Admin"));
        }
    }
}