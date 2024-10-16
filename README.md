# FestimangaApp
Unity project of an application for an event of a "Festimanga" convention created voluntarily

https://play.google.com/store/apps/details?id=com.GeekLuc.Festimanga

# Luca Rougefort / GeekLuc
## Etudiant B3JV programmation de jeux vidéo HEAJ

## **Application mobile pour le Festimanga**
    - Description : Il s'agit d'une application mobile pour Android basique pour l'évenement Festimanga. 
    - Technologies : C#, Unity

## Contact
- **GitHub** : [GeekLuc](https://github.com/GeekLuc)
- **Email** : [luca.rougefort2001@gmail.com](luca.rougefort2001@gmail.com)

#Explication de quelque scripts
##NotificationsControler.cs
Ce script gère la planification et l'envoi de notifications pour l'application Festimanga. 
Il utilise des bibliothèques spécifiques pour Android et hérite de MonoBehaviour. À l'initialisation, 
il demande l'autorisation d'envoyer des notifications et enregistre les canaux de notification pour Android, 
puis démarre une coroutine qui vérifie le fichier de planning toutes les minutes. 
La méthode CheckAndSendNotifications lit le fichier, extrait les informations des activités, et envoie une 
notification si l'heure actuelle est dans les 5 minutes précédant l'activité. Des directives conditionnelles 
assurent que certaines parties du code ne s'exécutent que sur Android.

##AndroidNotifications.cs
Ce script gère les notifications Android pour l'application Festimanga. Il utilise des bibliothèques spécifiques
pour Android et hérite de MonoBehaviour. À l'initialisation (Awake), il configure une source audio pour jouer un 
son de notification. La méthode RequestAuthorization demande la permission d'envoyer des notifications, tandis que 
RegisterNotificationChannel enregistre un canal de notification par défaut. La méthode SendNotification configure et 
envoie une notification avec un titre, un texte et une heure de déclenchement spécifiés, puis joue un son de notification. 
Des directives conditionnelles assurent que le code ne s'exécute que sur Android.

##DetailExposant.cs
Ce script gère l'affichage des détails de l'exposant sélectionné dans l'application Festimanga. Il utilise des bibliothèques 
pour la gestion des textes et hérite de MonoBehaviour. À l'initialisation (Start), il vérifie si les prefabs et les parents sont 
assignés, puis instancie les prefabs pour le nom, la description et l'emplacement de l'exposant, les assignant comme enfants 
des objets parents correspondants. Il récupère ensuite les informations de l'exposant sélectionné et met à jour le texte des
prefabs avec ces informations. En cas d'erreur, un message d'erreur est affiché dans la console.

##ListeLegendeDeroulant.cs
Ce script crée une liste déroulante pour les exposants en fonction de l'option sélectionnée dans le menu déroulant. Il utilise 
des bibliothèques pour la gestion des textes et des fichiers, et hérite de MonoBehaviour. À l'initialisation (Start), il lit 
les données des exposants à partir d'un fichier texte et les stocke dans une liste. Il ajoute également un écouteur pour 
détecter les changements de valeur dans le menu déroulant. La méthode LireFichierExposants lit le fichier texte, divise chaque
ligne en parties, et crée des objets Exposant qu'elle ajoute à la liste. La méthode OnExposantDropDownChange met à jour l'affichage 
des exposants en fonction de l'option sélectionnée dans le menu déroulant, en instanciant des objets texte pour chaque exposant 
correspondant et en les affichant sous l'objet parent spécifié.

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

# Luca Rougefort / GeekLuc
## B3JV Student in Video Game Programming at HEAJ

## **Mobile Application for Festimanga**
    - Description: This is a basic Android mobile application for the Festimanga event.
    - Technologies: C#, Unity

## Contact
- **GitHub**: [GeekLuc](https://github.com/GeekLuc)
- **Email**: [luca.rougefort2001@gmail.com](luca.rougefort2001@gmail.com)

#Explanation of some scripts
##NotificationsControler.cs
This script manages the scheduling and sending of notifications for the Festimanga application.
It uses specific libraries for Android and inherits from MonoBehaviour. Upon initialization,
it requests permission to send notifications and registers notification channels for Android,
then starts a coroutine that checks the schedule file every minute.
The CheckAndSendNotifications method reads the file, extracts activity information, and sends a
notification if the current time is within 5 minutes before the activity. Conditional directives
ensure that certain parts of the code only execute on Android.

##AndroidNotifications.cs
This script manages Android notifications for the Festimanga application. It uses specific libraries
for Android and inherits from MonoBehaviour. Upon initialization (Awake), it sets up an audio source
to play a notification sound. The RequestAuthorization method requests permission to send notifications,
while RegisterNotificationChannel registers a default notification channel. The SendNotification method
configures and sends a notification with a specified title, text, and trigger time, then plays a notification sound.
Conditional directives ensure that the code only executes on Android.

##DetailExposant.cs
This script manages the display of the selected exhibitor's details in the Festimanga application. It uses libraries
for text management and inherits from MonoBehaviour. Upon initialization (Start), it checks if the prefabs and parents are
assigned, then instantiates the prefabs for the exhibitor's name, description, and location, assigning them as children
of the corresponding parent objects. It then retrieves the selected exhibitor's information and updates the text of the
prefabs with this information. In case of an error, an error message is displayed in the console.

##ListeLegendeDeroulant.cs
This script creates a dropdown list for exhibitors based on the selected option in the dropdown menu. It uses libraries
for text and file management, and inherits from MonoBehaviour. Upon initialization (Start), it reads the exhibitor data
from a text file and stores it in a list. It also adds a listener to detect value changes in the dropdown menu. The LireFichierExposants
method reads the text file, splits each line into parts, and creates Exhibitor objects that it adds to the list. The OnExposantDropDownChange
method updates the display of exhibitors based on the selected option in the dropdown menu, by instantiating text objects for each corresponding
exhibitor and displaying them under the specified parent object.
