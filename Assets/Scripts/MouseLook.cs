using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 150f;

    float xRotation = 0f;
    float yRotation = 0f;
    bool _isMouseDown = false;
    float _mouseDownX = 0f;
    float _mouseDownY = 0f;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (!_isMouseDown)
            {
                _isMouseDown = true;
                _mouseDownX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
                _mouseDownY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

                return;
            }
            else
            {
                float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

                xRotation -= mouseY - _mouseDownY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);
                yRotation += mouseX - _mouseDownX;
                transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
            }
        }
        else if (_isMouseDown)
        {
            _isMouseDown = false;
        }
    }
}
