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

    private static string FilePath =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "ctt_settings.json");

    public static Settings Load()
    {
        if (!File.Exists(FilePath))
        {
            return new Settings
            {
                LineColor = Color.white,
                FarLineColor = Color.gray,
                BackgroundColor = Color.black,

                LineWidth = 2,
                FarLineWidth = 1,
                FarThreshold = 0.5,
                FieldSize = 10,
                Lambdas = new double[] { 1, 2, 3 },

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
}
