using System;
using Game.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Core {
    public class Enemy : MonoBehaviour {
        public static int enemyCount = 0;
        
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

        void OnEnable() {
            enemyCount++;
        }

        void OnDisable() {
            enemyCount--;

            if (enemyCount <= 0)
                LevelManager.LoadNextLevel();
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
                LevelManager.RestartLevel();
        }

        public void TakeDamage() {
            health--;
            
            if (health <= 0)
                Destroy(gameObject);
        }
    }
}
