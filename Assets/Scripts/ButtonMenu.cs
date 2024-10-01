// Rougefort Luca
// 2024
// Project Application Festimanga
// ButtonMenu.cs
// This script allows loading a scene when the button is clicked.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour{
    public string sceneToLoad; // The name of the scene to load

    // This method is called when the button is clicked
    public void OnButtonClick(){
        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
