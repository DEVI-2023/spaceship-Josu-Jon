using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObject;
    public bool continueSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
        IEnumerator coroutine = SpawnRoutine();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(5);
        spawn();
        if (continueSpawn){
            IEnumerator coroutine = SpawnRoutine();
            StartCoroutine(coroutine);
        }
       
    }

    public void spawn()
    {
        GameObject newSpawn = Instantiate(spawnObject);
        newSpawn.transform.position = new Vector3(Random.Range(-120f, 120f), Random.Range(-120f, 120f), Random.Range(-120f, 120f));
        newSpawn.SetActive(true);
    }
}
