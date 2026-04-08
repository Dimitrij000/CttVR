using CTT;
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
            (float)settings.FieldSize / 10f,
            transform.localScale.y,
            (float)settings.FieldSize / 10f
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

        SetupThresholdLine(thresholdLine1, 0.25f, settings);
        SetupThresholdLine(thresholdLine2, 0.75f, settings);
    }

    private void SetupThresholdLine(Transform t, float heightFactor, Settings settings)
    {
        if (t == null) return;

        t.localPosition = new Vector3(
            (heightFactor - 0.5f) * 10,
            0,
            0
        );
    }
}
