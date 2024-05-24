using System.Threading;
using Cysharp.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using TestTask.Levels;
using TestTask.StateMachine;
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
            var stateMachine = Substitute.For<IGameStateMachine>();
            stateMachine.EnterAsync<IBootstrapState>(Arg.Any<CancellationToken>()).Returns(UniTask.CompletedTask);
            stateMachine.EnterAsync<IGameplayState>(Arg.Any<CancellationToken>()).Returns(UniTask.CompletedTask);
            stateMachine.EnterAsync<IMenuState>(Arg.Any<CancellationToken>()).Returns(UniTask.CompletedTask);
            var levelService = Substitute.For<ILevelService>();
            Container.Bind<IGameStateMachine>().FromInstance(stateMachine).AsSingle();
            Container.Bind<ILevelService>().FromInstance(levelService).AsSingle();
;            UserInterfaceInstaller.InstallFromResource(Container);
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