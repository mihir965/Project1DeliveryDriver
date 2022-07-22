using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float steerSpeed = 0.5f;
    [SerializeField] float moveSpeed = 0.05f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float carSpeed = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, carSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedUps")
        {
            Debug.Log("The speed Increased!!");
            moveSpeed += 1f;
        }
        else if (other.tag == "SlowDowns")
        {
            Debug.Log("The speed Decreased");
            moveSpeed -= 1f;
        }
    }
}
