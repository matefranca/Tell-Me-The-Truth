using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Energy
{
    public class SelectionManager : SingletonInstance<SelectionManager>
    {
        [Header("Choices")]
        [SerializeField]
        private GameObject leftChoice;
        [SerializeField]
        private GameObject rightChoice;

        public bool CanSelect { get; private set; } = true;

        private void Start()
        {
            SetChoicesActivation(false);
        }

        public void SelectChoice(int choice)
        {
            SetChoicesActivation(false);
            Debug.Log(choice);

            DialogueManager.GetInstance().SelectChoice(choice, false);
        }

        public void GoToNextQuestion()
        {
            SetChoicesActivation(true);
            Invoke("EnableSelection", 1.5f);
        }

        public void EnableSelection()
        {
            CanSelect = true;
        }

        public void SetChoicesActivation(bool active)
        {
            leftChoice.SetActive(active);
            rightChoice.SetActive(active);

            if (!active)
            {
                leftChoice.GetComponent<Choice>().Unchoose();
                rightChoice.GetComponent<Choice>().Unchoose();
            }
        }
    }
}