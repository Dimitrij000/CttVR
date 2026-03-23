using UnityEngine;

public class LineMover : MonoBehaviour
{
    public static LineMover Instance;

    public Transform line;

    void Awake()
    {
        Instance = this;
    }

    public void SetLinePosition(float x)
    {
        if (line == null) return;

        float scale = 2f; // движение заметное, но не улетает

        // Двигаем линию внутри LineController
        line.localPosition = new Vector3(x * scale, 0, 0);
    }
}
