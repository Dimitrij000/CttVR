using SharpDX.DirectInput;

namespace CTT.Inputs
{
    class Keyboard : Input
    {
        public override InputType Type => InputType.Keyboard;

        public Keyboard() : base()
        {
            if (_devices == null)
            {
                _devices = ListDevices();
            }

            _keyboard = new SharpDX.DirectInput.Keyboard(_directInput);
            _keyboard.Properties.BufferSize = 128;
            _keyboard.Acquire();

            _stepScale = _settings.KeyboardGain;
        }

        public static DeviceInstance[] ListDevices()
        {
            _devices = ListDevices(InputType.Keyboard);
            return _devices;
        }


        // Internal

        const double SCALE = 1;
        const double DECAY = 0.5;

        static DeviceInstance[] _devices;

        readonly SharpDX.DirectInput.Keyboard _keyboard;
        readonly Settings _settings = Settings.Load();

        double _stepScale = 0.15;

        bool _isDownArrowPressed = false;
        bool _isUpArrowPressed = false;
        bool _isLeftArrowPressed = false;
        bool _isRightArrowPressed = false;

        protected override void Step()
        {
            _keyboard.Poll();
            var datas = _keyboard.GetBufferedData();
            if (datas.Length > 0)
            {
                foreach (var data in datas)
                {
                    if (data.Key == SharpDX.DirectInput.Key.Up)
                        _isUpArrowPressed = data.IsPressed;
                    if (data.Key == SharpDX.DirectInput.Key.Down)
                        _isDownArrowPressed = data.IsPressed;
                    if (data.Key == SharpDX.DirectInput.Key.Left)
                        _isLeftArrowPressed = data.IsPressed;
                    if (data.Key == SharpDX.DirectInput.Key.Right)
                        _isRightArrowPressed = data.IsPressed;
                }
            }

            if (_isLeftArrowPressed || _isRightArrowPressed)
                _x = (_x + (_isLeftArrowPressed ? -_stepScale : 0) + (_isRightArrowPressed ? _stepScale : 0)).ToRange(-SCALE, SCALE);
            else
                _x *= DECAY;

            if (_isDownArrowPressed || _isUpArrowPressed)
                _y = (_y + (_isUpArrowPressed ? -_stepScale : 0) + (_isDownArrowPressed ? _stepScale : 0)).ToRange(-SCALE, SCALE);
            else
                _y *= DECAY;
        }
    }
}