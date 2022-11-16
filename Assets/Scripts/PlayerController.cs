using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.XR.Management;
#else
using UnityEngine.XR.Management;
#endif

public class PlayerController : MonoBehaviour
{

    [SerializeField] GameManager mana;
    PlayerInput player_input;

    private void Start() {
        player_input = GetComponent<PlayerInput>();
    }

    public void OnSpawnMode(){
        player_input.SwitchCurrentActionMap("SpawnMode");
    }

    public void OnSpawnObject(){
        mana.SpawnObject();
        player_input.SwitchCurrentActionMap("Neutral");
    }

    public void OnCycleObject(){
        mana.CycleObject();
    }

    public void OnDelete(){
        mana.Delete();
    }
    
}
