using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDetection : MonoBehaviour
{

    [SerializeField] LineRenderer beam;

    RaycastHit hit; 
    Vector3 endPos = Vector3.zero;

    void Start(){
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 5f)){ endPos = hit.point; }
        else { endPos = ray.GetPoint(5); }

        beam.SetPosition(0, ray.origin);
        beam.SetPosition(1, endPos);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 5f)){ endPos = hit.point; }
        else { endPos = ray.GetPoint(5); }

        //beam.SetPosition(0, ray.origin);
        //beam.SetPosition(1, endPos);       
    }

    public Vector3 GetPos(){
        return endPos;
    }

    public RaycastHit GetHit(){
        return hit;
    }
}
