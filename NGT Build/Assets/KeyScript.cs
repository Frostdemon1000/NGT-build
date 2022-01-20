using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private GameManager manager;

    private bool canPickUp = false;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        CheckMouse();
    }

    private void CheckMouse()
    {
        if (Input.GetMouseButtonDown(0) && canPickUp)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit);

                if (hit.collider.name == transform.name)
                {
                    manager.KeyFound();
                    Destroy(gameObject);
                }
            }

        }
    }


    // Collision checks
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canPickUp = false;
    }

}
