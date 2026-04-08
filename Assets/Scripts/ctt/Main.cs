using CTT;
using SharpDX.DirectInput;
using UnityEngine;

public class CTTMain : MonoBehaviour
{
    public FieldController fieldController;

    void Start()
    {
        _settings = Settings.Instance;
    }

    private void OnDestroy()
    {
        if (_input != null)
        {
            _input.Updated -= Input_Updated;
            _input= null;
        }
        if (_controller != null)
        {
            _controller.Stop();
            _controller = null;
        }
    }

    public void Run()
    {
        if (CreateInput())
        {
            fieldController.SetUp(_settings);

            _controller = new Controller();
            _controller.Start();
        }
    }
    // Internal

    private Controller _controller;
    private CTT.Inputs.Input _input;
    private Settings _settings;

    private bool CreateInput()
    {
        DeviceInstance[] inputDevices;

        inputDevices = CTT.Inputs.Input.ListDevices(_settings.Input);
        if (inputDevices.Length > 0)
        {
            if (_settings.Input == CTT.Inputs.InputType.Mouse)
                _input = new CTT.Inputs.Mouse();
            else if (_settings.Input == CTT.Inputs.InputType.Joystick)
                _input = new CTT.Inputs.Joystick(0);
            else if (_settings.Input == CTT.Inputs.InputType.Keyboard)
                _input = new CTT.Inputs.Keyboard();
        }
        else
        {
            Debug.LogError($"Found no device of type '{_settings.Input}'. Please connect, or choose another input.");
        }

        if (_input != null)
        {
            _input.Updated += Input_Updated;
        }

        return _input != null;
    }

    private void Input_Updated(object sender, Point e)
    {
        _controller.Update(e);
    }
}
