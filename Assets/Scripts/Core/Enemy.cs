using Game.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Core {
    public class Enemy : MonoBehaviour {
        Movement movement;
        Look look;
    
        Transform playerTransform;

        [SerializeField]
        int health = 3;

        void Awake() {
            movement = GetComponent<Movement>();
            look = GetComponent<Look>();
            playerTransform = GameObject.FindWithTag("Player").transform;
        }

        void Update() {
            var playerPosition = playerTransform.position;
            var pointToFollow = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
            var direction = (pointToFollow - transform.position).normalized;

            movement.velocity = direction;
            look.point = pointToFollow;
        }

        void OnCollisionEnter(Collision other) {
            if (other.transform == playerTransform)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void TakeDamage() {
            health--;
            
            if (health <= 0)
                Destroy(gameObject);
        }
    }
}
