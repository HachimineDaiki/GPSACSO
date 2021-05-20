using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPSCameraCon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject obj;
    StoryText text;
    void Start()
    {
        text = obj.GetComponent<StoryText>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Acchild = transform.GetChild(text.SceneCnt).gameObject;
    }
}
