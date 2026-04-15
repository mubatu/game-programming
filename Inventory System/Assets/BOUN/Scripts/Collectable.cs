using InventoryModule;
using UnityEngine;

namespace BOUN.Scripts
{
    public class Collectable : MonoBehaviour
    {
        public InventoryType type;
        private Animator _animator;
        private BoxCollider _boxCollider;
    
        void Awake()
        {
            _animator = GetComponent<Animator>();
            _boxCollider = GetComponent<BoxCollider>();
        }
    
        public void Collect()
        {
            _animator.Play("collect");
            _boxCollider.enabled = false;
        }
    
        public void Activate()  
        {
            _animator.Play("idle");
            _boxCollider.enabled = true;
        }
    
    }
}