using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Core {
    public class PlayerController : MonoBehaviour {
        public event Action<Vector3> OnMove;

        public void HandleMoveInput(InputAction.CallbackContext context) {
            var velocity = context.ReadValue<Vector2>().normalized;
            OnMove?.Invoke(new Vector3(velocity.x, 0, velocity.y));
        } 
    }
}