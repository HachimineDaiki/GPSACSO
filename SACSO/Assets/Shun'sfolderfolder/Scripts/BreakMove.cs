using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //parentGameObjectは親要素のgameObject
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.transform.Translate(child.transform.position.x / 5.0f, child.transform.position.y / 5.0f, 0);
        }

    }
}
