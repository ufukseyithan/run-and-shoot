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
            var closestEnemy = FindClosestEnemy(10);

            if (closestEnemy != null) {
                var enemyPosition = closestEnemy.transform.position;
                
                transform.LookAt(new Vector3(enemyPosition.x, transform.position.y, enemyPosition.z));
                gun.TryFire();
            }
        }

        GameObject FindClosestEnemy(float range = 0) {
            var enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

            GameObject closestEnemy = null;
            var closestDistance = Mathf.Infinity;
            var position = transform.position;
            
            foreach (var enemyObject in enemyObjects) {
                var distance = Vector3.Distance(position, enemyObject.transform.position);

                if (distance > range)
                    continue;

                if (distance < closestDistance) {
                    closestEnemy = enemyObject;
                    closestDistance = distance;
                }
            }
            
            return closestEnemy;
        }
    }
}
