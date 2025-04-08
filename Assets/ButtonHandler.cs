using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public Button backButton, goButton, noButton, yesButton, startMP;
    public GameObject player, confirmPanel;
    public Text connectText;
    // Start is called before the first frame update
    void Start()
    {
        goButton.onClick.AddListener(delegate { PopupConfirm(); });
        noButton.onClick.AddListener(delegate { Cancel(); });
        yesButton.onClick.AddListener(delegate { Proceed(); });
        backButton.onClick.AddListener(delegate { Back(); });
    }

    void PopupConfirm()
    {
        confirmPanel.SetActive(true);
    }
    void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Proceed()
    {
        CameraFollow.target = player.transform;
        GameLogic.player = player.transform;
        player.GetComponent<Rigidbody>().useGravity = true;
        DontDestroyOnLoad(player);
        SceneManager.LoadScene("RacingGame");
    }

    void Cancel()
    {
        confirmPanel.SetActive(false);
    }

}
