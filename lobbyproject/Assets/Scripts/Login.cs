using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    // Gets input from assigned UI elements (both input boxes and both buttons)
    public TMP_InputField UsernameInput;
    public TMP_InputField PasswordInput;
    public Button LoginButton;
    public Button CreateAccButton;
    
    [SerializeField] private GameObject landingPagePanel = null;
    // Start is called before the first frame update
    void Start()
    {
        // Listens for login/create account button press
        Button lgnbtn = LoginButton.GetComponent<Button>();
        lgnbtn.onClick.AddListener(SendLoginInfo);
        Button accbtn = CreateAccButton.GetComponent<Button>();
        accbtn.onClick.AddListener(SendCreateAccountInfo);

        // Loads player login info
        LoadLoginInfo();
    }

    public void SendLoginInfo()
    {
        var friendsList = GameObject.Find("Friends List").GetComponent<CanvasGroup>();
        // Currently saves input data to player preference. To get player preference (for setup with a database or any other use), use "PlayerPrefs.GetString("String")
        // This method means the player data is saved with the application cookies for easy access, and the player's last username or password is remembered by default
        if ((UsernameInput == null )) {
            Debug.Log("Username input field is null.");
		}
        else {
            PlayerPrefs.SetString("Username", UsernameInput.text);
            PlayerPrefs.SetString("Password", PasswordInput.text);
		}

        //logic to validate the login (from database?), currently if (true) as a placeholder
        if (true) {
            //user logged in, disable the login panel to reveal the host/join lobby panel
            landingPagePanel.SetActive(false);

            // Show user friends


            friendsList.alpha = 1;

        }
    }

    public void SendCreateAccountInfo()
    {
        // Currently does nothing different from attempting to login
        PlayerPrefs.SetString("Username", UsernameInput.text);
        PlayerPrefs.SetString("Password", PasswordInput.text);
    }


    public void LoadLoginInfo()
    {
        if (PlayerPrefs.HasKey("Username"))
        {
            UsernameInput.text = PlayerPrefs.GetString("Username");
        }
        else
        {
            Debug.Log("No username found on load");
        }
        if (PlayerPrefs.HasKey("Password"))
        {
            PasswordInput.text = PlayerPrefs.GetString("Password");
        }
        else
        {
            Debug.Log("No password found on load");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
