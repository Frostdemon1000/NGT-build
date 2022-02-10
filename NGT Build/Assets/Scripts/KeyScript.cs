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

            LayerMask playerLayer;
            playerLayer = LayerMask.GetMask("Player");

            if (Physics.Raycast(ray, out RaycastHit hit, 4f, ~playerLayer))
            {
                if (hit.collider.name == transform.name)
                {
                    manager.KeyFound();
                    Destroy(gameObject);
                }
            }

        }
    }

}
