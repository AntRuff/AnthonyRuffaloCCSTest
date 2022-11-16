using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> objects;
    [SerializeField] RaycastDetection raycast;
    //[SerializeField] TMPro.TextMeshProUGUI curTool;
    //private List<string> tools;
    private int objectIndex = 0;
    private int controlIndex = 0;

    private GameObject held = null;

    public void SpawnObject(){
        Vector3 spawnPoint = raycast.GetPos();
        GameObject newSpawn = Instantiate(objects[objectIndex]);
        newSpawn.transform.position = spawnPoint;
    }

    public void CycleObject(){
        if (objectIndex < objects.Count-1) {objectIndex++;}
        else { objectIndex = 0;}
    }

    public void Delete(){
        RaycastHit hit = raycast.GetHit();
        if (!hit.collider) {return;}
        if (hit.collider.tag == "Interactable"){
            Destroy(hit.collider.gameObject);
        }
    }

    public bool GrabObject() {
        if (raycast.GetHit().collider.tag == "Interactable"){
            held = raycast.GetHit().collider.gameObject;
            held.transform.parent = raycast.transform;
            return true;
        }
        return false;
    }

    public void PlaceObject(){
        held.transform.parent = null;
        held = null;
        controlIndex = 0;
    }

    public void ControlObject(Vector2 value){
        switch (controlIndex){
            case 0: 
                MoveObject(value);
                break;
            case 1:
                RotateObject(0, value);
                break;
            case 2:
                RotateObject(1, value);
                break;
            case 3:
                RotateObject(2, value);
                break;
        }
    }

    private void MoveObject(Vector2 value){
        var xValue = value.x;
        var yValue = value.y;

        float distance = Vector3.Distance (raycast.transform.position, held.transform.position);
        
        if ((distance >= 10 && yValue > 0.01)||(distance <= 0.5 && yValue < -0.01)){
            return;
        }

        held.transform.position += raycast.transform.forward * yValue * Time.deltaTime;
    }

    private void RotateObject(int axis, Vector2 value){
        var xValue = value.x;
        var yValue = value.y;
        switch(axis){
            case 0:
                held.transform.Rotate(Vector3.up, xValue * 15 * Time.deltaTime);
                break;
            case 1:
                held.transform.Rotate(Vector3.right, xValue * 15 * Time.deltaTime);
                break;
            case 2:
                held.transform.Rotate(Vector3.forward, xValue * 15 * Time.deltaTime);
                break;
        }
    }

    public void CycleControl() {
        if (controlIndex < 3) { controlIndex++; }
        else { controlIndex = 0; }
    }
}