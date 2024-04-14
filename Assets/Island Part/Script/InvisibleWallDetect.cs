using UnityEngine;

public class InvisibleWallDetect : MonoBehaviour
{
    public string Description = "You are in Boundary";
    public string itemName = "InvisibleWall"; // Set the default item name for the invisible wall

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Detect();
        }
    }

    private void Detect()
    {
        IslandGobalVar.Description = Description;
        IslandGobalVar.ItemName = itemName; // Set the item name before calling CollectedScript
        GameManager.Instance.CollectedScript();
    }
}
