using UnityEngine;

namespace Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private GameBootstrapper _bootstrapperPrefab;

        private void Awake()
        {
            GameBootstrapper bootstrapperOnScene = FindObjectOfType<GameBootstrapper>();
            if (bootstrapperOnScene != null)
                return;
            
            Instantiate(_bootstrapperPrefab);
        }
    }
}