using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Text _objDisplayText;
    [SerializeField]
    private Text _interactDisplay;


    private Ray _ray;
    private GameObject _plrCamera;

    private int _interactableLayer;

    private void Awake()
    {
        _plrCamera = transform.Find("Main Camera").gameObject;
        _interactableLayer = LayerMask.GetMask("Interactables");
    }

    private void Update()
    {
        DisplayUpdate();
    }

    private void DisplayUpdate()
    {
        _ray = new Ray(_plrCamera.transform.position, _plrCamera.transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(_ray, out RaycastHit hit, 7f, _interactableLayer))
        {
            _objDisplayText.text = hit.collider.gameObject.name;
        }
        else
        {
            _objDisplayText.text = null;
            _interactDisplay.text = null;
        }
    }

}