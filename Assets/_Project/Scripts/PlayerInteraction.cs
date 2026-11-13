using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Настройки")]
    public float interactDistance = 3f;
    public LayerMask interactLayer;

    private PlayerRole playerRole;
    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main;
        playerRole = GetComponent<PlayerRole>();

        if (playerRole == null) Debug.LogError("ОШИБКА: На капсуле нет скрипта PlayerRole!");
        if (playerCamera == null) Debug.LogError("ОШИБКА: Камера не найдена!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("1. Кнопка Е нажата! Запускаю луч..."); // <--- Проверка ввода
            TryInteract();
        }
    }

    private void TryInteract()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        // Рисуем луч в окне Scene
        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red, 2f);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactLayer))
        {
            Debug.Log("2. Луч попал в объект: " + hit.collider.name); // <--- Луч попал

            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                Debug.Log("3. Найден скрипт Interactable. Передаю роль: " + playerRole.currentRole);
                interactable.Interact(playerRole.currentRole);
            }
            else
            {
                Debug.LogWarning("3 (ОШИБКА). Луч попал, но на объекте нет скрипта Interactable!");
            }
        }
        else
        {
            Debug.LogWarning("2 (ОШИБКА). Луч пролетел мимо! (Не тот слой или слишком далеко)."); // <--- Луч не попал
        }
    }
}