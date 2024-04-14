using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float countdownDuration = 180f;
    public TMP_Text scoreText;
    public TMP_Text targetScoreText;
    public TMP_Text timerText;
    public GameObject timerAndManagerCanvas; // Reference to TimerAndManager canvas
    public GameObject inventoryCanvas; // Reference to InventoryCanvas
    public TMP_Text BackgroundText;
    public TMP_Text subtitleText;
    public float ItemSubtitleDisplayTime = 5f;
    public float BackgroundSubtitleDisplayTime = 5f;

    private float startTime;
    private bool gameOver = false;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Activate TimerAndManager canvas and deactivate InventoryCanvas at the start
        timerAndManagerCanvas.SetActive(true);
        inventoryCanvas.SetActive(false);

        subtitleText.gameObject.SetActive(false);
        startTime = Time.time;
        TargetScoreText();
        UpdateScoreText();
        BackgroundText.gameObject.SetActive(true);
        Invoke("DeactivateBackgroundText", 5);
    }

    private void Update()
    {
        if (!gameOver)
        {
            float elapsedTime = Time.time - startTime;
            float remainingTime = countdownDuration - elapsedTime;

            int minutes = Mathf.FloorToInt(remainingTime / 60f);
            int seconds = Mathf.FloorToInt(remainingTime % 60f);
            timerText.text = "Remaining\n" + string.Format("{0:00}:{1:00}", minutes, seconds);
            UpdateScoreText();

            if (remainingTime <= 0f || IslandGobalVar.L1PlayerScore >= IslandGobalVar.L1AimScore)
            {
                // Time is up or player score equals target score
                GameOver();
            }
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score\n" + IslandGobalVar.L1PlayerScore.ToString();
    }

    private void TargetScoreText()
    {
        targetScoreText.text = "Target\n" + IslandGobalVar.L1AimScore.ToString();
    }

    public void CollectedScript()
    {
        // Update the collected items and player score
        CollectedItemsSO collectedItemsSO = Resources.Load<CollectedItemsSO>("CollectedItems");
        if (collectedItemsSO != null)
        {
            collectedItemsSO.AddItem(IslandGobalVar.ItemName);
            collectedItemsSO.UpdatePlayerScore(IslandGobalVar.L1PlayerScore);

            // Update the player's score text display
            UpdateScoreText();
        }
        else
        {
            Debug.LogError("CollectedItemsSO asset not found. Make sure it exists and is located in a Resources folder.");
        }

        // Update the UI
        HideSubtitle();
    }

    private void HideSubtitle()
    {
        subtitleText.gameObject.SetActive(false);
    }

    private void DeactivateBackgroundText()
    {
        BackgroundText.gameObject.SetActive(false);
    }

    private void GameOver()
    {
        gameOver = true;

        // Disable TimerAndManager canvas
        timerAndManagerCanvas.SetActive(false);
        
        // Enable InventoryCanvas
        inventoryCanvas.SetActive(true);

        // Update the inventory display with all collected items when the game is over
        CollectedItemsSO collectedItemsSO = Resources.Load<CollectedItemsSO>("CollectedItems");
        if (collectedItemsSO != null)
        {
            InventoryDisplay.instance.UpdateInventoryDisplay(collectedItemsSO.collectedItems);
        }
        else
        {
            Debug.LogError("CollectedItemsSO asset not found. Make sure it exists and is located in a Resources folder.");
        }

        // Update the player's score display in the inventory canvas
        InventoryDisplay.instance.UpdateScoreText(IslandGobalVar.L1PlayerScore);
    }

}