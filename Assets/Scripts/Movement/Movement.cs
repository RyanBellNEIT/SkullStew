using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(direction * Time.deltaTime * speed);
    }
}
