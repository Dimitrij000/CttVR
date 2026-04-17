using UnityEngine;

public class FieldController : MonoBehaviour
{
    public Transform line;
    public Transform centralLine;

    public Transform thresholdLine1;
    public Transform thresholdLine2;

    public void SetUp(Settings settings)
    {
        transform.localScale = new Vector3(
            (float)settings.FieldSize / FieldSizeFactor,
            transform.localScale.y,
            (float)settings.FieldSize / FieldSizeFactor
        );
        transform.GetComponent<MeshRenderer>().material.color = settings.BackgroundColor;

        line.localScale = new Vector3(
            (float)settings.FieldSize,
            (float)settings.LineWidth,
            line.localScale.z
        );
        line.GetComponent<MeshRenderer>().material.color = settings.LineColor;

        centralLine.localScale = new Vector3(
            (float)settings.FieldSize,
            (float)settings.LineWidth,
            centralLine.localScale.z
        );

        SetupThresholdLine(thresholdLine1, 0.5 - settings.FarThreshold / 2);
        SetupThresholdLine(thresholdLine2, 0.5 + settings.FarThreshold / 2);
    }

    // Internal

    const float FieldSizeFactor = 10f;  // some weird factor to convert field size to Unity units

    private void SetupThresholdLine(Transform t, double heightFactor)
    {
        if (t == null) return;

        t.localPosition = new Vector3(
            (float)(heightFactor - 0.5) * FieldSizeFactor,
            0,
            0
        );
    }
}
