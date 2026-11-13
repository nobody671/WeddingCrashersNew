using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Нужно для перезапуска сцены

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance;

    [Header("Настройки матча")]
    public float matchDuration = 300f;
    public float currentTime;
    public float weddingSuccess = 100f;

    [Header("UI Элементы")]
    public TextMeshProUGUI timerText;
    public Slider successBar;

    [Header("Экран результатов")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI resultText;

    public bool isGameActive = true;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        currentTime = matchDuration;
        UpdateUI();
        // На всякий случай прячем экран результатов при старте
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (!isGameActive) return;

        currentTime -= Time.deltaTime;
        timerText.text = Mathf.Ceil(currentTime).ToString();

        if (currentTime <= 0)
        {
            currentTime = 0;
            EndGame(true); // Время вышло, а шкала не упала в 0 -> Победа Спасателей
        }
    }

    public void ChangeScore(float amount)
    {
        if (!isGameActive) return;

        weddingSuccess += amount;
        weddingSuccess = Mathf.Clamp(weddingSuccess, 0, 100);
        UpdateUI();

        if (weddingSuccess >= 100)
        {
            EndGame(true); // Шкала полная -> Победа Спасателей
        }
        else if (weddingSuccess <= 0)
        {
            EndGame(false); // Шкала на нуле -> Победа Вредителей
        }
    }

    private void UpdateUI()
    {
        if (successBar != null) successBar.value = weddingSuccess;
    }

    private void EndGame(bool rescuersWon)
    {
        isGameActive = false;

        // Включаем экран
        gameOverPanel.SetActive(true);

        // Меняем текст
        if (rescuersWon)
        {
            resultText.text = "<color=green>СВАДЬБА СПАСЕНА!</color>\nПобеда Спасателей";
            Debug.Log("Победа Спасателей!");
        }
        else
        {
            resultText.text = "<color=red>СВАДЬБА ИСПОРЧЕНА!</color>\nПобеда Вредителей";
            Debug.Log("Победа Вредителей!");
        }

        // Разблокируем курсор мыши, чтобы можно было нажать на кнопку
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Этот метод мы привяжем к кнопке
    public void RestartGame()
    {
        // Перезагружаем текущую сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}