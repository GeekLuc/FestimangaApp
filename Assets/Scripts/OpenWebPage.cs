// Rougefort Luca
// 2024
// Project Application Festimanga
// OpenWebPage.cs
// This script opens a specified URL in the web browser.

using UnityEngine;
using TMPro;

public class OpenWebPage : MonoBehaviour{
    [SerializeField] private string url; // URL to be opened

    // Method to open the specified URL
    public void OpenURL(){
        Application.OpenURL(url);
    }
}


