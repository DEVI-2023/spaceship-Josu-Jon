using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject gameControler;
    private int speed;
    public int speedModifier;
    public int rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        speedControler();
        move();
        rotation();
    }

    void move()
    {
        transform.position += transform.forward /20 * speed;
    }

    void speedControler()
    {
        if (Input.GetKey(KeyCode.Alpha0))
        {
            speed = 0;
        }else if(Input.GetKey(KeyCode.Alpha1)) 
        {
            speed = 1 * speedModifier;
        }else if(Input.GetKey(KeyCode.Alpha2))
        {
            speed = 2 * speedModifier;
        }else if(Input.GetKey(KeyCode.Alpha3))
        {
            speed = 4 * speedModifier;
        }else if (Input.GetKey(KeyCode.Alpha4))
        {
            speed = 6 * speedModifier;
        }else if (Input.GetKey(KeyCode.Alpha5))
        {
            speed = 10 * speedModifier;
        }
    }

    void rotation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Rotate(Vector3.left * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.down * Time.deltaTime * rotationSpeed);           
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed); 
        }
        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            this.transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
        }
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player touch: " + collision.gameObject.name);
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            gameControler.GetComponent<EndGame>().GameFinish();
        }
    }
}
