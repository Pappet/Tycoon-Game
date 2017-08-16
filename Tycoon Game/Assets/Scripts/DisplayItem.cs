using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayItem : MonoBehaviour {

    public float WaitingAmount;

	// Use this for initialization
	void Start () {
        WaitingAmount = Random.Range(1,10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float ReturnWaitingAmount()
    {
        return WaitingAmount;
    }
}
