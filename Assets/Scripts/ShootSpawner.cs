using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class ShootSpawner : MonoBehaviour
{
    public GameObject shooter;
    public GameObject shoot1;
    public GameObject shootZone1;
    public GameObject shoot2;
    public GameObject shootZone2;
    public GameObject bomb;
    public GameObject boss;
    public int shootSpeed;
    public int deads = 0;
    private bool bombReady = true;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newShoot1 = Instantiate(shoot1, shootZone1.transform.position, shooter.transform.rotation);
            GameObject newShoot2 = Instantiate(shoot2, shootZone2.transform.position, shooter.transform.rotation);
            newShoot1.SetActive(true);
            newShoot2.SetActive(true);
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (bombReady == true)
            {
                bombReady = false;
                GameObject newBomb = Instantiate(bomb, shooter.transform.position, shooter.transform.rotation);
                newBomb.SetActive(true);
                IEnumerator coroutine = bombActive();
                StartCoroutine(coroutine);
                
            }
           
        }

    }

    IEnumerator bombActive()
    {
        yield return new WaitForSeconds(10);
        bombReady = true;      
    }

    public void ActiveBoss()
    {
        if (deads >= 1)
        {
            boss.SetActive(true);
        }
    }



}
