using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isBroken = false;
    public Material brokenMaterial; // Сюда перетащим красный материал
    public Material normalMaterial; // Сюда перетащим синий/зеленый материал

    private Renderer objectRenderer;

    void Start()
    {
        // Получаем компонент Renderer (чтобы менять цвет)
        objectRenderer = GetComponentInChildren<Renderer>();
        if (objectRenderer != null && normalMaterial != null)
        {
            objectRenderer.material = normalMaterial;
        }
    }

    public virtual void Interact()
    {
        // Меняем состояние на противоположное
        isBroken = !isBroken;

        if (isBroken)
        {
            Debug.Log(gameObject.name + " СЛОМАН!");
            if (objectRenderer != null && brokenMaterial != null)
                objectRenderer.material = brokenMaterial;
        }
        else
        {
            Debug.Log(gameObject.name + " ПОЧИНЕН!");
            if (objectRenderer != null && normalMaterial != null)
                objectRenderer.material = normalMaterial;
        }
    }
}