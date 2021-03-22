using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shedderGet : MonoBehaviour
{

    Texture texture;

    Material material;

    float Des;

    Shader shader;
    // Start is called before the first frame update
    void Start()
    {
        Des = 0f;
        material = GetComponent<Renderer>().material;
        if (material.HasProperty("_Destruction"))
        {
            Debug.Log(material.GetFloat("_Destruction"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Des < 1f)
        {
            Des += Time.deltaTime / 1f;
        }

        if (material.HasProperty("_Destruction"))
        {
            material.SetFloat("_Destruction", Des);
            Debug.Log(Des);
        }
    }
}
