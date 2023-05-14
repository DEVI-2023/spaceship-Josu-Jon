using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public GameObject gameControler;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        IEnumerator coroutine = LeafDestruction();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward / 20 * speed;
    }

    IEnumerator LeafDestruction()
    {
        yield return new WaitForSeconds(1);
        Destroy(GetComponent<MeshRenderer>());
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Hit();
            Destroy(GetComponent<MeshRenderer>());
            Destroy(gameObject);
        }
    }
}
