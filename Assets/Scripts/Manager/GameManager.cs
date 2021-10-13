using UnityEngine;

namespace Energy
{
    public class GameManager : SingletonInstance<GameManager>
    {
        [Header("Exit Button.")]
        [SerializeField]
        private KeyCode exitKey;

        void Update()
        {
            if (Input.GetKeyDown(exitKey))
            {
                SceneLoader.GetInstance().LoadScene(GameData.MENU_SCENE_NAME);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}