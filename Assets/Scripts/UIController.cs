using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject overlayPanel;
    public Dropdown inputDropdown;
    public Dropdown orientationDropdown;

    public CTTMain CttApp;

    private Settings _settings;

    void Start()
    {
        _settings = Settings.Instance;

        inputDropdown.value = (int)_settings.Input;
        inputDropdown.onValueChanged.AddListener(OnInputChanged);

        orientationDropdown.value = (int)_settings.Orientation;
        orientationDropdown.onValueChanged.AddListener(OnOrientationChanged);
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

        CttApp.Run();
    }
}
