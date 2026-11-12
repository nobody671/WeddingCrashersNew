using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        // Получаем доступ к компоненту CharacterController
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 1. Получаем нажатия клавиш (WASD или стрелочки)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 2. Создаем направление движения
        Vector3 move = transform.right * x + transform.forward * z;

        // 3. Двигаем персонажа
        controller.Move(move * speed * Time.deltaTime);

        // 4. Применяем гравитацию (чтобы он прилипал к полу)
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}