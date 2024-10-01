// Rougefort Luca
// 2024
// Project Application Festimanga
// NotificationsControler.cs
// This script handles the scheduling and sending of notifications for the Festimanga application.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

public class NotificationsControler : MonoBehaviour{
    [SerializeField] AndroidNotifications androidNotifications;
    [SerializeField] TextAsset planningFile;

    void Start(){
        // Request authorization and register notification channels based on the platform
#if UNITY_ANDROID
        androidNotifications.RequestAuthorization();
        androidNotifications.RegisterNotificationChannel();
#endif
        // Start the coroutine to check the planning file periodically
        StartCoroutine(CheckPlanning());
    }

    private IEnumerator CheckPlanning(){
        while (true){
            // Check and send notifications based on the planning file
            CheckAndSendNotifications();
            yield return new WaitForSeconds(60); // Check every minute
        }
    }

    private void CheckAndSendNotifications(){
        string[] lines = planningFile.text.Split('\n');
        DateTime now = DateTime.Now;

        foreach (string line in lines){
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split('|');
            if (parts.Length != 5) continue; // Ensure there are 5 parts

            string dateString = parts[0].Trim();
            string timeString = parts[1].Trim();
            string activityName = parts[2].Trim();
            string location = parts[3].Trim();
            string notificationMessage = parts[4].Trim(); // Get the notification message

            DateTime activityTime;
            if (DateTime.TryParseExact($"{dateString} {timeString}", "dd/MM/yyyy HH'h'mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out activityTime)){
                Debug.Log($"Checking activity: {activityName} at {activityTime}");
                if (now >= activityTime.AddMinutes(-5) && now < activityTime){
                    Debug.Log($"Sending notification for: {activityName}");
#if UNITY_ANDROID
                    androidNotifications.SendNotification("Festimanga", notificationMessage, activityTime);
#endif
                }
            }
        }
    }
}
