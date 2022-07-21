using System;
using UnityEngine;

namespace Game.Core {
    public class Bullet : MonoBehaviour {
        void Start() {
            Destroy(gameObject, 5);
        }

        void Update() {
            transform.position += transform.forward * 20 * Time.deltaTime;
        }

        void OnTriggerEnter(Collider other) {
            if (other.tag == "Enemy") {
                other.GetComponent<Enemy>().TakeDamage();
                
                Destroy(gameObject);
            }
        }
    }
}
