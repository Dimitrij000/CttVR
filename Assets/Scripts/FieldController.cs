using UnityEngine;

public class FieldController : MonoBehaviour
{
    public Transform line;
    public Transform centralLine;

    void Start()
    {
        var settings = Settings.Instance;

        transform.localScale = new Vector3((float)settings.FieldSize / 10, 1, (float)settings.FieldSize / 10);

        line.localScale = new Vector3((float)settings.FieldSize, (float)settings.LineWidth, 0.1f);

        centralLine.localScale = new Vector3((float)settings.FieldSize, (float)settings.LineWidth, 0.1f);
    }
}
