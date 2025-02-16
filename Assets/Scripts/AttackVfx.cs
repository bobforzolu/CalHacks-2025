using UnityEngine;

namespace System.Components
{
    public class AttackVfx : MonoBehaviour
    {
        public GameObject VfxPrefab;
        public AttackComponent attackComponent;

        private void OnEnable()
        {
            attackComponent.OnHit += AttackComponentOnOnHit;
        }

        private void AttackComponentOnOnHit(Vector3 hitpoint)
        {
            VfxPrefab.SetActive(true);
            VfxPrefab.transform.position = hitpoint;
            
        }

        private void OnDisable()
        {
            attackComponent.OnHit += AttackComponentOnOnHit;

        }
    }
}