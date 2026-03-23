using UnityEngine;

namespace CTT
{
    public class Controller
    {
        private float _offset = 0f;
        private float _noisePhase = 0f;
        private bool _isRunning = false;

        public void Start()
        {
            _isRunning = true;
            Reset();
        }

        public void Update(Vector2 input)
        {
            if (!_isRunning)
                return;

            _noisePhase += 0.08f;
            float noise =
                (Mathf.Cos(_noisePhase) * 2 - 1) +
                (Mathf.Cos(_noisePhase * 2) * 2 - 1) / 2;

            float speed =
                (_offset * 0.1f +
                 input.x * 1.0f +
                 noise * 0.1f)
                 * 0.5f;

            _offset = Mathf.Clamp(_offset + speed, -1f, 1f);

            LineMover.Instance?.SetLinePosition(_offset);
        }

        private void Reset()
        {
            _offset = 0f;
            _noisePhase = Random.value;

            LineMover.Instance?.SetLinePosition(0);
        }
    }
}
