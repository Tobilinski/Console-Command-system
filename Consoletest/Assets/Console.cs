using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// This script is used to create a console for the game.
// Dieses Skript wird verwendet um eine Konsole für das Spiel zu erstellen.

// The console can be opened by pressing the backquote key.
// Die Konsole kann geöffnet werden indem die Backquote Taste gedrückt wird.

// The console can be closed by pressing the backquote key again.
// Die Konsole kann geschlossen werden indem die Backquote Taste erneut gedrückt wird.

// Requirements:
    // Canvas with an empty GameObject, InputField and a Text element.
    // Empty GameObject in the Canvas must be named "ConsoleParent".
    // InputField in UI must be named "Console".
    // Text element in UI must be named "Output".
    // Attach teh script anywhere in the scene.

// Anforderungen:
    // Canvas mit einem leeren GameObject, InputField und einem Text Element.
    // Leeres GameObject im Canvas muss "ConsoleParent" heißen.
    // InputField im UI muss "Console" heißen.
    // Text Element im UI muss "Output" heißen.
    // Script irgendwo in der Szene anhängen.
public class Console : MonoBehaviour
{
    private InputField _inputField;
    private Text _consoleText;
    private GameObject _ConsoleParent;
    static List<string> typedCommands = new List<string>();
    private void Start()
    {
        // Finding and assigning references to UI elements.
        // Finden von Gameobject fuer die Konsole der Referenze.
        _consoleText = GameObject.Find("Output").GetComponent<Text>();
        _inputField = GameObject.Find("Console").GetComponent<InputField>();
        _ConsoleParent = GameObject.Find("ConsoleParent");
        
        // Setting the console UI to be inactive by default.
        // Setzen der Konsole auf inaktiv als Standard.
        _ConsoleParent.SetActive(false);
        
        // Displaying previously typed commands in the console.
        // Anzeigen von zuvor eingegebenen Befehlen in der Konsole.
        for (int i = 0; i < typedCommands.Count; i++)
        {
            _consoleText.text += "\n" + typedCommands[i];
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //Input to open console.
        //Eingabe um Konsole zu öffnen.
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
          toggleConsole();
        }

       
        
        //Input to send command.
        //Eingabe um Befehl zu senden.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            string command = _inputField.text;
            //Adding the command to the list of typed commands.
            //Hinzufügen des Befehls zur Liste der eingegebenen Befehle.
            typedCommands.Add(command);
            //Only adding the command to the consoleText (Display) if it is not empty.
            //Nur hinzufügen des Befehls zum consoleText (Anzeige) wenn er nicht leer ist.
            if (!string.IsNullOrEmpty(command))
            {
                _consoleText.text += "\n" + command;
                _inputField.text = "";
            }

            
            //Example use case: Loading a level via Command.
            //Beischpiel für die Verwendung von laden eines Levels über Befehl.
            switch (command)
            {
                //Command Name: LoadLevel_1
                case "LoadLevel_1":
                    SceneManager.LoadScene("test");
                    break;
                //Command Name: LoadLevel_2
                case "LoadLevel_2":
                    SceneManager.LoadScene("Scene2");
                    break;
                //Command Name: LoadLevel_3
                case "LoadLevel_3":
                    SceneManager.LoadScene("Scene3");
                    break;
            }
        }
        void toggleConsole()
        {
            bool currentstateConsole = _ConsoleParent.activeSelf;
            _ConsoleParent.SetActive(!currentstateConsole);
        }
    }
}
