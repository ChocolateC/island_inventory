using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class InventoryDisplay : MonoBehaviour
{
    public static InventoryDisplay instance; // Singleton instance
    public TextMeshProUGUI scoreText; // Text to display player score
    public TextMeshProUGUI itemText; // Text to display collected items

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mark the root GameObject as DontDestroyOnLoad
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update the player score text
    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score.ToString(); // Update the player score text
        Debug.Log("Score text updated to: " + score); // Debug log to check if the score is being updated
    }

    // Update the inventory display with a list of item names
    public void UpdateInventoryDisplay(List<string> itemNames)
    {
        itemText.text = ""; // Clear the current text

        // Group the item names by their occurrences
        var groupedItems = itemNames.GroupBy(x => x);

        // Iterate through each group and display the item name with its count
        foreach (var group in groupedItems)
        {
            string itemName = group.Key;
            int itemCount = group.Count();
            itemText.text += $"{itemName} x{itemCount}\n"; // Add each item name with count to the text
        }
    }
}
