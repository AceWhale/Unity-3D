using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    private InputAction lookAction;
    private GameObject cameraPosition3;
    private GameObject character;
    private Vector3 c;
    private Vector3 cameraAngles;
    private bool isFpv;
    private float sensitivityH = 0.15f;
    private float sensitivityV = -0.08f;

    private float minDistance = 0.0f;
    private float maxDistance = 10.0f;

    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
        character = GameObject.Find("Character");
        c = this.transform.position - character.transform.position;
        cameraPosition3 = GameObject.Find("CameraPosition");
        cameraAngles = this.transform.eulerAngles;
        isFpv = true;
    }

    void Update()
    {
        if (isFpv)
        {
            float wheel = Input.mouseScrollDelta.y;
            c *= 1 - wheel / 10.0f;

            float distance = c.magnitude;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
            c = c.normalized * distance;

            if (distance < 1.0f)
            {
                c = c.normalized * minDistance;
            }

            GameState.isFpv = distance < 0.25f;

            Vector2 lookValue = lookAction.ReadValue<Vector2>();
            cameraAngles.x += lookValue.y * sensitivityV;
            cameraAngles.y += lookValue.x * sensitivityH;

            if (distance == minDistance)
            {
                cameraAngles.x = Mathf.Clamp(cameraAngles.x, -35f, 20f);
            }
            else
            {
                cameraAngles.x = Mathf.Clamp(cameraAngles.x, 35f, 75f);
            }

            this.transform.eulerAngles = cameraAngles;

            this.transform.position = character.transform.position +
                Quaternion.Euler(0, cameraAngles.y, 0) * c;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isFpv)
            {
                this.transform.position = cameraPosition3.transform.position;
                this.transform.rotation = cameraPosition3.transform.rotation;
            }
            isFpv = !isFpv;
        }
    }
}