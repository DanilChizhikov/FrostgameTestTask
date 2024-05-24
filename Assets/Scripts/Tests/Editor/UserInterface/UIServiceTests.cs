using NUnit.Framework;
using TestTask.UserInterface;
using Zenject;

namespace TestTask.Tests.UserInterface
{
    [TestFixture]
    public sealed class UIServiceTests : ZenjectUnitTestFixture
    {
        private IUIService _uiService;
        
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            UserInterfaceInstaller.InstallFromResource(Container);
            _uiService = Container.Resolve<IUIService>();
        }

        [Test, TestCase(ScreenType.Menu), TestCase(ScreenType.Gameplay)]
        public void When_TryShow_Screen_Then_Return_True(ScreenType screenType)
        {
            bool result = _uiService.TryShow(screenType);
            
            Assert.IsTrue(result);
        }
    }
}