using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private Object[] allObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameFinish()
    {
        Debug.Log("Game Finish");
        allObjects = FindObjectsOfType(typeof(MonoBehaviour));
        foreach (Object obj in allObjects)
        {
            if (obj.GameObject().tag != "Inmortal")
            {

                Destroy(obj.GetComponent<MeshRenderer>());
                Destroy(obj);
            }
        }
    }
}
