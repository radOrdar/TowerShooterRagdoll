using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class WindowBase : MonoBehaviour
    {
        [SerializeField] private Button CloseButton;

        private void Awake() =>
            OnAwake();

        public void Construct()
        { }

        private void OnAwake() =>
            CloseButton.onClick.AddListener(() => Destroy(gameObject));
        
        protected virtual void Init(){}
        protected virtual void SubscribeUpdates(){}
        protected virtual void Cleanup(){}
    }
}