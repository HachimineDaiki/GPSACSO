using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blowaway : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField] GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        Vector3 ue = new Vector3(0f, 100f, 0f);

        transform.Rotate(270f, 0f, 0f);
        rb.AddForce(transform.forward * -800, ForceMode.Impulse);
        rb.AddForce(transform.up * -50, ForceMode.Impulse);
        rb.AddTorque(transform.right * 500);
        Invoke("ExplosionSet", 1.5f);
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ExplosionSet()
    {
        GameObject obj = Instantiate(explosion, this.transform.position, Quaternion.identity);
        //gameObject.SetActive(false);
        Destroy(gameObject, 2.0f);
        Destroy(obj, 2.5f);
    }
}
