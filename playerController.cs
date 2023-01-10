using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private float speed = 15.0f;
    private float turnSpeed = 35.0f;
    private float horizontalInput;
    private float forwardInput;
    private float forwardSpeed;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); //equals -1 when pressing a and 1 when pressing d
        forwardInput = Input.GetAxis("Vertical"); //equals -1 when pressing s and 1 when pressing w

        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed * speed); //moves forward and backward
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput * forwardInput); // rotates left and right

        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.identity;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            forwardSpeed = 0;
        }
    }

    void FixedUpdate()
    {
        forwardSpeed = (forwardSpeed*30 + forwardInput) / 31;
    }
}
