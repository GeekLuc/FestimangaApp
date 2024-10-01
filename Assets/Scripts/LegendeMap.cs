// Rougefort Luca
// 2024
// Project Application Festimanga
// LegendeMap.cs
// This script handles the display of the map legend in the Festimanga application.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

[System.Serializable]
public class Legende{
    public string nom, id; // Properties for the legend name and ID
}

public class LegendeMap : MonoBehaviour{
    [SerializeField] TextAsset FichierLegende; // Text file containing the legend data
    [SerializeField] Transform parent; // Parent transform for the legend items
    [SerializeField] TMP_Text PrefabLegende; // Prefab for the legend text item
    List<Legende> legendeListe = new List<Legende>(); // List to store the legend items

    void Start(){
        // Read the legend data from the text file and populate the list
        string[] lines = FichierLegende.text.Split('\n');
        foreach (string line in lines){
            string[] parts = line.Split('|');
            if (parts.Length >= 2){ // Ensure there are enough elements in the array
                Legende legende = new Legende{
                    id = parts[0].Trim(),
                    nom = parts[1].Trim()
                };
                legendeListe.Add(legende);
            }
        }
        // Display the legend items
        AfficherLegende();
    }

    public void AfficherLegende(){
        // Clear existing legend items
        foreach (Transform child in parent){
            Destroy(child.gameObject);
        }

        // Instantiate and display new legend items
        foreach (Legende legende in legendeListe){
            TMP_Text newText = Instantiate(PrefabLegende, parent);
            newText.text = legende.id + " - " + legende.nom + "\n";
        }
    }
}


