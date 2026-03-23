using CTT.Inputs;
using System;
using System.IO;
using UnityEngine;

public enum Orientation
{
    Horizontal = 0,
    Vertical = 1
}

[Serializable]
public class Settings
{
    public Color LineColor;
    public Color FarLineColor;
    public Color BackgroundColor;

    public double LineWidth;
    public double FarLineWidth;
    public double FarThreshold;
    public double FieldSize;
    public double[] Lambdas;

    public InputType Input;
    public Orientation Orientation;

    public double KeyboardGain;
    public double OffsetGain;
    public double InputGain;
    public double NoiseGain;

    public bool IsProperTrackingTimerVisible;
    public int ProperTrackingDurationThreshold;
    public bool IsTrackingTimerVisible;

    public bool IsOldCTTBugEnabled;

    public bool TonePlayer1_IsEnabled;
    public double TonePlayer1_MaxFrequency;
    public int TonePlayer1_SoundsDeviceIndex;
    public int TonePlayer1_ToneType;
    public int TonePlayer1_PulseDuration;

    public bool TonePlayer2_IsEnabled;
    public double TonePlayer2_MaxFrequency;
    public int TonePlayer2_SoundsDeviceIndex;
    public int TonePlayer2_ToneType;
    public int TonePlayer2_PulseDuration;

    public string LogFolder;

    public static Settings Instance => _settings ??= Load();

    public static Settings Load()
    {
        if (!File.Exists(FilePath))
        {
            return new Settings
            {
                LineColor = Color.white,
                FarLineColor = Color.gray,
                BackgroundColor = Color.black,

                LineWidth = 0.02,
                FarLineWidth = 0.1,
                FarThreshold = 0.5,
                FieldSize = 1,
                Lambdas = new double[] { 0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5 },

                Input = InputType.Mouse,
                Orientation = Orientation.Horizontal,

                KeyboardGain = 1,
                OffsetGain = 0.01,
                InputGain = 0.11,
                NoiseGain = 0.00001,

                ProperTrackingDurationThreshold = 30,

                LogFolder = Application.persistentDataPath
            };
        }

        string json = File.ReadAllText(FilePath);
        return JsonUtility.FromJson<Settings>(json);
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(this, true);
        File.WriteAllText(FilePath, json);
    }

    // Inernal

    private static string FilePath =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "ctt_settings.json");

    private static Settings _settings;
}
