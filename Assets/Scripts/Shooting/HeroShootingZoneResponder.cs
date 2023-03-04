using System;
using System.Linq;
using Hero;
using UnityEngine;

namespace Shooting
{
    [RequireComponent(typeof(CapsuleCollider), typeof(HeroAnimator))]
    public class HeroShootingZoneResponder : MonoBehaviour
    {
        private HeroAnimator _heroAnimator;

        private bool _isInsideShootZone;

        private void Start()
        {
            AssureTriggerColliderPresent();
            _heroAnimator = GetComponent<HeroAnimator>();
        }

        private void Update()
        {
            if (_isInsideShootZone)
            {
                _heroAnimator.ToggleShootBehaviour(true);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ShootingZoneTrigger shootingZoneTrigger))
            {
                _isInsideShootZone = true;
                _heroAnimator.ToggleShootBehaviour(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out ShootingZoneTrigger shootingZoneTrigger))
            {
                _heroAnimator.ToggleShootBehaviour(false);
                _isInsideShootZone = false;
            }
        }

        private void AssureTriggerColliderPresent()
        {
            CapsuleCollider[] colliders = GetComponents<CapsuleCollider>();
            var triggerCollider = colliders.FirstOrDefault(col => col.isTrigger);
            if (triggerCollider == null)
            {
                if (colliders.Length > 1)
                {
                    colliders[0].isTrigger = true;
                } else
                {
                    gameObject.AddComponent<CapsuleCollider>().isTrigger = true;
                }
            }
        }
    }
}