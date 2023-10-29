using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 10f;

    [SerializeField] float slowSpeed = 8f;
    [SerializeField] float slowerSpeed = 6f;

    [SerializeField] float slowestSpeed = 4f;

    [SerializeField] float boostSpeed = 15f;

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "House")
        { 
            moveSpeed = slowestSpeed;
        }
        else if(other.gameObject.tag == "Bump")
        { 
            moveSpeed = slowerSpeed;
        }
        else if(other.gameObject.tag == "Small Bump")
        { 
            moveSpeed = slowSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
        
    }

}
