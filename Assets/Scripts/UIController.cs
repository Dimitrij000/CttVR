using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject overlayPanel;
    public Dropdown inputDropdown;
    public Dropdown orientationDropdown;
    public Toggle isProperTrackingTimerVisible;
    public InputField lineWidth;

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
        isProperTrackingTimerVisible.isOn = _settings.IsProperTrackingTimerVisible;
        isTrackingTimerVisible.isOn = _settings.isTrackingTimerVisible;
        isOldCTTBugEnabled.isOn = _settings.isOldCTTBugEnabled;
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
        _settings.IsProperTrackingTimerVisible = isProperTrackingTimerVisible.isOn;
        _settings.IsTrackingTimerVisible = isTrackingTimerVisible.isOn;
        _settings.IsOldCTTBugEnabled = isOldCTTBugEnabled.isOn;


        CttApp.Run();
    }
}
