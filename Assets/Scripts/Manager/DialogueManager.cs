using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Energy
{
    public class DialogueManager : SingletonInstance<DialogueManager>
    {
        [Header("Dialogue Question.")]
        [SerializeField]
        private Question firstQuestion;

        private Question activeQuestion;

        private bool timeCounting = false;
        private float timer = 0f;

        private void Start()
        {
            activeQuestion = firstQuestion;
        }

        private void Update()
        {
            if (activeQuestion.isTimeQuestion && !timeCounting)
            {
                timer = activeQuestion.timeToWait;
                timeCounting = true;
            }

            if (timer > 0 && timeCounting)
            {
                QuestionCountdown();
            }
        }

        private void QuestionCountdown()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                
                SelectChoice(0, true);
            }
        }

        public void SelectChoice(int choice, bool automatic)
        {
            Question question;
            int timelineIndex;

            if (activeQuestion.isTimeQuestion)
            {
                if (automatic)
                {
                    question = activeQuestion.choice2Question;
                    timelineIndex = activeQuestion.choice2TimeLine;
                    SelectionManager.GetInstance().SetChoicesActivation(false);
                }

                else
                {
                    question = activeQuestion.choice1Question;
                    timelineIndex = activeQuestion.choice1TimeLine;
                }

                timer = 0;
                timeCounting = false;
            }

            else 
            {
                
                if (choice == 0)
                {
                    question = activeQuestion.choice1Question;
                    timelineIndex = activeQuestion.choice1TimeLine;

                }
                else
                {
                    question = activeQuestion.choice2Question;
                    timelineIndex = activeQuestion.choice2TimeLine;
                }
            }

            activeQuestion = question;

            TimelineManager.GetInstance().ActivateNextTimeline(timelineIndex);
        }

        public void GoToNextQuestion()
        {
            UIManager.GetInstance().SetChoicesText(activeQuestion.choice1Text, activeQuestion.choice2Text);
            UIManager.GetInstance().SetDialogueText(activeQuestion.questionText);
            SelectionManager.GetInstance().GoToNextQuestion();
        }
    }
}