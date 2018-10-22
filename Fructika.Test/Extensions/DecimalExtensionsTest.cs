using Fructika.Extensions;
using Xunit;

namespace Fructika.Test.Extensions
{
    public class DecimalExtensionsTest
    {
        [Fact]
        public void When_GetGramsIsCalledWithNull_Then_ItReturnsFormattedQuestionMark()
        {
            decimal? subject = null;

            Assert.Equal("?g", subject.GetGrams());
        }

        [Fact]
        public void When_GetGramsIsCalledWithANumber_Then_ItReturnsFormattedNumber()
        {
            decimal? subject = 5;

            Assert.Equal("5.0g", subject.GetGrams());
        }
    }
}

