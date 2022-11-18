using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.XR.Management;
#else
using UnityEngine.XR.Management;
#endif*/

//Handles the events for Player Inputs
public class PlayerController : MonoBehaviour
{
    //Game Manager
    [SerializeField] GameManager mana;
    //The player
    [SerializeField] GameObject player;
    //Player inputs
    PlayerInput player_input;

    private void Start() {
        player_input = GetComponent<PlayerInput>();
    }

    //Event that fires when SpawnMode is triggered
    public void OnSpawnMode(){
        mana.UpdateSpawnModeText();
        player_input.SwitchCurrentActionMap("SpawnMode");
    }

    //Event that fires when SpawnObject is triggered
    public void OnSpawnObject(){
        mana.SpawnObject();
        player_input.SwitchCurrentActionMap("Neutral");
    }

    //Event that fires when CycleObject is triggered
    public void OnCycleObject(){
        mana.CycleObject();
    }

    //Event that fires when Delete is triggered
    public void OnDelete(){
        mana.Delete();
    }

    //Event that fires when GrabMode is triggered
    public void OnGrabMode(){
        if (mana.GrabObject()) {
            player_input.SwitchCurrentActionMap("GrabMode");
            mana.UpdateControlText();
        }
    }

    //Event that fires when PlaceObject is triggered
    public void OnPlaceObject(){
        player_input.SwitchCurrentActionMap("Neutral");
        mana.PlaceObject();
    }

    //Event that fires when ControlObject is triggered
    public void OnControlObject(InputValue value){
        mana.ControlObject(value.Get<Vector2>());
    }

    //Event that fires when CycleControl is triggered
    public void OnCycleControl(){
        mana.CycleControl();
    }

    //Event that fires when Movement is triggered, moves the player around.
    public void OnMovement(InputValue value){
        Camera cam = player.GetComponentInChildren<Camera>();

        Vector2 extract = value.Get<Vector2>();
        Vector3 direction = new Vector3(extract.x, 0, extract.y);
        player.transform.position += direction * Time.deltaTime;  
    }

    //Event that fires when SaveMode is triggered
    public void OnSaveMode(){
        player_input.SwitchCurrentActionMap("LevelSelect");
        mana.OpenLevelSelect();
    }

    //Event that fires when Select is triggered
    public void OnSelect(){
        if (mana.SelectOption()){player_input.SwitchCurrentActionMap("Neutral");}
    }
}
