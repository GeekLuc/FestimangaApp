// Rougefort Luca
// 2024
// Project Application Festimanga
// ListeExposantDeroulant.cs
// This script creates a dropdown list for exhibitors based on the selected dropdown option.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.IO;
using System.Xml.Linq;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Liste{
    public string nom, description, position; // Properties for the exhibitor's name, description, and position
    public int identifiant; // Property for the exhibitor's ID
}

public class ListeExposantDeroulant : MonoBehaviour{
    [SerializeField] TMP_Dropdown TMP_Dropdown; // Dropdown for selecting exhibitors
    [SerializeField] TextAsset FichierExposants; // Text file containing exhibitor data
    [SerializeField] Transform parent; // Parent transform for the exhibitor items
    [SerializeField] TMP_Text textPrefab; // Prefab for the exhibitor text item
    List<Liste> elementListe = new List<Liste>(); // List to store the exhibitor items

    void Start(){
        // Read the exhibitor data from the text file and populate the list
        string[] lines = FichierExposants.text.Split('\n');
        foreach (string line in lines){
            string[] parts = line.Split('|');
            if (parts.Length >= 4){ // Ensure there are enough elements in the array
                Liste Elements = new Liste{
                    identifiant = int.Parse(parts[0].Trim()),
                    nom = parts[1].Trim(),
                    description = parts[2].Trim(),
                    position = parts[3].Trim()
                };
                elementListe.Add(Elements);
            }
        }

        // Add listener for dropdown value change
        TMP_Dropdown.onValueChanged.AddListener(delegate { OnDropDownChange(); });
        OnDropDownChange();
    }

    public void OnDropDownChange(){
        int identifiantSelectionne = TMP_Dropdown.value;

        // Clear existing exhibitor items
        foreach (Transform child in parent){
            Destroy(child.gameObject);
        }

        // Instantiate and display new exhibitor items based on the selected dropdown option
        foreach (Liste Elements in elementListe){
            if (identifiantSelectionne == 0 || Elements.identifiant == identifiantSelectionne){
                TMP_Text newText = Instantiate(textPrefab, parent);
                newText.text = Elements.nom + "\n";

                Button button = newText.GetComponent<Button>();
                if (button != null){
                    button.onClick.AddListener(() => OnExposantClick(Elements));
                }
            }
        }
    }

    // Handle exhibitor item click
    public void OnExposantClick(Liste exposant){
        ExposantSelectionne.Nom = exposant.nom;
        ExposantSelectionne.Description = exposant.description;
        ExposantSelectionne.Position = exposant.position;
    }
}


