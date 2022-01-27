using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private GameManager manager;


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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward));

            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), Color.red, 1f);

            if (Physics.Raycast(ray, out RaycastHit hit, 5f))
            {
                Debug.Log(hit.collider.name);

                if (hit.collider.name == transform.name)
                {
                    manager.KeyFound();
                    Destroy(gameObject);
                }
            }

        }
    }

}
