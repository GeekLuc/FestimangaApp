// Rougefort Luca
// 2024
// Project Application Festimanga
// ListeFAQ.cs
// This script handles the display of the FAQ list in the Festimanga application.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.IO;
using System.Xml.Linq;

[System.Serializable]
public class FAQ{
    public string txt; // Property for the FAQ text
    public string type; // Property for the FAQ type (Question or Answer)
}

public class ListeFAQ : MonoBehaviour{
    [SerializeField] TextAsset FichierFAQ; // Text file containing the FAQ data
    [SerializeField] Transform parent; // Parent transform for the FAQ items
    [SerializeField] TMP_Text PrefabQuestion, PrefabReponse; // Prefabs for the question and answer text items
    List<FAQ> faqListe = new List<FAQ>(); // List to store the FAQ items

    void Start(){
        // Read the FAQ data from the text file and populate the list
        string[] lines = FichierFAQ.text.Split('\n');
        foreach (string line in lines){
            string[] parts = line.Split('|');
            if (parts.Length >= 2){ // Ensure there are enough elements in the array
                FAQ faq = new FAQ{
                    type = parts[0].Trim(),
                    txt = parts[1].Trim()
                };
                faqListe.Add(faq);
            }
        }
        // Display the FAQ items
        AfficherFAQ();
    }

    public void AfficherFAQ(){
        // Clear existing FAQ items
        foreach (Transform child in parent){
            Destroy(child.gameObject);
        }

        // Instantiate and display new FAQ items
        foreach (FAQ faq in faqListe){
            if (faq.type == "Q"){
                TMP_Text newText = Instantiate(PrefabQuestion, parent);
                newText.text = faq.txt + "\n";
            }else if (faq.type == "R"){
                TMP_Text newText = Instantiate(PrefabReponse, parent);
                newText.text = faq.txt + "\n";
            }
        }
    }
}


