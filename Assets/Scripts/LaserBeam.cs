using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {

    public float range = 100f;
    public bool isAND = false;
    public GameObject laserCollision;
    public GameObject laserParticle;
    public RaycastHit laserHit;
    public Ray shootRay;
    LineRenderer laserLine;
    bool mfw;
    int shootableMask;

    void Start ()
    {
        laserLine = GetComponent<LineRenderer>();
    }
	
	
	void Update ()
    {

        shootableMask = LayerMask.GetMask("Shootable");

        if( isAND == false)
        {
            DoTheLaser();
        }
       
    }

    void DoTheLaser ()
    {
        laserLine.enabled = true;    
        laserLine.SetPosition(0, transform.position);

        laserParticle.SetActive(true);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;


        if (Physics.Raycast(shootRay, out laserHit, range, shootableMask))
        {
            laserLine.SetPosition(1, laserHit.point);

            if (laserHit.collider.tag == "AND")
            {
                mfw = laserHit.collider.gameObject.GetComponent<RayDetection>().detectedRays[0];


                laserHit.transform.SendMessage("HitByRay");
            }

        }
        else
        {
            laserLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }

    //gonna use arrays to do the do
    void sendPower ()
    {

    }
}
