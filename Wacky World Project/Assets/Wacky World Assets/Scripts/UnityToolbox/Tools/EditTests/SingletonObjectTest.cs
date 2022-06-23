using NUnit.Framework;

namespace UnityToolbox.Tools.EditTests
{
    public class SingletonObjectTest
    {
        [Test]
        public void ShouldNotBeNull()
        {
                Assert.IsNotNull(Singleton<object>.Instance());
        }


      

        [Test]
        public void CreateTwoSingletonShouldThrowException()
        {
            Singleton<object>.Instance();
            Assert.Throws<MultipleSingleton>(() => { new Singleton<object>(); });
        }
    }
}