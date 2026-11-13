using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Материалы для замены")]
    public Material normalMat; // Сюда перетащим GreenMat (целый)
    public Material brokenMat; // Сюда перетащим RedMat (сломанный)
    public float scoreImpact = 10f; // На сколько изменится шкала

    private bool isBroken = false;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        UpdateVisuals();
    }

    public void Interact(RoleType playerRole)
    {
        if (playerRole == RoleType.Crasher) // Вредитель
        {
            if (!isBroken)
            {
                isBroken = true;
                Debug.Log(gameObject.name + " СЛОМАН!");
                UpdateVisuals();

                // ДОБАВЛЕНО: Отнимаем очки
                if (MatchManager.Instance != null)
                    MatchManager.Instance.ChangeScore(-scoreImpact);
            }
            else
            {
                Debug.Log("Тут уже всё сломано!");
            }
        }
        else if (playerRole == RoleType.Rescuer) // Спасатель
        {
            if (isBroken)
            {
                isBroken = false;
                Debug.Log(gameObject.name + " ПОЧИНЕН!");
                UpdateVisuals();
                if (MatchManager.Instance != null)
                    MatchManager.Instance.ChangeScore(scoreImpact);
            }
            else
            {
                Debug.Log("Тут и так всё в порядке!");
            }
        }
    }

    private void UpdateVisuals()
    {
        if (meshRenderer != null)
        {
            // Теперь мы не перекрашиваем, а полностью меняем материал
            if (isBroken)
            {
                meshRenderer.material = brokenMat;
            }
            else
            {
                meshRenderer.material = normalMat;
            }
        }
    }
}