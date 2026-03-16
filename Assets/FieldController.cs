using UnityEngine;

public class FieldController : MonoBehaviour
{
    public Transform line;
    public Transform farLine;

    void Start()
    {
        var s = Settings.Load();

        // Размер поля
        transform.localScale = new Vector3((float)s.FieldSize, 1, (float)s.FieldSize);

        // Линия
        line.localScale = new Vector3((float)s.FieldSize, (float)s.LineWidth, 0.01f);

        // Дальняя линия
        farLine.localScale = new Vector3((float)s.FieldSize, (float)s.FarLineWidth, 0.01f);
    }
}
