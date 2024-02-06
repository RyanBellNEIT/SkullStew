using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image skullDisplay;
    [SerializeField] private Sprite[] skulls;
    [SerializeField] private string[] chosenSkullList;
    [SerializeField] private Text[] scoreText;
    [SerializeField] private List<GameObject> playUIObjects;


    public string chosenSkullName;
    public bool isPlaying = false;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.Log("Game Manager is null.");
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PickSkull();
    }

    public void PickSkull()
    {
        int imgCount = skulls.Length;
        int chosenSkull = Random.Range(0, imgCount);
        skullDisplay.sprite = skulls[chosenSkull];
        chosenSkullName = chosenSkullList[chosenSkull];
    }

    public void ResetPos(Vector3 startPos, GameObject obj)
    {
        var restartPos = new Vector3(Random.Range(-3, 3), startPos.y, startPos.z);
        obj.transform.position = restartPos;
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.GetComponent<Rigidbody>().AddForce(0,Random.Range(1,5),0, ForceMode.Impulse);
    }

    public void AddScore(int color, int score)
    {
        scoreText[color].text = score.ToString();
    }

    public void StartGame()
    {
        isPlaying = true;
        foreach(GameObject obj in playUIObjects)
        {
            obj.SetActive(true);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}
