using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class ResetCollectedItemsOnPlayModeEnter : MonoBehaviour
{
    static ResetCollectedItemsOnPlayModeEnter()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            // Find the CollectedItemsSO asset
            CollectedItemsSO collectedItemsSO = Resources.Load<CollectedItemsSO>("CollectedItems");
            if (collectedItemsSO != null)
            {
                // Reset collected items
                collectedItemsSO.ResetCollectedItems();
                // Reset player's score
                collectedItemsSO.UpdatePlayerScore(0);
                // Mark the asset as dirty to save changes
                EditorUtility.SetDirty(collectedItemsSO);
                // Save the asset database
                AssetDatabase.SaveAssets();
                // Refresh the asset database to reflect changes
                AssetDatabase.Refresh();
                Debug.Log("Collected items and player score reset on entering play mode.");
            }
            else
            {
                Debug.LogError("CollectedItemsSO asset not found. Make sure it exists and is located in a Resources folder.");
            }
        }
    }
}
