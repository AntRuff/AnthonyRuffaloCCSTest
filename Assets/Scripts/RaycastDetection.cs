using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDetection : MonoBehaviour
{

    [SerializeField] LineRenderer beam;

    RaycastHit hit; 
    Vector3 endPos = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        endPos = transform.position + (5f * transform.forward);

        if (Physics.Raycast(ray, out hit, 5f)){
            endPos = hit.point;
        }

        beam.SetPosition(0, transform.position);
        beam.SetPosition(1, endPos);       
    }

    public Vector3 GetPos(){
        return endPos;
    }
}
