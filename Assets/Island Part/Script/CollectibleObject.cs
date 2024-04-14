using UnityEngine;
using System.Collections.Generic;


public class CollectibleObject : MonoBehaviour
{
    public int scoreValue = 10;
    public string Description = "";
    public string Name = "";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        // Increment player's score
        IslandGobalVar.L1PlayerScore += scoreValue;

        // Set description and name of the collected object
        IslandGobalVar.Description = Description;
        IslandGobalVar.ItemName = Name;

        // Access the CollectedItemsSO scriptable object directly
        CollectedItemsSO collectedItemsSO = Resources.Load<CollectedItemsSO>("CollectedItems");

        if (collectedItemsSO != null)
        {
            // Add the collected item to the list
            collectedItemsSO.AddItem(Name);

            // Call UpdateInventoryDisplay method of the InventoryDisplay instance to update the inventory display
            List<string> itemList = new List<string> { Name }; // Create a list containing the single item
            InventoryDisplay.instance.UpdateInventoryDisplay(itemList); // Pass the list of the collected item
        }
        else
        {
            Debug.LogError("CollectedItemsSO asset not found. Make sure it exists and is located in a Resources folder.");
        }

        // Destroy the collected object
        Destroy(gameObject);
    }

}