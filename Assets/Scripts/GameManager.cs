using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> objects;
    [SerializeField] TMPro.TextMeshProUGUI curTool;
    private List<string> tools;
    private int index = 0 ;

    void Start() {
        tools = new List<string>();
        tools.Add("Spawn");
        tools.Add("Grab");
        tools.Add("Delete");
        curTool.text = tools[0];
    }

    public void Cycle() {
        index++;
        if (index >= tools.Count){
            index = 0;
        }
        curTool.text = tools[index];
    }

    public void UseTool(){
        if (tools[index] == "Spawn"){
            Spawn();
        }
        else if (tools[index] == "Grab"){
            Grab();
        }
        else if (tools[index] == "Delete"){
            Delete();
        }

    }

    void Spawn(){
        //Create the game object
        //add it to list
    }

    void Grab() {
        //Place object in hand
        //Switch status to holding.
    }

    void Delete() {

    }
}
