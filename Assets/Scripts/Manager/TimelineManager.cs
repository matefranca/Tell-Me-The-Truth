using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Energy
{
    public class TimelineManager : SingletonInstance<TimelineManager>
    {
        [Header("Timelines.")]
        [SerializeField]
        private GameObject[] timelines;

        public void ActivateNextTimeline(int choice)
        {
            if (choice >= timelines.Length)
                return;

            foreach (GameObject go in timelines)
                go.SetActive(false);

            Debug.Log("Timeline Activated. Choice: " + choice);
            timelines[choice].SetActive(true);
        }

        public void EndTimeLine()
        {
            Debug.Log("Timeline Ended.");
            
            DialogueManager.GetInstance().GoToNextQuestion();
        }
    }
}