using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            // Берем позицию и направление взгляда ГЛАВНОЙ камеры
            Vector3 rayOrigin = Camera.main.transform.position;
            Vector3 rayDirection = Camera.main.transform.forward;

            // Пускаем луч из камеры
            if (Physics.Raycast(rayOrigin, rayDirection, out hit, interactDistance))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    interactable.Interact();
                }
                else
                {
                    Debug.Log("Попали в: " + hit.collider.name + ". Но там нет скрипта Interactable.");
                }
            }
            else
            {
                Debug.Log("Луч улетел в пустоту.");
            }
        }
    }

    void OnDrawGizmos()
    {
        // Проверяем, есть ли камера на сцене
        if (Camera.main != null)
        {
            Gizmos.color = Color.green;
            // Рисуем луч из камеры, чтобы видеть, куда он летит
            Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * interactDistance);
        }
    }
}