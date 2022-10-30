using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, 13);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -10);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-10, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(10, 0, 0);
        }

        if(transform.position.y < -10)
        {
            transform.position = new Vector3(-2, 3, -35);
        }
    }
    void OnCollisionStay(Collision hit)
    {
    if(hit.gameObject.tag == "Enemy")
    {
        transform.position = new Vector3(-3, 3, -35);
    }
    }
}

