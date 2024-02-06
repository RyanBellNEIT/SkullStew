using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    [SerializeField] private float timeRemaining;

    //Internal Variables
    private int minutes;
    private int seconds;

    // Update is called once per frame
    void Update()
    {
        CountDown();
    }

    private void CountDown()
    {
        if (timeRemaining > 1f)
        {
            timeRemaining -= Time.deltaTime;
            minutes = Mathf.FloorToInt(timeRemaining / 60);
            seconds = Mathf.FloorToInt(timeRemaining % 60);

            if (seconds < 10)
            {
                GetComponent<Text>().text = "" + seconds;
            }
            else
            {
                GetComponent<Text>().text = "" + seconds;
            }
        }
        else if (timeRemaining <= 1f)
        {
            GetComponent<Text>().text = "GO!";
            timeRemaining = 0;
            TimeIsUp();
        }
    }

    private void TimeIsUp()
    {
        GameManager.Instance.StartGame();
        this.gameObject.SetActive(false);
    }
}
