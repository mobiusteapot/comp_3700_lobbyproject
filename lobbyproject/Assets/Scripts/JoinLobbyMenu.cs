using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lobby
{
    public class JoinLobbyMenu : MonoBehaviour
    {
        
        [Header("UI")]

        public TMP_InputField ipInput;
        public Button joinIPButton;

        [SerializeField] private NetworkManagerLobby networkManager = null;

        [SerializeField] private GameObject landingPagePanel = null;

        void Start()
        {
            // Listens for Join Lobby button press
            Button ipbtn = joinIPButton.GetComponent<Button>();
            ipbtn.onClick.AddListener(JoinLobby);
            /*Button frndbtn = joinFriendButton.GetComponent<Button>();
            frndbtn.onClick.AddListener(JoinLobby);
            */

        }

        private void OnEnable()
        {
            NetworkManagerLobby.OnClientConnected += HandleClientConnected;
            NetworkManagerLobby.OnClientDisconnected += HandleClientDisconnected;
        }

        private void OnDisable()
        {
            NetworkManagerLobby.OnClientConnected -= HandleClientConnected;
            NetworkManagerLobby.OnClientDisconnected -= HandleClientDisconnected;
        }

        public void JoinLobby()
        {
            string ipAddress = ipInput.text;

            networkManager.networkAddress = ipAddress;
            networkManager.StartClient();

            joinIPButton.interactable = false;
        }

        private void HandleClientConnected()
        {
            joinIPButton.interactable = true;

            //gameObject.SetActive(false);
            landingPagePanel.SetActive(false);
        }

        private void HandleClientDisconnected()
        {
            joinIPButton.interactable = true;
        }
    }
}