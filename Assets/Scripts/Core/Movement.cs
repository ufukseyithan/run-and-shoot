using UnityEngine;

namespace Game.Core {
    public class Movement : MonoBehaviour {
        new Rigidbody rigidbody;
        
        [Header("Settings")]
        [SerializeField]
        float speed = 1;

        [HideInInspector]
        public Vector3 velocity = Vector3.zero;

        void Awake() {
            rigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate() {
            rigidbody.velocity = (velocity * speed);
        }
    }
}