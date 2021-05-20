using NUnit.Framework;

namespace GenericCollectionsLibrary.Tests
{
    [TestFixture]
    public class MyIteratorTests
    {
        [Test]
        public void Current_NewNodeCreated_ReturnedExpected()
        {
            var node = new Node<int>(5, null);
            var target = new MyIterator<int>(node);

            Assert.That(target.Current, Is.EqualTo(5));
        }

        [Test]
        public void MoveNext_NodeIsNull_ReturnedFalse()
        {
            var target = new MyIterator<float>(null);

            Assert.That(target.MoveNext, Is.EqualTo(false));
        }

        [Test]
        public void MoveNext_TwoNodes_ReturnedTrueAndCurrentNodeIsExpected()
        {
            var node1 = new Node<float>(5.6f, null);
            var node2 = new Node<float>(0f, node1);

            var target = new MyIterator<float>(node2);

            Assert.That(target.MoveNext, Is.EqualTo(true));
            Assert.That(target.Current, Is.EqualTo(5.6f));
        }
    }
}