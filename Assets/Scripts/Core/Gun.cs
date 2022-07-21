using UnityEngine;

namespace Game.Core {
    public class Gun : MonoBehaviour {
        float nextTimeToFire;
        
        [SerializeField]
        GameObject bulletPrefab;
        [SerializeField]
        Transform muzzleTransform;
        
        public void TryFire() {
            if (Time.time >= nextTimeToFire) {
                Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);

                nextTimeToFire = Time.time + .1f;
            }
        }
    }
}