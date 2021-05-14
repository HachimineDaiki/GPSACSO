using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTest : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Turn;

    private int TurnNum;
    void Start()
    {
        Turn = GameObject.Find("TurnObj");
        TurnNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (TurnNum)
        {
            case 0:
                Rotplus();
                break;
            case 1:
                Rotplus();
                break;
            case 2:
                Rotminus();
                break;
            case 3:
                Rotminus();
                break;
        }
    }

    Vector3 Get()
    {
        TurnPosGet PosGet = Turn.gameObject.GetComponent<TurnPosGet>();
        return (PosGet.TurnPos[TurnNum].transform.position);
    }

    void Rotplus()
    {
        if(Get().z < gameObject.transform.position.z)
        {
            float XposDis = Get().x - gameObject.transform.position.x;
        }
    }
    void Rotminus()
    {
        Debug.Log("minus");
    }
}
