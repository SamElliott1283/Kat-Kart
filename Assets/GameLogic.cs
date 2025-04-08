using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public Transform[] checkpointArray;
    public static Transform[] checkpointA;

    public static int currentCheckpoint, currentLap;

    public int Lap;
    public int maxLaps = 3;

    public Vector3 startPos;
    public Quaternion startRotation;
    public static Transform player;

    public int playerPosition = 1;
    public int playerCount = 1;

    public GameObject finishPanel;

    public Text lapText, lapTimerText, totalTimerText, startTimerText, positionTextUpper, positionTextLower;

    public Text winnerNameText, returnTimerText;

    public float[] lapTime = { 0, 0, 0 };
    public float[] totalTime = { 0, 0, 0 };

    public static float lapTimeCount, totalTimeCount;

    private bool startTiming;
    private bool finish = false;

    // Start is called before the first frame update
    void Start()
    {
        currentCheckpoint = 0;
        currentLap = 0;

        player.position = startPos;
        player.rotation = startRotation;
        player.rotation = Quaternion.Euler(0, 40, 0);



        positionTextUpper.text = playerPosition.ToString();
        positionTextLower.text = playerCount.ToString();

        StartCoroutine(SetOff());

    }

    IEnumerator SetOff() //Countdown to start
    {
        Controller kartScript = player.GetComponent<Controller>();
        kartScript.Freeze();
        yield return new WaitForSeconds(1.0f);
        startTimerText.text = "2";
        yield return new WaitForSeconds(1.0f);
        startTimerText.text = "1";
        yield return new WaitForSeconds(1.0f);
        startTiming = true;
        kartScript.Unfreeze();
        startTimerText.text = "GO!";
        startTimerText.color = Color.green;
        yield return new WaitForSeconds(1.0f);
        startTimerText.text = "";
    }

    IEnumerator FinishGame()
    {
        finish = true;
        totalTimeCount = 0.0f;

        startTimerText.text = "Done";
        yield return new WaitForSeconds(2.0f);

        startTimerText.text = "";
        finishPanel.SetActive(true);

        returnTimerText.text = "3";
        yield return new WaitForSeconds(1.0f);
        returnTimerText.text = "2";
        yield return new WaitForSeconds(1.0f);
        returnTimerText.text = "1";
        yield return new WaitForSeconds(1.0f);
        returnTimerText.text = "0";

        Destroy(player.gameObject);
        SceneManager.LoadScene("MainMenu");


    }

    // Update is called once per frame
    void Update()
    {
        if (!finish)
        {
            TimerCount();
            LapLogic();
            positionTextUpper.text = playerPosition.ToString();
            checkpointA = checkpointArray;
        }
        
    }

    private void LapLogic()
    {
        if (currentLap != Lap)
        {
            if (Lap != 0)
            {
                lapTimeCount = 0.0f;
            }
        }
        Lap = currentLap;

        if (Lap > maxLaps) //disable this script if reach max laps
        {
            StartCoroutine(FinishGame());
        }
        if (Lap == 0) //display Lap 1 even if it's lap 0
        {
            lapText.text = "Lap " + (Lap + 1) + " of " + maxLaps;
        }
        else if (Lap <= maxLaps) //display lap text normally
        {
            lapText.text = "Lap " + Lap + " of " + maxLaps;
        }
    }

    private void TimerCount()
    {
        if (startTiming)
        {
            lapTimeCount += Time.deltaTime;
            totalTimeCount += Time.deltaTime;
            // Math to count each time properly
            lapTime[0] = Mathf.Floor(lapTimeCount / 60.0f);
            lapTime[1] = Mathf.Floor(lapTimeCount) % 60;
            lapTime[2] = Mathf.Floor(lapTimeCount * 1000.0f) % 999;

            totalTime[0] = Mathf.Floor(totalTimeCount / 60.0f);
            totalTime[1] = Mathf.Floor(totalTimeCount) % 60;
            totalTime[2] = Mathf.Floor(totalTimeCount * 1000.0f) % 999;
        }

        lapTimerText.text = string.Format("{0:00}:{1:00}.{2:000}", lapTime[0], lapTime[1], lapTime[2]);
        totalTimerText.text = string.Format("{0:00}:{1:00}.{2:000}", totalTime[0], totalTime[1], totalTime[2]);
    }
}
