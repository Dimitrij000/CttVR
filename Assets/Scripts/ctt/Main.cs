using SharpDX.DirectInput;
using System;

namespace CTT
{
    public class Main : IDisposable
    {
        public Main()
        {
            _controller = new Controller();
            _controller.ConnectionStatusChanged += Controller_ConnectionStatusChanged;
            _controller.IsRunningChanged += Controller_IsRunningChanged;

            Controller_ConnectionStatusChanged(null, false);

            if (!CreateInput())
            {
                _settings.Input = Inputs.Input.GetFirstExistingType();
                _settings.Save();
            }
        }

        public void Dispose()
        {
            _controller.Stop();
            _settings.Save();

            Logger.Instance.Save();
        }

        // Internal

        readonly Settings _settings = Settings.Load();
        readonly Controller _controller;

        Inputs.Input _input = null;

        private bool CreateInput()
        {
            DeviceInstance[] inputDevices;

            inputDevices = Inputs.Input.ListDevices(_settings.Input);
            if (inputDevices.Length > 0)
            {
                if (_settings.Input == Inputs.InputType.Mouse)
                    _input = new Inputs.Mouse();
                else if (_settings.Input == Inputs.InputType.Joystick)
                    _input = new Inputs.Joystick(0);
                else if (_settings.Input == Inputs.InputType.Keyboard)
                    _input = new Inputs.Keyboard();
            }
            else
            {
                Console.WriteLine($"Found no device of type '{_settings.Input}'. Please connect, or choose another input.");
            }

            if (_input != null)
            {
                _input.Updated += Input_Updated;
            }

            return _input != null;
        }

        private void Controller_ConnectionStatusChanged(object sender, bool isConnected)
        {
            if (_controller.IsServerReady)
            {
                // imgTcpClient.Source = isConnected ? _tcpOnImage : _tcpOffImage;
            }
        }

        private void Controller_IsRunningChanged(object sender, bool isRunning)
        {
            // imgTcpClient.Visibility = isRunning ? Visibility.Hidden : Visibility.Visible;
            if (isRunning)
            {
                //Activate();
            }
            else
            {
                Logger.Instance.Save();
            }
        }

        private void Input_Updated(object sender, Point e)
        {
            _controller.Update(e);
        }
    }
}