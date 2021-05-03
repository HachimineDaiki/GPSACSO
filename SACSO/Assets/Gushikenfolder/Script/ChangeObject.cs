using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    public GameObject Drum;
    public GameObject BreakDrum;

    private void Start()
    {
        Drum.SetActive(false);
        BreakDrum.SetActive(true);
    }
}
