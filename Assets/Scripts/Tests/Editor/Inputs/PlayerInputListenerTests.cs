using System;
using NUnit.Framework;
using TestTask.Core.Inputs.Runtime;
using TestTask.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using Zenject;

namespace TestTask.Tests.Inputs
{
    [TestFixture]
    internal sealed class PlayerInputListenerTests : ZenjectUnitTestFixture, IPlayerInputListener
    {
        private InputTestFixture _inputTestFixture;
        private IInputService _inputService;
        private IDisposable _inputSubscription;

        private Vector2 _input;
        
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _inputTestFixture = new InputTestFixture();
            _inputTestFixture.Setup();
            InputInstaller.InstallFromResource(Container);
            _inputService = Container.Resolve<IInputService>();
            _inputService.Enable();
            _input = Vector2.positiveInfinity;
        }

        [Test]
        public void When_Subscribing_Then_InputService_Return_NotNull()
        {
            _inputSubscription = _inputService.Subscribe(this);
            
            Assert.AreNotEqual(null, _inputSubscription);
        }

        [Test]
        public void When_Update_Inputs_Then_Listener_Is_Called()
        {
            _inputSubscription = _inputService.Subscribe(this);
            
            var mouse = InputSystem.AddDevice<Mouse>();
            InputState.Change(mouse.position, new Vector2(1f, 1f));
            _inputTestFixture.Press(mouse.rightButton);
            InputSystem.Update();
            
            Assert.AreEqual(new Vector2(1f, 1f), _input);
        }
        
        [Test]
        public void When_Update_Inputs_And_InputService_Disabled_Then_Listener_Is_Not_Called()
        {
            _inputSubscription = _inputService.Subscribe(this);
         
            _inputService.Disable();
            var mouse = InputSystem.AddDevice<Mouse>();
            InputState.Change(mouse.position, new Vector2(4f, 4f));
            _inputTestFixture.Press(mouse.rightButton);
            InputSystem.Update();
            
            Assert.AreEqual(new Vector2(4f, 4f), _input);
        }

        [TearDown]
        public override void Teardown()
        {
            _inputSubscription?.Dispose();
            base.Teardown();
            _inputTestFixture.TearDown();
        }
        
        void IPlayerInputListener.OnMove(Vector2 screenPoint)
        {
            _input = screenPoint;
        }
    }
}