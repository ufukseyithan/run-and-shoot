using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core {
    public class Player : MonoBehaviour {
        PlayerController controller;
        Movement movement;

        void Awake() {
            controller = GetComponent<PlayerController>();
            movement = GetComponent<Movement>();
            
            controller.OnMove += (velocity) => movement.velocity = velocity;
        }

        void Update() {
        
        }
    }

}
