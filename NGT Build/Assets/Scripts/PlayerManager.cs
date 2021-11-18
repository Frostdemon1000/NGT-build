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

    private Transform _originalTrans;

    private Ray _ray;
    private GameObject _plrCamera;

    private int _interactableLayer;

    private bool _canHide = false;
    private bool _isHiding = false;

    private void Awake()
    {
        _plrCamera = transform.Find("Main Camera").gameObject;
        _interactableLayer = LayerMask.GetMask("Interactables");
    }

    private void Update()
    {
        DisplayUpdate();
        CheckInput();
    }

    private void DisplayUpdate()
    {
        _ray = new Ray(_plrCamera.transform.position, _plrCamera.transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(_ray, out RaycastHit hit, 7f, _interactableLayer))
        {
            _objDisplayText.text = hit.collider.gameObject.name;

            if (hit.collider.gameObject.name == "HideBarrel")
            {
                _interactDisplay.text = "E to hide";
                _canHide = true;
            }
            else
            {
                _interactDisplay.text = null;
                _canHide = false;
            }
        }
        else
        {
            _objDisplayText.text = null;
            _canHide = false;
            _interactDisplay.text = null;
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canHide && !_isHiding && Physics.Raycast(_ray, out RaycastHit hit, 7f, _interactableLayer))
        {
            _originalTrans = transform;
            transform.Find("Main Camera").SetPositionAndRotation(hit.collider.transform.Find("CameraSpot").position, hit.collider.transform.Find("CameraSpot").rotation);
            transform.GetComponent<PlayerMovement>().canMove = false;
            transform.GetComponent<PlayerCamera>().canRotate = false;
            _isHiding = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && _canHide && _isHiding)
        {
            transform.SetPositionAndRotation(_originalTrans.position, _originalTrans.rotation);

            transform.GetComponent<PlayerMovement>().canMove = true;
            transform.GetComponent<PlayerCamera>().canRotate = true;
            _isHiding = false;
        }
    }
}