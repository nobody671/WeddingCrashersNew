using UnityEngine;

// Создаем два возможных состояния
public enum RoleType
{
    Crasher, // Вредитель
    Rescuer  // Спасатель
}

public class PlayerRole : MonoBehaviour
{
    public RoleType currentRole = RoleType.Crasher; // По умолчанию мы Вредитель

    void Update()
    {
        // Тестовая кнопка 1 - стать Вредителем
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentRole = RoleType.Crasher;
            Debug.Log("Я - ВРЕДИТЕЛЬ (ломаю)");
        }
        // Тестовая кнопка 2 - стать Спасателем
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentRole = RoleType.Rescuer;
            Debug.Log("Я - СПАСАТЕЛЬ (чиню)");
        }
    }
}