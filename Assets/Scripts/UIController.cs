using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject overlayPanel;
    public Dropdown inputDropdown;
    public Dropdown orientationDropdown;

    private Settings settings;

    void Start()
    {
        settings = Settings.Load();

        // Загружаем значения в UI
        inputDropdown.value = settings.Input;
        orientationDropdown.value = settings.Orientation;

        // Подписываемся на изменения
        inputDropdown.onValueChanged.AddListener(OnInputChanged);
        orientationDropdown.onValueChanged.AddListener(OnOrientationChanged);
    }

    void OnInputChanged(int value)
    {
        settings.Input = value;
        settings.Save();
    }

    void OnOrientationChanged(int value)
    {
        settings.Orientation = value;
        settings.Save();
    }

    public void OnStartPressed()
    {
        overlayPanel.SetActive(false);
    }
}
