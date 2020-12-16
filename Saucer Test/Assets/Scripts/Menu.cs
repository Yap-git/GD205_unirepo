using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
     public GUISkin guiSkin;
 
      // When About is clicked, it starts off with "About", then breaks into a new line
     private string clicked = "", MessageDisplayOnAbout = "About \n ";
     private Rect WindowRect = new Rect((Screen.width / 2) - 100, Screen.height / 2, 200, 200);
     private float volume = 1.0f;
 
     private void Start()
     {
        //Information on how to play
         MessageDisplayOnAbout += "How to Play: Use WASD to Move, Q and E to turn. Gather all Gas Cans to Win. Click Enemies to Kill them. Press ESC to Go Back";
     }
 
     private void OnGUI()
     {
     	//Important note: "" is a string that determines the start of the Menu,
     	//it is very necessary
         
         //When the game is started, a Rectangle or "Window" is drawn to fit
     	//the player's screen. The following code attaches what windows such as
     	//options are clicked, leading into a different assortment of menus
         GUI.skin = guiSkin;
         if (clicked == "")
         {
             WindowRect = GUI.Window(0, WindowRect, menuFunc, "Main Menu");
         }
         else if (clicked == "options")
         {
             WindowRect = GUI.Window(1, WindowRect, optionsFunc, "Options");
         }
         else if (clicked == "about")
         {
             GUI.Box(new Rect (0,0,Screen.width,Screen.height), MessageDisplayOnAbout);
         }else if (clicked == "resolution")
         {
         	//This code uses a for loop to create a vertical list of different Screen Resolutions.
         	//When a resolution is clicked, it checks what box along the "X" interger it is, then
         	//sets the screen resolution accordingly.
             GUILayout.BeginVertical();
             for (int x = 0; x < Screen.resolutions.Length;x++ )
             {
                 if (GUILayout.Button(Screen.resolutions[x].width + "X" + Screen.resolutions[x].height))
                 {
                     Screen.SetResolution(Screen.resolutions[x].width,Screen.resolutions[x].height,true);
                 }
             }
             GUILayout.EndVertical();
             GUILayout.BeginHorizontal();
             if (GUILayout.Button("Back"))
             {
                 clicked = "options";
             }
             GUILayout.EndHorizontal();
         }
     }
       //Code that determines what Options displays when clicked.
     private void optionsFunc(int id)
     {
         if (GUILayout.Button("Resolution"))
         {
             clicked = "resolution";
         }
         GUILayout.Box("Volume");
         volume = GUILayout.HorizontalSlider(volume ,0.0f,1.0f);
         AudioListener.volume = volume;
         if (GUILayout.Button("Back"))
         {
             clicked = "";
         }
     }
     //This code going onword is for button management, and for any window that leads
     //into a straightforward command, such as "Play Game" which will start the scene
     private void menuFunc(int id)
     {
         //buttons 
         if (GUILayout.Button("Play Game"))
         {
             //play game is called
             SceneManager.LoadScene("Final");
         }
         if (GUILayout.Button("Options"))
         {
             clicked = "options";
         }
         if (GUILayout.Button("About"))
         {
             clicked = "about";
         }
         if (GUILayout.Button("Quit Game"))
         {
             Application.Quit();
         }
         
     }
 
     private void Update()
     {
         if (clicked == "about" && Input.GetKey (KeyCode.Escape))
             clicked = "";
     }
 }