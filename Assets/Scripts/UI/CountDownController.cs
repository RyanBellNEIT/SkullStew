using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownController : MonoBehaviour
{
    [SerializeField] private float timeRemaining;

    // Update is called once per frame
    void Update()
    {
        CountDown();
    }

    private void CountDown()
    {
        if (timeRemaining > 1f)
        {
            if(SceneManager.GetActiveScene().isLoaded)
            {
                timeRemaining -= Time.deltaTime;
                this.GetComponent<Text>().text = timeRemaining.ToString().Split(".")[0];
            }
        }
        else if (timeRemaining <= 1f && timeRemaining > 0.3f)
        {
            timeRemaining -= Time.deltaTime;
            GetComponent<Text>().text = "GO!";
        }
        else if(timeRemaining <= 0.3f)
        {
            TimeIsUp();
        }
    }

    private void TimeIsUp()
    {
        GameManager.Instance.StartGame();
        this.gameObject.SetActive(false);
    }
}
