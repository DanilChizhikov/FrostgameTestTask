using System;
using TestTask.UserInterface;
using Zenject;

namespace TestTask.Infrastructure
{
    internal sealed class Entrypoint : IInitializable
    {
        private readonly IUIService _uiService;
        
        public Entrypoint(IUIService uiService)
        {
            _uiService = uiService;
        }
        
        public void Initialize()
        {
            if (!_uiService.TryShow(ScreenType.Loading))
            {
                throw new Exception("Screen not found: " + ScreenType.Loading);
            }
        }
    }
}