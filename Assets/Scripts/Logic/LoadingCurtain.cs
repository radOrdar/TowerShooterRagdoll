using System.Collections;
using UnityEngine;

namespace Logic
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _curtain;
        [SerializeField] private float fadeSpeed = 0.03f;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _curtain.alpha = 1;
        }

        public void Hide() => StartCoroutine(DoFadeIn());

        private IEnumerator DoFadeIn()
        {
            while (_curtain.alpha > 0)
            {
                _curtain.alpha -= fadeSpeed;
                yield return new WaitForSeconds(fadeSpeed);
            }
            
            gameObject.SetActive(false);
        }
    }
}