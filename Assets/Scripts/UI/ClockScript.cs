using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour
{
    [SerializeField] private float timeRemaining;
    [SerializeField] private GameObject[] skulls;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip; 

    //Internal Variables
    private int minutes;
    private int seconds;

    // Start is called before the first frame update
    void Start()
    {
        //timeRemaining = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
    }

    private void CountDown()
    {
        if(timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
            minutes = Mathf.FloorToInt(timeRemaining/60);
            seconds = Mathf.FloorToInt(timeRemaining%60);

            if(seconds < 10)
            {
                GetComponent<Text>().text = "Time left " + minutes + ":0" + seconds;
            }
            else
            {
                GetComponent<Text>().text = "Time left " + minutes + ":" + seconds;
            }
        }
        else
        {
            timeRemaining = 0;
            GetComponent<Text>().text = "Time left 0:00";
            source.PlayOneShot(clip);
            Thread.Sleep(10);
            TimeIsUp();
        }
    }

    private void TimeIsUp()
    {
      
        for (int i = 0; i < skulls.Length; i++)
        {
            PlayerPrefs.SetInt(skulls[i].gameObject.tag, skulls[i].GetComponent<FallingScript>().GetScore());
        }
        GameManager.Instance.GameOver();
    }
}
