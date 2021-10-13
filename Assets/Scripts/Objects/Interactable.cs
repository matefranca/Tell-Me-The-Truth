using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Energy
{
    [RequireComponent(typeof(Rigidbody))]
    public class Interactable : MonoBehaviour
    {
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void Select(Transform parent)
        {
            transform.SetParent(parent);
            transform.position = parent.position;
            rb.isKinematic = true;
        }

        public void Deselect()
        {
            transform.parent = null;
            rb.isKinematic = false;
        }
    }
}