using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.XR.Management;
#else
using UnityEngine.XR.Management;
#endif

public class PlayerController : MonoBehaviour
{

    [SerializeField] GameManager mana;

    public void UseTool(){
        mana.UseTool();
    }

    public void OnCycleMenu(){
        mana.Cycle();
    }
}
