using UnityEngine;

public class GameController : MonoBehaviour
{
    private Settings settings;

    void Start()
    {
        settings = Settings.Load();

        // Меняем что-нибудь
        settings.FieldSize = 123.45;
        settings.LineWidth = 9.99;
        settings.Lambdas = new double[] { 1, 2, 3 };

        // Сохраняем
        settings.Save();

        Debug.Log("Saved!");
    }
}
