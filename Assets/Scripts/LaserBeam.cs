using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {

    public float range = 100f;

    Ray shootRay;
    RaycastHit laserHit;
    LineRenderer laserLine;
    int shootableMask;

    void Start ()
    {

        laserLine = GetComponent<LineRenderer>();

    }
	
	
	void Update ()
    {

        shootableMask = LayerMask.GetMask("Shootable");

        laserLine.enabled = true;
        laserLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out laserHit, range, shootableMask))
        {
            laserLine.SetPosition(1, laserHit.point);
        }

        else
        {
            laserLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
