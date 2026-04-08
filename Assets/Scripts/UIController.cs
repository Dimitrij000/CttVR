using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject overlayPanel;
    public Dropdown inputDropdown;
    public Dropdown orientationDropdown;
    public Toggle isProperTrackingTimerVisible;
    public Toggle isTrackingTimerVisible;
    public Toggle isOldCTTBugEnabled;
    public InputField lineWidth;
    public InputField farLineWidth;
    public InputField farThreshold;
    public InputField fieldSize;
    public InputField keyboardGain;
    public InputField offsetGain;
    public InputField inputGain;
    public InputField noiseGain;
    public InputField properTrackingDurationThreshold;
    public InputField lambdas;

    // Цвета в формате R,G,B
    public InputField lineColor;
    public InputField farLineColor;
    public InputField backgroundColor;

    public CTTMain CttApp;

    private Settings _settings;

    void Start()
    {
        _settings = Settings.Instance;

        inputDropdown.value = (int)_settings.Input;
        inputDropdown.onValueChanged.AddListener(OnInputChanged);

        orientationDropdown.value = (int)_settings.Orientation;
        orientationDropdown.onValueChanged.AddListener(OnOrientationChanged);

        lineWidth.text = _settings.LineWidth.ToString();
        farLineWidth.text = _settings.FarLineWidth.ToString();
        farThreshold.text = _settings.FarThreshold.ToString();
        fieldSize.text = _settings.FieldSize.ToString();
        keyboardGain.text = _settings.KeyboardGain.ToString();
        offsetGain.text = _settings.OffsetGain.ToString();
        inputGain.text = _settings.InputGain.ToString();
        noiseGain.text = _settings.NoiseGain.ToString();
        properTrackingDurationThreshold.text = _settings.ProperTrackingDurationThreshold.ToString();
        lambdas.text = string.Join(" ", _settings.Lambdas);

        // Загружаем цвета в формате R,G,B
        lineColor.text = ColorToString(_settings.LineColor);
        farLineColor.text = ColorToString(_settings.FarLineColor);
        backgroundColor.text = ColorToString(_settings.BackgroundColor);

        isProperTrackingTimerVisible.isOn = _settings.IsProperTrackingTimerVisible;
        isTrackingTimerVisible.isOn = _settings.IsTrackingTimerVisible;
        isOldCTTBugEnabled.isOn = _settings.IsOldCTTBugEnabled;
    }

    void OnInputChanged(int value)
    {
        _settings.Input = (CTT.Inputs.InputType)value;
        _settings.Save();
    }

    void OnOrientationChanged(int value)
    {
        _settings.Orientation = (Orientation)value;
        _settings.Save();
    }

    public void OnStartPressed()
    {
        overlayPanel.SetActive(false);

        _settings.LineWidth = double.Parse(lineWidth.text);
        _settings.FarLineWidth = double.Parse(farLineWidth.text);
        _settings.FarThreshold = double.Parse(farThreshold.text);
        _settings.FieldSize = double.Parse(fieldSize.text);
        _settings.KeyboardGain = double.Parse(keyboardGain.text);
        _settings.OffsetGain = double.Parse(offsetGain.text);
        _settings.InputGain = double.Parse(inputGain.text);
        _settings.NoiseGain = double.Parse(noiseGain.text);
        _settings.ProperTrackingDurationThreshold = int.Parse(properTrackingDurationThreshold.text);
        _settings.Lambdas = lambdas.text.Split(" ").Select(v => double.Parse(v)).ToArray();

        // Парсим цвета
        _settings.LineColor = ParseColor(lineColor.text);
        _settings.FarLineColor = ParseColor(farLineColor.text);
        _settings.BackgroundColor = ParseColor(backgroundColor.text);

        _settings.IsProperTrackingTimerVisible = isProperTrackingTimerVisible.isOn;
        _settings.IsTrackingTimerVisible = isTrackingTimerVisible.isOn;
        _settings.IsOldCTTBugEnabled = isOldCTTBugEnabled.isOn;

        _settings.Save();

        CttApp.Run();
    }

    // -----------------------------
    // Вспомогательные методы
    // -----------------------------

    private Color ParseColor(string text)
    {
        // Формат: "R,G,B"
        var parts = text.Split(',');
        if (parts.Length != 3)
            return Color.white;

        float r = float.Parse(parts[0]) / 255f;
        float g = float.Parse(parts[1]) / 255f;
        float b = float.Parse(parts[2]) / 255f;

        return new Color(r, g, b);
    }

    private string ColorToString(Color c)
    {
        int r = Mathf.RoundToInt(c.r * 255f);
        int g = Mathf.RoundToInt(c.g * 255f);
        int b = Mathf.RoundToInt(c.b * 255f);

        return $"{r},{g},{b}";
    }
}
