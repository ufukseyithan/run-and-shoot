using UnityEngine;

namespace Game.Core {
    public class Movement : MonoBehaviour {
        [HideInInspector]
        public Vector3 velocity = Vector3.zero;
        
        [Header("Settings")]
        [SerializeField]
        float speed = 1;
        
        new Rigidbody rigidbody;

        void Awake() {
            rigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate() {
            rigidbody.velocity = (velocity * speed);
        }
    }
}