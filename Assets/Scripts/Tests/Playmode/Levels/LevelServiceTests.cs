using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using NUnit.Framework;
using TestTask.Levels;
using UnityEngine.TestTools;
using Zenject;

namespace TestTask.Tests.Levels
{
    public sealed class LevelServiceTests : ZenjectUnitTestFixture
    {
        private ILevelService _levelService;
        private LevelRepository _repository;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            LevelInstaller.InstallFromResource(Container);
            _levelService = Container.Resolve<ILevelService>();
            _repository = Container.Resolve<LevelRepository>();
        }

        [Test]
        public void When_Random_LevelId_In_Repository_Then_LevelId_Is_Not_Empty()
        {
            var random = new Random();
            
            string levelId = _repository.Levels[random.Next(_repository.Levels.Count - 1)];
            
            Assert.AreNotEqual(null, levelId);
            Assert.AreNotEqual(string.Empty, levelId);
        }

        [UnityTest]
        public IEnumerator When_LevelService_Load_Random_Location_Then_LevelView_Is_Not_Null() => UniTask.ToCoroutine(async () =>
        {
            var random = new Random();
            string levelId = _repository.Levels[random.Next(_repository.Levels.Count - 1)];

            ILevelView levelView = await _levelService.LoadAsync(levelId);

            Assert.AreNotEqual(null, levelView);
        });
    }
}