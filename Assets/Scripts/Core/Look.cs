using UnityEngine;

namespace Game.Core {
    public class Look : MonoBehaviour {
        [HideInInspector]
        public Vector3 point;

        void Update() {
            if (point != Vector3.zero)
                transform.LookAt(point);
        }
    }
}