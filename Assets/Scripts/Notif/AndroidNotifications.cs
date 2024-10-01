// Rougefort Luca
// 2024
// Project Application Festimanga
// AndroidNotifications.cs
// This script handles Android notifications for the Festimanga application.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

public class AndroidNotifications : MonoBehaviour{
#if UNITY_ANDROID
    private AudioSource audioSource;

    void Awake(){
        // Initialize the audio source and load the notification sound
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("notification_sound");
    }

    // Request permission for notifications
    public void RequestAuthorization(){
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS")){
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    // Register a notification channel
    public void RegisterNotificationChannel(){
        var channel = new AndroidNotificationChannel(){
            Id = "default_channel",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    // Set up and send a notification
    public void SendNotification(string title, string text, DateTime fireTime){
        var notification = new AndroidNotification{
            Title = title,
            Text = text,
            FireTime = fireTime,
            SmallIcon = "icon_0"
        };

        AndroidNotificationCenter.SendNotification(notification, "default_channel");

        // Play the notification sound
        PlayNotificationSound();
    }

    // Play the notification sound
    private void PlayNotificationSound(){
        if (audioSource != null && audioSource.clip != null){
            audioSource.Play();
        }
    }
#endif
}

