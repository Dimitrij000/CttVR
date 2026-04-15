using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 150f;
    public Transform xrOrigin; // XR Origin или Player

    float xRotation = 0f;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // вертикальный поворот камеры
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // горизонтальный поворот XR Origin
        if (xrOrigin != null)
            xrOrigin.Rotate(Vector3.up * mouseX);
    }
}
