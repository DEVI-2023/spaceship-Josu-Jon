using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedControler();
        rotation();
        move();
    }

    void move()
    {
        this.transform.position += Vector3.forward * Time.deltaTime * speed;
    }

    void speedControler()
    {
        
    }

    void rotation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.rotation *= Quaternion.Euler(0,1,0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.rotation *= Quaternion.Euler(0, -1, 0);
        }
    }
}
