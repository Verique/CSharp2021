using System;
using NUnit.Framework;

namespace Events.Tests
{
    [TestFixture]
    public class CountdownTests
    {
        [Test]
        public void Subscribe_MethodIsNull_ArgumentNullExceptionThrown()
        {
            var target = new Countdown();
            Assert.That(() => target.Subscribe(null), Throws.ArgumentNullException);
        }
        
        [Test]
        public void Subscribe_MethodIsCorrect_NothingThrown()
        {
            var target = new Countdown();
            Action action = () => { };
            
            Assert.That(() => target.Subscribe(action), Throws.Nothing);
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
            Action action = () => { };
            
            target.Subscribe(action);
            
            Assert.That(target.Invoke, Throws.Nothing);
        }
    }
}