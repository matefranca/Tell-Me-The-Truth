using UnityEngine;

namespace Energy
{
    public class FanSpin : MonoBehaviour
    {
        [Header("Rotation Speed.")]
        [SerializeField]
        private float rotationSpeed = 150f;

        private void Update()
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}
