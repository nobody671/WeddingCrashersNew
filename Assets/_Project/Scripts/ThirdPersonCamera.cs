using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Сюда мы перетащим нашу капсулу
    public float distance = 5.0f; // Расстояние от камеры до игрока
    public float sensitivity = 3.0f; // Чувствительность мыши
    public float minY = -20f; // Максимальный угол наклона вниз
    public float maxY = 60f;  // Максимальный угол наклона вверх

    private float rotationX = 0f;
    private float rotationY = 0f;

    void LateUpdate() // LateUpdate используется для камер, чтобы они не дергались
    {
        if (!target) return; // Если цель не задана, ничего не делаем

        // Получаем движение мыши
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, minY, maxY); // Ограничиваем, чтобы камера не перевернулась

        // Вычисляем поворот камеры
        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);

        // Вычисляем позицию камеры (немного приподнимаем её над центром капсулы)
        Vector3 position = target.position - (rotation * Vector3.forward * distance) + (Vector3.up * 1.5f);

        // Применяем позицию и поворот
        transform.rotation = rotation;
        transform.position = position;

        // ОЧЕНЬ ВАЖНО: Поворачиваем самого игрока туда же, куда смотрит камера (по горизонтали)
        target.rotation = Quaternion.Euler(0, rotationX, 0);
    }
}