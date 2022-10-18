using TDS.Infrastructure.LoadingScreen;
using TDS.Infrastructure.SceneLoader;
using TDS.Infrastructure.Utility.Coroutine;
using UnityEngine;

namespace TDS.Infrastructure.StateMachine
{
    public class BootstrapeState : BaseExitableState, IState
    {
        public BootstrapeState(IGameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }
        
        
        public override void Enter()
        {

            RegisterAllGlobalServices();
            StateMachine.Enter<MenuState>();
            

        }

        public override void Exit()
        {

        }

      

        private void RegisterAllGlobalServices()
        {
           
            Services.Container.RegisterMono<ICoroutineRunner>(typeof(CoroutineRunner));
            Services.Container.Register<ISceneLoadService>(new AsyncSceneLoadService(Services.Container.Get<ICoroutineRunner>()));
            Services.Container.Register<ILoadingScreenService>(new LoadingScreenService());
        }
    }
}