using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Color normalColor = Color.white;
    private Color hoverColor = Color.black;

    private Image buttonImage;

    void Start()
    {
        buttonImage = GetComponent<Image>(); // Get the Image component of the button
        
        if (buttonImage == null)
        {
            Debug.LogError("Image component not found on GameObject: " + gameObject.name);
        }
        else
        {
            buttonImage.color = normalColor; // Set the initial color
        }
    }


    // When the pointer enters the button area
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.color = hoverColor; // Change color to indicate hover
    }

    // When the pointer exits the button area
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.color = normalColor; // Change color back to normal
    }

   public void OnPointerClick(PointerEventData eventData)
{
    Debug.Log("Button Clicked: " + gameObject.name); // Check if the method is called

    // Handle button click event here
    if (gameObject.name == "ExitButton")
    {
        // Call the ExitGame function
        ExitGame();
    }
    else if (gameObject.name == "MenuButton")
    {
        // Load the menu scene by name
        SceneManager.LoadScene("MainMenu"); // Change "NewMenuSceneName" to the actual new menu scene name
    }
}


    // Function to handle the exit button click event
    public void ExitGame()
    {
        Debug.Log("Quitting application...");
        Application.Quit(); // Shutdown the application
    }
}
