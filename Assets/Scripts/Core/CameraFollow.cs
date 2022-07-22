using UnityEngine;

namespace Game.Core {
    public class CameraFollow : MonoBehaviour {
        [SerializeField] Transform target;
        [SerializeField] Vector3 offset;

        void LateUpdate() {
            var targetPosition = target.position + offset;
        
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10);
        }
    }
}
