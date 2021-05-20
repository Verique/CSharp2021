using NUnit.Framework;

namespace GenericCollectionsLibrary.Tests
{
    [TestFixture]
    public class GenericQueueTests
    {
        [Test]
        public void Peek_EmptyQueue_ThrownInvalidOperationException()
        {
            var target = new GenericQueue<int>();

            Assert.That(target.Peek, Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_EmptyQueue_ThrownInvalidOperationException()
        {
            var target = new GenericQueue<int>();

            Assert.That(target.Pop, Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_HeadIs5_Returned5()
        {
            var target = new GenericQueue<int>();

            target.Push(5);
            target.Push(0);
            target.Push(-1);

            Assert.That(target.Peek(), Is.EqualTo(5));
        }

        [Test]
        public void Push_DataIsCorrect_DataPushed()
        {
            var target = new GenericQueue<int>();
            target.Push(5);
            Assert.That(target.Peek(), Is.EqualTo(5));
        }

        [Test]
        public void Pop_DataGiven_ReturnedExpected()
        {
            var target = new GenericQueue<int>();

            target.Push(5);
            target.Push(0);
            target.Push(-1);

            Assert.That(target.Pop(), Is.EqualTo(5));
            Assert.That(target.Pop(), Is.EqualTo(0));
            Assert.That(target.Pop(), Is.EqualTo(-1));
        }
    }
}