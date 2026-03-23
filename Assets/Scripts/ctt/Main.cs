using UnityEngine;
using CTT;

public class CTTMain : MonoBehaviour
{
    private Controller controller;

    void Start()
    {
        controller = new Controller();
        controller.Start();
    }

    void Update()
    {
        Vector3 mouse = Input.mousePosition;

        float x = (mouse.x / Screen.width) * 2f - 1f;

        controller.Update(new Vector2(x, 0));
    }
}
