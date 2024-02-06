using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CauldronScore : MonoBehaviour
{
    [SerializeField] private GameObject[] skullScores;
    [SerializeField] private GameObject splashParticle;
    public string chosenSkull;
    public AudioClip[] clips;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.1f;

    private void Start()
    {
        PlayerPrefs.DeleteKey("red");
        PlayerPrefs.DeleteKey("yellow");
        PlayerPrefs.DeleteKey("green");
        PlayerPrefs.DeleteKey("blue");
    }

    void OnTriggerEnter(Collider col)
    {
        chosenSkull = GameManager.Instance.chosenSkullName;
        GetComponent<AudioSource>().PlayOneShot(clips[Random.Range(0, clips.Length)]);

        //check to see if it is the chosen skull
        //green skull
        if (col.gameObject.tag == "green")
        {
            GameObject splash = Instantiate(splashParticle, transform.position, Quaternion.identity);
            splash.GetComponent<ParticleSystem>().Play();
            if (chosenSkull == "green")
            {
                //reset position
                GameManager.Instance.ResetPos(skullScores[0].GetComponent<FallingScript>().startPos, skullScores[0]);
                audioSource.PlayOneShot(clip, volume);
                //adds to the score
                skullScores[0].GetComponent<FallingScript>().SetScore(skullScores[0].GetComponent<FallingScript>().GetScore() + 1);
                //call AddScore on GameManager to display score
                GameManager.Instance.AddScore(0, skullScores[0].GetComponent<FallingScript>().GetScore());
                //pick next skull
                GameManager.Instance.PickSkull();
            }
            else
            {
                //reset position
                GameManager.Instance.ResetPos(skullScores[0].GetComponent<FallingScript>().startPos, skullScores[0]);
                audioSource.PlayOneShot(clip, volume);
            }
        }

        //blue skull
        if (col.gameObject.tag == "blue")
        {
            GameObject splash = Instantiate(splashParticle, transform.position, Quaternion.identity);
            splash.GetComponent<ParticleSystem>().Play();
            if (chosenSkull == "blue")
            {
                //reset position
                GameManager.Instance.ResetPos(skullScores[1].GetComponent<FallingScript>().startPos, skullScores[1]);
                audioSource.PlayOneShot(clip, volume);
                //adds to the score
                skullScores[1].GetComponent<FallingScript>().SetScore(skullScores[1].GetComponent<FallingScript>().GetScore() + 1);
                //call AddScore on GameManager to display score
                GameManager.Instance.AddScore(1, skullScores[1].GetComponent<FallingScript>().GetScore());
                //pick next skull
                GameManager.Instance.PickSkull();
            }
            else
            {
                //resets position
                GameManager.Instance.ResetPos(skullScores[1].GetComponent<FallingScript>().startPos, skullScores[1]);
                audioSource.PlayOneShot(clip, volume);

            }
        }

        //red skull
        if (col.gameObject.tag == "red")
        {
            GameObject splash = Instantiate(splashParticle, transform.position, Quaternion.identity);
            splash.GetComponent<ParticleSystem>().Play();
            if (chosenSkull == "red")
            {
                //reset position
                GameManager.Instance.ResetPos(skullScores[2].GetComponent<FallingScript>().startPos, skullScores[2]);
                audioSource.PlayOneShot(clip, volume);
                //adds to the score
                skullScores[2].GetComponent<FallingScript>().SetScore(skullScores[2].GetComponent<FallingScript>().GetScore() + 1);
                //call AddScore on GameManager to display score
                GameManager.Instance.AddScore(2, skullScores[2].GetComponent<FallingScript>().GetScore());
                //pick next skull
                GameManager.Instance.PickSkull();
            }
            else
            {
                //reset position
                GameManager.Instance.ResetPos(skullScores[2].GetComponent<FallingScript>().startPos, skullScores[2]);
                audioSource.PlayOneShot(clip, volume); ;
            }
        }

        //yellow skull
        if (col.gameObject.tag == "yellow")
        {
            GameObject splash = Instantiate(splashParticle, transform.position, Quaternion.identity);
            splash.GetComponent<ParticleSystem>().Play();
            if (chosenSkull == "yellow")
            {
                //reset position
                GameManager.Instance.ResetPos(skullScores[3].GetComponent<FallingScript>().startPos, skullScores[3]);
                audioSource.PlayOneShot(clip, volume);
                //adds to the score
                skullScores[3].GetComponent<FallingScript>().SetScore(skullScores[3].GetComponent<FallingScript>().GetScore() + 1);
                //call AddScore on GameManager to display score
                GameManager.Instance.AddScore(3, skullScores[3].GetComponent<FallingScript>().GetScore());
                //pick next skull
                GameManager.Instance.PickSkull();
            }
            else
            {
                //reset position
                GameManager.Instance.ResetPos(skullScores[3].GetComponent<FallingScript>().startPos, skullScores[3]);
                audioSource.PlayOneShot(clip, volume);
            }
        }
    }
}
