using NUnit.Framework;
using TestTask.UserInterface;

namespace TestTask.Tests.UserInterface
{
    [TestFixture]
    public sealed class UIServiceTests
    {
        private IUIService _uiService;

        [Test, TestCase(ScreenType.Menu), TestCase(ScreenType.Gameplay)]
        public void When_TryShow_Screen_Then_Return_True(ScreenType screenType)
        {
            bool result = _uiService.TryShow(screenType);
            
            Assert.IsTrue(result);
        }
    }
}