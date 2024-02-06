using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingScript : MonoBehaviour
{
    private int score;
    private Rigidbody rb;

    [Header("Gravity")]
    [SerializeField] private float gravity = 3f;
    public bool useGravity = true;

    [Header("Audio")]
    [SerializeField] private AudioClip clip;
    [SerializeField] private float volume = 0.1f;
    private AudioSource audioSource;

    [HideInInspector] public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        score = 0;
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isPlaying)
        {
            rb.useGravity = true;

            if (Input.GetKeyDown("space"))
            {
                useGravity = false;
            }

            if (Input.GetKeyUp("space"))
            {
                useGravity = true;
            }

            if (useGravity)
            {
                rb.AddForce(new Vector3(0, -1.0f, 0) * rb.mass * gravity);
            }
        }
        else
        {
            rb.useGravity = false;
        }
    }
    
   private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Reset")
        {
            //Instantiate(spalshParticle, transform.position, Quaternion.Euler(-90, 0, 0));
            GameManager.Instance.ResetPos(startPos, this.gameObject);
            audioSource.PlayOneShot(clip, volume);
        }
    }

    #region Setters/Getters
    public void SetScore(int score)
    {
        this.score = score;
    }

    public int GetScore() 
    { 
        return score; 
    }
    #endregion


}
