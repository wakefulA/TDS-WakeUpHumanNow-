using System.Collections;


namespace TDS.Infrastructure.Utility.Coroutine
{
    public interface ICoroutineRunner : IService
    {
        UnityEngine.Coroutine StartCoroutine(IEnumerator enumerator);
    }
        
    
}