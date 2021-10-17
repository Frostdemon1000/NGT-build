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
            if (Physics.Raycast(_playerRay, out RaycastHit hit, _raycastRange, _layerMask))
            {
                _tempObj = hit.transform.gameObject;
                print(_tempObj.name);
                CheckCollider(_tempObj);
            }
            else { print(null); return; }
        }
    }

    private void CheckCollider(GameObject _hitObj)
    {
        if (_hitObj.CompareTag("Door"))
        {
            _hitObj.GetComponentInParent<DoorScript>().PlayAnimation();
        }

        if (_hitObj.CompareTag("Liftable"))
        {
            
        }
    }
}
