using UnityEngine;
using System.Collections;

public class LaserCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = GetComponentInParent<LaserBeam>().laserHit.point;
        transform.LookAt(transform.parent.parent.position);
    }
}
