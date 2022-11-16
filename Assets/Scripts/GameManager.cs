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
    private int index = 0;

    public void SpawnObject(){
        Vector3 spawnPoint = raycast.GetPos();
        GameObject newSpawn = Instantiate(objects[index]);
        newSpawn.transform.position = spawnPoint;
    }

    public void CycleObject(){
        if (index < objects.Count-1) {index++;}
        else { index = 0;}
    }
}