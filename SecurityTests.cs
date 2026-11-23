using AtmSystem;
using Xunit;

namespace AtmSystem.Tests
{
    public class SecurityTests
    {
        [Fact]
        public void Hash_SameInput_SameResult()
        {
            string salt = Security.NewSalt();
            Assert.Equal(Security.Hash("1234", salt), Security.Hash("1234", salt));
        }

        [Fact]
        public void Hash_DifferentSalt_DifferentResult()
        {
            Assert.NotEqual(Security.Hash("1234", Security.NewSalt()), Security.Hash("1234", Security.NewSalt()));
        }

        [Fact]
        public void Hash_DoesNotContainPlainSecret()
        {
            Assert.DoesNotContain("1234", Security.Hash("1234", Security.NewSalt()));
        }

        [Fact]
        public void Mask_HidesMiddleDigits()
        {
            Assert.Equal("2202 **** **** 0016", AtmService.Mask("2202200000000016"));
        }
    }
}
