using UnityEngine;

public class FieldController : MonoBehaviour
{
    public Transform line;
    public Transform centralLine;

    // Новые линии
    public Transform thresholdLine1;
    public Transform thresholdLine2;

    void Start()
    {
        var settings = Settings.Instance;

        // Масштаб поля
        transform.localScale = new Vector3(
            (float)settings.FieldSize / 10f,
            1,
            (float)settings.FieldSize / 10f
        );

        // Цвет фона
        var renderer = GetComponent<MeshRenderer>();
        if (renderer != null)
            renderer.material.color = settings.BackgroundColor;

        // Основная линия
        line.localScale = new Vector3(
            (float)settings.FieldSize,
            (float)settings.LineWidth,
            0.1f
        );
        line.GetComponent<MeshRenderer>().material.color = settings.LineColor;

        // Центральная линия
        centralLine.localScale = new Vector3(
            (float)settings.FieldSize,
            (float)settings.LineWidth,
            0.1f
        );
        centralLine.GetComponent<MeshRenderer>().material.color = settings.LineColor;

        // Threshold линии
        SetupThresholdLine(thresholdLine1, 0.25f, settings);
        SetupThresholdLine(thresholdLine2, 0.75f, settings);
    }

    private void SetupThresholdLine(Transform t, float heightFactor, Settings settings)
    {
        if (t == null) return;

        // Ширина (высота) линии
        t.localScale = new Vector3(
            (float)settings.FieldSize,
            (float)settings.FarLineWidth,
            0.1f
        );

        // Цвет
        t.GetComponent<MeshRenderer>().material.color = settings.FarLineColor;

        // Позиция по высоте
        t.localPosition = new Vector3(
            0,
            (heightFactor - 0.5f) * (float)settings.FieldSize,
            0
        );
    }
}
