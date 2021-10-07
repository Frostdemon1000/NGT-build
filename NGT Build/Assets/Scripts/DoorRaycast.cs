using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRaycast : MonoBehaviour
{
    [SerializeField]
    private int _rayLength = 5;
    [SerializeField]
    private LayerMask _layerMaskInteract;
    [SerializeField]
    private string _excludeLayerName = null;

    private MyDoorController raycastedObj;

    [SerializeField]
    private KeyCode _openDoorKey = KeyCode.Mouse0;
}
