using Moq;
using NUnit.Framework;

namespace Events.Tests
{
    [TestFixture]
    public class SubscriberTests
    {
        [Test]
        public void Subscribe_CountdownIsNull_ArgumentNullExceptionThrown()
        {
            var target = new Subscriber();
            
            Assert.That(() => target.Subscribe(null, 0), Throws.ArgumentNullException);
        }
        
        [Test]
        public void Subscribe_MethodIsCorrect_NothingThrown()
        {
            var target = new Subscriber();
            var countdown = Mock.Of<Countdown>();
            
            Assert.That(() => target.Subscribe(countdown, 0), Throws.Nothing);
        }
    }
}