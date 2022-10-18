using TDS.Infrastructure.LoadingScreen;
using TDS.Infrastructure.SceneLoader;


namespace TDS.Infrastructure.StateMachine
{
    public class MenuState : BaseExitableState, IState
    {
        private ILoadingScreenService _loadingScreenService;
        private ISceneLoadService _sceneLoadService;
        
        public MenuState(IGameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public override void Enter()
        {
            
            Services.Container.Get(out _loadingScreenService);
            Services.Container.Get(out _sceneLoadService);
            
            _loadingScreenService.ShowScreen();
            _sceneLoadService.Load("MenuScene", OnSceneLoaded);
      
        }

        private void OnSceneLoaded()
        {
            ILoadingScreenService loadingScreenService = Services.Container.Get<ILoadingScreenService>();
            loadingScreenService.HideScreen();
        }

        public override void Exit()
        {
            _loadingScreenService = null;
            _sceneLoadService = null;

        }
    }
}