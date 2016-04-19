using UnityEngine;
using System.Collections;

public class UnlockDoor : MonoBehaviour {

    GameObject child;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void HitByRay ()
    {
        child = transform.GetChild(0).gameObject;
        child.SetActive(false);       
    }
}
