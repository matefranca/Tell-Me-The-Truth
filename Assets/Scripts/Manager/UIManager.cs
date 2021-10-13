using System.Collections;
using TMPro;
using UnityEngine;

namespace Energy
{
    public class UIManager : SingletonInstance<UIManager>
    {
        [Header("Interaction Text")]
        [SerializeField]
        private GameObject interactionText;
        [SerializeField]
        private GameObject helperText;

        [Header("Dialogue Objects.")]
        [SerializeField]
        private TMP_Text dialogueText;
        [SerializeField]
        private TMP_Text leftChoiceText;
        [SerializeField]
        private TMP_Text rightChoiceText;




        private void Start()
        {
            SetInteractionText(false);
        }

        public void SetInteractionText(bool open)
        {
            interactionText.SetActive(open);
        }
        
        public void SetDialogueText(string dialogue)
        {
            StartCoroutine(ShowDialogueText(dialogue));
        }

        private IEnumerator ShowDialogueText(string question)
        {
            dialogueText.text = "";
            foreach (var letter in question.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.05f);
            }
        }

        public void SetChoicesText(string leftChoice, string rightChoice)
        {
            leftChoiceText.SetText(leftChoice);
            rightChoiceText.SetText(rightChoice);
        }

        public void SetHelperText(bool active)
        {
            helperText.SetActive(active);
        }
    }
}