using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushEnemies : MonoBehaviour
{
    [SerializeField] private bool active;        //判定の有効か否か
    [SerializeField] private float time;
    // Start is called before the first frame update
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            //active = false;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    public void DoorOpen()
    {
        active = true;
        time = 0.8f;
    }

    private void OnTriggerStay(Collider obj)
    {
        Destroy(obj);
        //Debug.Log(obj.gameObject.name);
        if (obj.gameObject.tag == "Enemy")
        {
            if (active)
            {
                Rigidbody rb = obj.gameObject.GetComponent<Rigidbody>();
                rb.AddForce((transform.forward + (transform.up)) * 100.0f);
            }
        }
    }
}
