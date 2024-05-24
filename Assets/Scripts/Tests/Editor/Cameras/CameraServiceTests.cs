using NUnit.Framework;
using TestTask.Cameras;
using TestTask.Cameras.Configs;
using TestTask.Cameras.Runtime;
using Zenject;

namespace TestTask.Tests.Cameras
{
    [TestFixture]
    public sealed class CameraServiceTests : ZenjectUnitTestFixture
    {
        private ICameraService _cameraService;
        
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            CameraInstaller.InstallFromResource(Container);
            _cameraService = Container.Resolve<ICameraService>();
        }
        
        [Test]
        public void When_TrySetup_FollowConfig_With_Camera_Gameplay_Then_Return_TRUE()
        {
            bool result = false;
            
            Assert.DoesNotThrow(() =>
            {
                result = _cameraService.TrySetup(new FollowConfig
                {
                    CameraId = "Gameplay",
                    FollowTarget = null,
                });
            });
            
            Assert.IsTrue(result);
        }
    }
}