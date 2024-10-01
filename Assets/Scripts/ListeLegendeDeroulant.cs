// Rougefort Luca
// 2024
// Project Application Festimanga
// ListeLegendeDeroulant.cs
// This script creates a dropdown list for exhibitors based on the selected dropdown option.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Exposant{
    public string categorie; // Property for the exhibitor's category
    public string identifiant; // Property for the exhibitor's ID
    public string nom; // Property for the exhibitor's name
}

public class ListeLegendeDeroulant : MonoBehaviour{
    [SerializeField] TMP_Dropdown exposantDropdown; // Dropdown for selecting exhibitors
    [SerializeField] TextAsset fichierExposants; // Text file containing exhibitor data
    [SerializeField] Transform parentTransform; // Parent transform for the exhibitor items
    [SerializeField] TMP_Text exposantTextPrefab; // Prefab for the exhibitor text item
    List<Exposant> exposantListe = new List<Exposant>(); // List to store the exhibitor items

    void Start(){
        // Read the exhibitor data from the text file and populate the list
        LireFichierExposants();
        // Add listener for dropdown value change
        exposantDropdown.onValueChanged.AddListener(delegate { OnExposantDropDownChange(); });
        OnExposantDropDownChange();
    }

    void LireFichierExposants(){
        string[] lines = fichierExposants.text.Split('\n');
        foreach (string line in lines){
            string[] parts = line.Split('|');
            if (parts.Length >= 3){ // Ensure there are enough elements in the array
                Exposant exposant = new Exposant{
                    categorie = parts[0].Trim(),
                    identifiant = parts[1].Trim(),
                    nom = parts[2].Trim()
                };
                exposantListe.Add(exposant);
            }
        }
    }

    public void OnExposantDropDownChange(){
        int identifiantSelectionne = exposantDropdown.value;

        // Clear existing exhibitor items
        foreach (Transform child in parentTransform){
            Destroy(child.gameObject);
        }

        // Instantiate and display new exhibitor items based on the selected dropdown option
        foreach (Exposant exposant in exposantListe){
            if (int.TryParse(exposant.categorie, out int categorieInt)){
                if (identifiantSelectionne == 0 || categorieInt == identifiantSelectionne){
                    TMP_Text newText = Instantiate(exposantTextPrefab, parentTransform);
                    newText.text = $"{exposant.identifiant}. {exposant.nom}\n";
                }
            }
        }
    }
}


