using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MM_ButtonHandler : MonoBehaviour
{
    public Button playButton, quitButton;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        playButton.onClick.AddListener(delegate { nextScene(); });
        quitButton.onClick.AddListener(delegate { quitGame(); });
    }

    void nextScene()
    {
        SceneManager.LoadScene("CharacterSelect");
    }
    void quitGame()
    {
        Application.Quit();
    }
}
