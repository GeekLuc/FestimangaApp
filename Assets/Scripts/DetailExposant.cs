// Rougefort Luca
// 2024
// Project Application Festimanga
// DetailExposant.cs
// This script handles the display of selected exhibitor details in the Festimanga application.

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetailExposant : MonoBehaviour{
    [SerializeField] TMP_Text prefabNom; // Prefab for the exhibitor's name
    [SerializeField] TMP_Text prefabDescription; // Prefab for the exhibitor's description
    [SerializeField] TMP_Text prefabEmplacement; // Prefab for the exhibitor's location
    [SerializeField] Transform parentNom; // Parent transform for the name prefab
    [SerializeField] Transform parentDescription; // Parent transform for the description prefab
    [SerializeField] Transform parentEmplacement; // Parent transform for the location prefab

    void Start(){
        try{
            // Check if the prefabs and parents are assigned
            if (prefabNom == null || prefabDescription == null || prefabEmplacement == null || parentNom == null || parentDescription == null || parentEmplacement == null){
                Debug.LogError("One or more prefabs or parents are not assigned in the inspector.");
                return;
            }

            // Instantiate the prefabs and set them as children of the parent objects
            TMP_Text Nom = Instantiate(prefabNom, parentNom);
            TMP_Text description = Instantiate(prefabDescription, parentDescription);
            TMP_Text emplacement = Instantiate(prefabEmplacement, parentEmplacement);

            // Retrieve the selected exhibitor's information
            string nomExposant = ExposantSelectionne.Nom;
            string descriptionExposant = ExposantSelectionne.Description;
            string emplacementExposant = ExposantSelectionne.Position;

            Debug.Log("Selected exhibitor: " + nomExposant);
            Debug.Log("Selected exhibitor: " + descriptionExposant);
            Debug.Log("Selected exhibitor: " + emplacementExposant);

            // Update the text of the prefabs with the exhibitor's information
            Nom.text = nomExposant;
            description.text = descriptionExposant;
            emplacement.text = emplacementExposant;
        }catch (Exception ex){
            Debug.LogError("Error initializing exhibitor details: " + ex.Message);
        }
    }
}

