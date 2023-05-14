using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int lifes;
    public GameObject gameControler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
        lifes--;
        if (lifes<=0) 
        {
            Die();
        }
        
    }

    private void Die()
    {
        gameControler.GetComponent<ShootSpawner>().ActiveBoss();
        gameControler.GetComponent<ShootSpawner>().deads++;
        Destroy(GetComponent<MeshRenderer>());
        Destroy(gameObject);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (gameObject.tag == "Boss")
            {
                gameControler.GetComponent<EndGame>().GameFinish();
            }
            else
            {
                Die();
            }
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            if(gameObject.tag == "Shield")
            {
                Hit();
            }
            else if(gameObject.tag == "Boss" && GameObject.FindGameObjectsWithTag("Shield").Length == 0)
            {
                gameControler.GetComponent<EndGame>().GameFinish();
            }
            else if(gameObject.tag != "Boss")
            {
                Die();
            }

        }
    }
}
