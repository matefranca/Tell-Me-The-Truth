using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SceneSelectWindow : MonoBehaviour
{
    [MenuItem("Energy/Scenes/Menu %0")]
    public static void OpenMenuScene()
    {
        if (EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
            return;
        }

        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Menu.unity");
    }

    [MenuItem("Energy/Scenes/Level1 %0")]
    public static void OpenLevel1()
    {
        if (EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
            return;
        }

        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Level1.unity");
    }
}
