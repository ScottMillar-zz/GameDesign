using UnityEngine;
using System.Collections;

public class RayDetection : MonoBehaviour
{

    public bool[] detectedRays = { false, false};

    GameObject laser;
    GameObject laserParticale;
    LineRenderer lineRenderer;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(detectedRays[0] == true && detectedRays[1] == true)
        {
            GetComponentInChildren<LaserBeam>().isEnabled = false;
        }
        else
        {
            GetComponentInChildren<LaserBeam>().isEnabled = true;
        }
    }

    void HitByRay()
    {
       // Debug.Log("I got whacked");
    }
}
