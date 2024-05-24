using System.Collections;
using System.Threading;
using Cysharp.Threading.Tasks;
using NUnit.Framework;
using TestTask.StateMachine;
using UnityEngine.TestTools;

namespace TestTask.Tests.StateMachine
{
    [TestFixture]
    public sealed class GameStateMachineTests
    {
        private GameStateMachine _stateMachine;
        
        [SetUp]
        public void Setup()
        {
            _stateMachine = new GameStateMachine(new []
            {
                new TestState(),
            });
        }

        [UnityTest]
        public IEnumerator Enter_To_TestState_And_Then_CurrentState_Should_Be_TestState() => UniTask.ToCoroutine(async () =>
        {
            await _stateMachine.EnterAsync<TestState>(new CancellationToken());
            
            Assert.AreNotEqual(null, _stateMachine.CurrentState);
            Assert.AreEqual(typeof(TestState), _stateMachine.CurrentState.GetType());
        });
        
        [UnityTest]
        public IEnumerator Enter_To_TestState_With_Data_And_Then_CurrentState_Should_Be_TestState() => UniTask.ToCoroutine(async () =>
        {
            const bool Data = true;
            
            await _stateMachine.EnterAsync<TestState, bool>(Data, new CancellationToken());
            
            Assert.AreNotEqual(null, _stateMachine.CurrentState);
            Assert.AreEqual(Data, ((TestState)_stateMachine.CurrentState).IsInstalled);
        });
        
        [TearDown]
        public void TearDown()
        {
            _stateMachine.Dispose();
        }
    }
}