using System;
using Moq;
using NUnit.Framework;

namespace Events.Tests
{
    [TestFixture]
    public class CountdownTests
    {
        
        [Test]
        public void AddSubscriber_MethodIsCorrect_NothingThrown()
        {
            var target = new Countdown();
            var subscriber = Mock.Of<ICountdownSubscriber>();
            
            Assert.That(() => target.AddSubscriber(subscriber), Throws.Nothing);
        }
        
        [Test]
        public void Invoke_CountdownMessageIsNull_NullReferenceExceptionThrown()
        {
            var target = new Countdown();
            Assert.That(target.Invoke, Throws.Exception.TypeOf<NullReferenceException>());
        }
        
        [Test]
        public void Invoke_CorrectMethod_NothingThrown()
        {
            var target = new Countdown();
            var subscriber = Mock.Of<ICountdownSubscriber>();
            
            target.AddSubscriber(subscriber);
            
            Assert.That(target.Invoke, Throws.Nothing);
        }
    }
}