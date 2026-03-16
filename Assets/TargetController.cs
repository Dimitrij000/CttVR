using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float speed = 0.0f;     // текущая скорость цели
    public float lambda = 1.0f;    // коэффициент ускорения
    public float maxSpeed = 5.0f;  // ограничение скорости

    private float position = 0.0f; // внутренняя позиция цели

    void Start()
    {
        var s = Settings.Load();

        // Берём первую лямбду из массива
        if (s.Lambdas != null && s.Lambdas.Length > 0)
            lambda = (float)s.Lambdas[0];

        maxSpeed = (float)s.FieldSize; // чтобы цель не улетала слишком далеко
    }

    void Update()
    {
        // Уравнение CTT:
        // скорость += lambda * ошибка * deltaTime
        // но пока ошибки нет — делаем простое движение

        speed += lambda * Time.deltaTime;

        // ограничиваем скорость
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);

        // обновляем позицию
        position += speed * Time.deltaTime;

        // перемещаем объект по оси X
        transform.localPosition = new Vector3(position, transform.localPosition.y, transform.localPosition.z);
    }
}
