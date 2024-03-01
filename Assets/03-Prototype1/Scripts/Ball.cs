using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject ball;

    public float speed = 5f;

    float edge = 10f;

    bool canMove = true;

    public float resetPositionY = 14f;

    public float force = 3f;

   // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Vector3 pos = transform.position;

            pos.z += speed * Time.deltaTime;
            transform.position = pos;

            if (pos.z < -edge)
            {
                speed = Mathf.Abs(speed);
            }
            else if (pos.z > edge)
            {
                speed = -Mathf.Abs(speed);
            }
        }

        if(Input.GetMouseButtonDown(0)) 
        { 
            canMove = false;
            ball.GetComponent<Rigidbody>().isKinematic = false;
            float randomForce = Random.Range(-force, force);
            Vector3 forceVector = new Vector3(0, 0, randomForce);
            ball.GetComponent<Rigidbody>().AddForce( forceVector, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bottom")
        {
            //reset ball
            canMove = true;
            ball.GetComponent <Rigidbody>().isKinematic = true;
            ball.transform.position = new Vector3(0, resetPositionY, 0);

        }
    }
}
