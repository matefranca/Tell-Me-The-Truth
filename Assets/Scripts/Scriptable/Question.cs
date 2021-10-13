using UnityEngine;

[CreateAssetMenu(menuName = "New Question.")]
public class Question : ScriptableObject
{
    public string questionText;
    public string choice1Text;
    public string choice2Text;

    public bool isTimeQuestion;
    public float timeToWait;

    public int choice1TimeLine;
    public int choice2TimeLine;

    public Question choice1Question;
    public Question choice2Question;
}
