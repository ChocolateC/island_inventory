using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager instance;
    public static InventoryManager Instance { get { return instance; } }

    public CollectedItemsSO collectedItemsSO;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Method to update the player's score and invoke the UpdateScoreText method
    public void UpdatePlayerScoreAndDisplay(int newScore)
    {
        collectedItemsSO.UpdatePlayerScore(newScore);
        InventoryDisplay.instance.UpdateScoreText(newScore);
        Debug.Log("Player score updated to: " + newScore); // Debug log to check if the method is being called
    }
}
