using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blowaway : MonoBehaviour
{

    private Rigidbody rb;

    public bool KillSEflg;

    [SerializeField] GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();

        transform.Rotate(270f, 0f, 0f);
        rb.AddForce(transform.forward * -800, ForceMode.Impulse);
        rb.AddForce(transform.up * -50, ForceMode.Impulse);
        rb.AddTorque(transform.right * 500);
        Invoke("ExplosionSet", 1.5f);
        Destroy(gameObject, 1.5f);
        KillSEflg = true;
    }

    // Update is called once per frame
    void Update()
    {
        KillSEflg = false;
    }

    private void ExplosionSet()
    {
        GameObject obj = Instantiate(explosion, this.transform.position, Quaternion.identity);
        //gameObject.SetActive(false);
        Destroy(gameObject, 2.0f);
        Destroy(obj, 2.5f);
    }
}
