using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalleyScore : MonoBehaviour
{
    [SerializeField] private Text redText;
    [SerializeField] private Text yellowText;
    [SerializeField] private Text greenText;
    [SerializeField] private Text blueText;
    [SerializeField] private Text totalText;

    //Internal Variables
    private int redScore;
    private int yellowScore;
    private int greenScore;
    private int blueScore;
    private int totalScore;

    // Start is called before the first frame update
    void Start()
    {
        redScore = PlayerPrefs.GetInt("red");
        yellowScore = PlayerPrefs.GetInt("yellow");
        greenScore = PlayerPrefs.GetInt("green");
        blueScore = PlayerPrefs.GetInt("blue");
        totalScore = redScore + yellowScore + greenScore + blueScore;
        FinalScore();
    }

    void FinalScore()
    {
        redText.text = "Red Collected: " + redScore.ToString();
        yellowText.text = "Yellow Collected: " + yellowScore.ToString();
        greenText.text = "Green Collected: " + greenScore.ToString();
        blueText.text = "Blue Collected: " + blueScore.ToString();
        totalText.text = "Total Score: " + totalScore.ToString();
    }
}
