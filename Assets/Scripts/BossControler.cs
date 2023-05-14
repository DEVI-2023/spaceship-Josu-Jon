using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossControler : MonoBehaviour
{
    public GameObject target;
    public GameObject gameControler;
    public GameObject spawnedEnemy;
    private Vector3[] enemyPositions = { new Vector3(50, 0, 250), new Vector3(-50, 0, 250), new Vector3(50, 20, 250), new Vector3(-50, 20, 250), new Vector3(20, 20, 250), new Vector3(-20, 20, 250), new Vector3(0, 30, 250), new Vector3(0, -20, 250) };
    // Start is called before the first frame update
    void Start()
    {
        gameControler.GetComponent<Spawner>().continueSpawn = false;
        IEnumerator coroutine = Wave1();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
    }

    private void Shoot()
    {

    }

    private void SpawnEnemy(int numEnemy)
    {
        for (int i = 0; i < numEnemy; i++)
        {
            Debug.Log("Enemys Spawned");
            GameObject newSpawn = Instantiate(spawnedEnemy);
            newSpawn.transform.position = enemyPositions[i];
            newSpawn.SetActive(true);
        }

    }
    IEnumerator Wave1()
    {
        SpawnEnemy(2);
        yield return new WaitForSeconds(10);
        IEnumerator coroutine = Wave2();
        StartCoroutine(coroutine);
    }

    IEnumerator Wave2()
    {
        SpawnEnemy(4);
        yield return new WaitForSeconds(15);
        IEnumerator coroutine = Wave3();
        StartCoroutine(coroutine);
    }

    IEnumerator Wave3()
    {
        SpawnEnemy(8);
        yield return new WaitForSeconds(2);
    }
}
