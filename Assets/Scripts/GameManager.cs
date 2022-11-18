using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;


//Manages object control and level state
public class GameManager : MonoBehaviour
{

    //List of object types that can be spawned
    [SerializeField] List<GameObject> objects;
    //Reference to the raycaster
    [SerializeField] RaycastDetection raycast;
    //UI for saving and loading levels
    [SerializeField] Canvas levelSelect;
    //Display action around hand
    [SerializeField] TMPro.TextMeshProUGUI toolTipText;
    
    //Indexs for cycling options
    private int objectIndex = 0;
    private int controlIndex = 0;

    //List of all spawned objects in the level
    private List<GameObject> objectList = new List<GameObject>();

    //The object being moved or rotated
    private GameObject held = null;

    private void Awake(){
        toolTipText.text = "";
        SaveLoad.Init();
    }

    //Rotates the text while spawning an object
    public void UpdateSpawnModeText(){
        switch(objectIndex){
            case 0:
                toolTipText.text = "Spawning Cube";
                break;
            case 1:
                toolTipText.text = "Spawning Sphere";
                break;
            case 2:
                toolTipText.text = "Spawning Capsule";
                break;
        }
    }

    //Spawns an object at end of ray, or where the ray hits
    public void SpawnObject(){
        Vector3 spawnPoint = raycast.GetPos();
        GameObject newSpawn = Instantiate(objects[objectIndex]);
        newSpawn.transform.position = spawnPoint;
        objectList.Add(newSpawn);
        toolTipText.text = "";
    }

    //Cycles spawned object
    public void CycleObject(){
        if (objectIndex < objects.Count-1) {objectIndex++;}
        else { objectIndex = 0;}
        UpdateSpawnModeText();
    }

    //Deletes object ray is hitting
    public void Delete(){
        RaycastHit hit = raycast.GetHit();
        if (!hit.collider) {return;}
        if (hit.collider.tag == "Interactable"){
            objectList.Remove(hit.collider.gameObject);
            Destroy(hit.collider.gameObject);
        }
    }

    //Grab object ray is hitting
    public bool GrabObject() {
        if (!raycast.GetHit().collider) {return false; }
        if (raycast.GetHit().collider.tag == "Interactable"){
            held = raycast.GetHit().collider.gameObject;
            held.transform.parent = raycast.transform;
            return true;
        }
        return false;
    }

    //Place held object where it is
    public void PlaceObject(){
        held.transform.parent = null;
        held = null;
        controlIndex = 0;
        toolTipText.text = "";
    }

    //Update's text while holding object
    public void UpdateControlText(){
        switch (controlIndex){
            case 0:
                toolTipText.text = "Move Forward and Back";
                break;
            case 1:
                toolTipText.text = "Rotate X";
                break;
            case 2:
                toolTipText.text = "Rotate Y";
                break;
            case 3:
                toolTipText.text = "Rotate Z";
                break;
        }
    }

    //Sends joystick inputs to either move or rotate held object
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

    //Move held object with joystick
    private void MoveObject(Vector2 value){
        var xValue = value.x;
        var yValue = value.y;

        float distance = Vector3.Distance (raycast.transform.position, held.transform.position);
        
        if ((distance >= 10 && yValue > 0.01)||(distance <= 0.5 && yValue < -0.01)){
            return;
        }

        held.transform.position += raycast.transform.forward * yValue * Time.deltaTime;
    }

    //Rotate held object with joystick
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

    //Cycle between moving and the axis of rotation
    public void CycleControl() {
        if (controlIndex < 3) { controlIndex++; }
        else { controlIndex = 0; }
        UpdateControlText();
    }

    //Save the level to the provided level slot
    public void SaveLevel(int level){
        List<ObjectData> saveInfo = new List<ObjectData>();
        foreach(GameObject obj in objectList){
            int pre;
            if (obj.GetComponent<BoxCollider>()){
                pre = 0;
            }
            else if (obj.GetComponent<SphereCollider>()){
                pre = 1;
            }
            else if (obj.GetComponent<CapsuleCollider>()){
                pre = 2;
            }
            else {
                Debug.LogError("Save Failed");
                return;
            }

            ObjectData savedObj = new ObjectData {
                prefabIndex = pre,
                position = obj.transform.position,
                rotation = obj.transform.rotation
            };
            saveInfo.Add(savedObj);
        }
        //Converts List of Object data to a json string for saving
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(saveInfo, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        SaveLoad.Save(json, level);
    }

    //Load level from json at slot provided
    public void LoadLevel(int level){
        string saveString = SaveLoad.Load(level);

        foreach(GameObject obj in objectList){
                Destroy(obj);
        }

        objectList = new List<GameObject>();

        if (saveString == null){    
            return;
        }
        //Reads the JSON into a list
        List<ObjectData> loadInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ObjectData>>(saveString);

        //Populates the object list with the info loaded.
        foreach(ObjectData data in loadInfo){
            GameObject newObject = Instantiate(objects[data.prefabIndex], data.position, data.rotation);
            objectList.Add(newObject);
        }
    }

    //Opens the level save/load menu
    public void OpenLevelSelect(){
        levelSelect.gameObject.SetActive(true);
    }

    //Triggers the OnClick event for a button in the UI
    public bool SelectOption(){
        RaycastHit hit = raycast.GetHit();
        if(!hit.collider) {return false; }
        if(hit.collider.gameObject.GetComponent<Button>()){
            hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
            return true;
        }
        return false;
    }

    //Small class to store relavent information to save and load levels.
    public class ObjectData {   
        public int prefabIndex;
        public Vector3 position;
        public Quaternion rotation;
    }

}