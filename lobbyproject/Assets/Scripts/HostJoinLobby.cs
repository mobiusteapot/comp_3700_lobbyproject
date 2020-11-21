using UnityEngine;
using UnityEngine.UI;

namespace Lobby
{
    public class HostJoinLobby : MonoBehaviour
    {
        [Header("UI")]
        public Button hostLobbyButton;
        [SerializeField] private NetworkManagerLobby networkManager = null;
        [SerializeField] private GameObject landingPagePanel = null;

    void Start()
    {
        // Listens for host lobby button press
        Button hostbtn = hostLobbyButton.GetComponent<Button>();
        hostbtn.onClick.AddListener(HostLobby);
    }

        public void HostLobby()
        {
            //user is now hosting and their roomplayer object is instantiated
            networkManager.StartHost();
            //disable the host/join lobby panel to reveal the lobby panel
            landingPagePanel.SetActive(false);
        }
    }
}