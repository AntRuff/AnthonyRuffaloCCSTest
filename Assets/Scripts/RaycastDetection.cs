using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDetection : MonoBehaviour
{
    //LineRenderer for raycast visualization
    [SerializeField] LineRenderer beam;

    //Variable for output of a Raycast
    RaycastHit hit;

    //End of raycast, either hit or the max distance
    Vector3 endPos = Vector3.zero;

    private float maxDistance = 5f;

    void Start(){
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, maxDistance)){ endPos = hit.point; }
        else { endPos = ray.GetPoint(maxDistance); }

        beam.SetPosition(0, ray.origin);
        beam.SetPosition(1, endPos);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, maxDistance)){ endPos = hit.point; }
        else { endPos = ray.GetPoint(maxDistance); }      
    }

    //Get the current End Postion
    public Vector3 GetPos(){
        return endPos;
    }

    //Get the RaycastHit information
    public RaycastHit GetHit(){
        return hit;
    }
}
