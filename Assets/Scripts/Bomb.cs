using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int force;
    private bool explote;
    // Start is called before the first frame update
    void Start()
    {
        IEnumerator coroutine = BombShoot();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward / 20 * 2;
        if (explote)
        {
            Big();
        }
    }

    IEnumerator BombShoot()
    {
        yield return new WaitForSeconds(3);
        explote = true;
        IEnumerator coroutine = BombExplote();
        StartCoroutine(coroutine);
    }

    IEnumerator BombExplote()
    {
        yield return new WaitForSeconds(5);
        Destroy(GetComponent<MeshRenderer>());
        Destroy(gameObject);
    }
    private void Big()
    {
        this.transform.localScale += new UnityEngine.Vector3(2,2,2);
    }
   
}
