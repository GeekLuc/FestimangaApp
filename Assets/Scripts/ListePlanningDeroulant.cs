// Rougefort Luca
// 2024
// Project Application Festimanga
// ListePlanningDeroulant.cs
// This script changes the planning image based on the selected dropdown option.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.IO;
using System.Xml.Linq;
using UnityEngine.SceneManagement;

public class ListePlanningDeroulant : MonoBehaviour{
    [SerializeField] TMP_Dropdown TMP_Dropdown; // Dropdown for selecting the planning option
    [SerializeField] Sprite[] sprites; // Array of sprites for different planning options
    [SerializeField] Image imageDisplay; // UI Image to display the selected sprite

    void Start(){
        // Add listener for dropdown value change
        TMP_Dropdown.onValueChanged.AddListener(delegate { OnDropDownChange(); });
        OnDropDownChange();
    }

    public void OnDropDownChange(){
        int identifiantSelectionne = TMP_Dropdown.value;

        // Check if the selected identifier is valid
        if (identifiantSelectionne >= 0 && identifiantSelectionne < sprites.Length){
            imageDisplay.sprite = sprites[identifiantSelectionne];
            imageDisplay.gameObject.SetActive(true);
        }else{
            imageDisplay.gameObject.SetActive(false);
        }
    }
}



