using UnityEngine;

namespace Hero
{
    [RequireComponent(typeof(HeroMove), typeof(HeroAnimator), typeof(HeroAttack))]
    public class HeroController : MonoBehaviour, IShootStateReader
    {
   

        private HeroMove _heroMove;
        private HeroAnimator _heroAnimator;
        private HeroAttack _heroAttack;
    
        private Camera _mainCamera;


        private LayerMask _groundLayerMask;
        private LayerMask _ragdollLayerMask;

        private bool _isInShootZone;
        private bool _isInShootBehaviour;

        private void Awake()
        {
            _heroMove = GetComponent<HeroMove>();
            _heroAnimator = GetComponent<HeroAnimator>();
            _heroAttack = GetComponent<HeroAttack>();
        }

        private void Start()
        {
            _mainCamera = Camera.main;
            _groundLayerMask = LayerMask.GetMask("Ground");
            _ragdollLayerMask = LayerMask.GetMask("Ragdoll");
        }

        // Update is called once per frame
        void Update()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(1))
            {
                if (Physics.Raycast(ray, out RaycastHit hit, 1000f, _groundLayerMask))
                {
                    _heroMove.MoveTo(hit.point);
                    _heroAnimator.ToggleShootBehaviour(false);
                    return;
                }
            }

            if (_isInShootBehaviour)
            {
                if (Physics.Raycast(ray, out RaycastHit hitRagdoll, 1000f, _ragdollLayerMask))
                {
                    _heroAttack.UpdateBodyAndGunRotation(hitRagdoll.collider.transform.position);
                } else if (Physics.Raycast(ray, out RaycastHit hitGround, 1000f, _groundLayerMask))
                {
                    _heroAttack.UpdateBodyAndGunRotation(hitGround.point);
                }
            
                if (Input.GetMouseButtonDown(0))
                {
                    _heroAnimator.ShotOnce(); 
                } else if (Input.GetMouseButton(0))
                {
                    _heroAnimator.ToggleShotLoop(true);
                } else
                {
                    _heroAnimator.ToggleShotLoop(false);
                }
            }
        }
    
        public void EnteredState()
        {
            _isInShootBehaviour = true;
            _heroAttack.GunSetActive(true);
        }

        public void ExitedState()
        {
            _isInShootBehaviour = false;
            _heroAttack.GunSetActive(false);
        }
    }
}