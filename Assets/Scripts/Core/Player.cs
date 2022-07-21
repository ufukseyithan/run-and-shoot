using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core {
    public class Player : MonoBehaviour {
        PlayerController controller;
        Movement movement;
        [SerializeField]
        Gun gun;

        void Awake() {
            controller = GetComponent<PlayerController>();
            movement = GetComponent<Movement>();
            
            controller.OnMove += (velocity) => movement.velocity = velocity;
        }

        void Update() {
            var closestEnemy = FindClosestEnemy();

            if (closestEnemy != null) {
                var enemyPosition = closestEnemy.transform.position;
                
                transform.LookAt(new Vector3(enemyPosition.x, transform.position.y, enemyPosition.z));
                gun.TryFire();
            }
        }

        GameObject FindClosestEnemy() {
            var enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

            GameObject closest = null;
            var distance = Mathf.Infinity;
            var position = transform.position;
            
            foreach (var enemyObject in enemyObjects) {
                var diff = enemyObject.transform.position - position;
                var curDistance = diff.sqrMagnitude;
                
                if (curDistance < distance) {
                    closest = enemyObject;
                    distance = curDistance;
                }
            }
            
            return closest;
        }
    }
}
