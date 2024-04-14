using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CollectedItems", menuName = "ScriptableObjects/CollectedItems")]
public class CollectedItemsSO : ScriptableObject
{
    public List<string> collectedItems = new List<string>(); // Initialize the list to avoid null reference
    public int playerScore = 0; // Initialize player score to 0

    // Method to add a new item to the collected items list
    public void AddItem(string itemName)
    {
        Debug.Log("Adding item: " + itemName);
        collectedItems.Add(itemName); // Add the item to the list
    }

    // Method to remove an item from the collected items list
    public void RemoveItem(string itemName)
    {
        Debug.Log("Removing item: " + itemName);
        collectedItems.Remove(itemName); // Remove the item from the list
    }

    // Method to reset the collected items list and player score
    public void ResetCollectedItems()
    {
        Debug.Log("Resetting collected items and player score.");
        collectedItems.Clear(); // Clear the list
        playerScore = 0; // Reset player score
    }

    // Method to update the player's score
    public void UpdatePlayerScore(int newScore)
    {
        Debug.Log("Updating player score: " + newScore);
        playerScore = newScore;
    }
}
