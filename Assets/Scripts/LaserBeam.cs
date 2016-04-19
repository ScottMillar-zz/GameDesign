using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {

    public float range = 100f;
    public bool isEnabled = false;
    public bool isAND = false;
    public bool continued = false;
    public GameObject laserCollision;
    public GameObject laserParticle;
    public RaycastHit laserHit;
    public Ray shootRay;

    public LineRenderer laserLine;
    bool mfw;
    int shootableMask;

    void Start ()
    {
        laserLine = GetComponent<LineRenderer>();
    }
	
	
	void Update ()
    {

        shootableMask = LayerMask.GetMask("Shootable");

        if(isEnabled == false)
        {
            DoTheLaser();
        }
        else if (isEnabled == true)
        {
            laserLine.enabled = false;
            laserParticle.SetActive(false);
        }


    }

    void DoTheLaser()
    {
        laserLine.enabled = true;
        laserLine.SetPosition(0, transform.position);

        laserParticle.SetActive(true);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out laserHit, range, shootableMask))
        {
           
            laserLine.SetPosition(1, laserHit.point);

            if (laserHit.collider.tag == "Key")
            {
                laserHit.transform.SendMessage("HitByRay");
            }

            if (laserHit.collider.tag == "AND")
            {
                runAND();
            }
            else if (continued == true)
            {
                continued = false;
                //GameObject.FindWithTag("AND").GetComponent<RayDetection>().detectedRays[1] == true
                if (GameObject.FindWithTag("AND").GetComponent<RayDetection>().detectedRays[1] == true)
                {
                    GameObject.FindWithTag("AND").GetComponent<RayDetection>().detectedRays[1] = false;
                }
                else
                {
                    GameObject.FindWithTag("AND").GetComponent<RayDetection>().detectedRays[0] = false;
                }
            }

        }
        else
        {
            laserLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
            
            
        
    

    //gonna use arrays to do the do
    //laserHit.collider.gameObject.GetComponent<RayDetection>().detectedRays[0];
    void runAND ()
    {
        if (laserHit.collider.tag == "AND")
        {
            if (continued == false)
            {
                if (laserHit.collider.gameObject.GetComponent<RayDetection>().detectedRays[0] == false)
                {
                    laserHit.collider.gameObject.GetComponent<RayDetection>().detectedRays[0] = true;
                }
                else if (laserHit.collider.gameObject.GetComponent<RayDetection>().detectedRays[0] == true && laserHit.collider.gameObject.GetComponent<RayDetection>().detectedRays[1] == false)
                {
                    laserHit.collider.gameObject.GetComponent<RayDetection>().detectedRays[1] = true;
                }
            }
            continued = true;
            
        }
    }
}
