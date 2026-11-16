using UnityEngine;
using TMPro; // Добавляем для вывода текста на экран

public enum RoleType
{
    Crasher, // Вредитель
    Rescuer  // Спасатель
}

public class PlayerRole : MonoBehaviour
{
    public RoleType currentRole;

    [Header("UI для показа роли")]
    public TextMeshProUGUI roleText; // Сюда перетащим текст роли на экране

    void Start()
    {
        // Генерируем случайное число от 0 до 1 (0 или 1)
        int randomRole = Random.Range(0, 2);

        if (randomRole == 0)
        {
            currentRole = RoleType.Crasher;
            if (roleText != null) roleText.text = "ТЫ: ВРЕДИТЕЛЬ (Ломай всё!)";
            Debug.Log("Ты - Вредитель");
        }
        else
        {
            currentRole = RoleType.Rescuer;
            if (roleText != null) roleText.text = "ТЫ: СПАСАТЕЛЬ (Чини всё!)";
            Debug.Log("Ты - Спасатель");
        }
    }

    void Update()
    {
        // Оставляем кнопки 1 и 2 для тестов, но в будущем их уберем
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentRole = RoleType.Crasher;
            if (roleText != null) roleText.text = "ТЕСТ: ВРЕДИТЕЛЬ";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentRole = RoleType.Rescuer;
            if (roleText != null) roleText.text = "ТЕСТ: СПАСАТЕЛЬ";
        }
    }
}