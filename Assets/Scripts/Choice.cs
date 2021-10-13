using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Energy
{
    public class Choice : MonoBehaviour
    {
        [Header("Index")]
        public int index;

        [Header("SelectionObjects")]
        [SerializeField]
        private GameObject[] selectionObjects;

        void Start()
        {
        }

        public void Choose()
        {
            foreach (GameObject go in selectionObjects)
                go.SetActive(true);
        }

        public void Unchoose()
        {
            foreach (GameObject go in selectionObjects)
                go.SetActive(false);
        }
    }
}