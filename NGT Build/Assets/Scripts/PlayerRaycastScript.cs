using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastScript : MonoBehaviour
{
    [SerializeField]
    private int _raycastRange;

    private int _layerMask;

    private Ray _playerRay;
    private GameObject _tempObj;

    private void Awake()
    {
        _layerMask = LayerMask.GetMask("Interactables");
    }

    private void Update()
    {
        _playerRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        CallRay();
    }

    private void CallRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red, 2f);
            if (Physics.Raycast(_playerRay, out RaycastHit hit, _raycastRange, _layerMask))
            {
                _tempObj = hit.transform.gameObject;
            }
            else { print("null"); return; }

            print(_tempObj.name);
            CheckCollider(_tempObj);
        }
    }

    private void CheckCollider(GameObject _raycastHit)
    {
        if (_raycastHit.CompareTag("Door"))
        {
            _raycastHit.GetComponentInParent<DoorScript>().PlayAnimation();
        }

        if (_raycastHit.CompareTag("Liftable"))
        {
            
        }
    }
}
