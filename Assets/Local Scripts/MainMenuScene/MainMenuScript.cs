using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuScript : MonoBehaviour
{
    public Button LocalGameButton;
    public Button NetworkGameButton;
    public Button ExitGameButton;

    public Canvas QuitMenu;

    void Start()
    {
        QuitMenu = QuitMenu.GetComponent<Canvas>();
        QuitMenu.enabled = false;

        LocalGameButton = LocalGameButton.GetComponent<Button>();
        NetworkGameButton = NetworkGameButton.GetComponent<Button>();
        ExitGameButton = ExitGameButton.GetComponent<Button>();
    }

    public void LocalButtonPress()
    {
        GameObject.FindGameObjectWithTag("GameSettings").GetComponent<NetworkSettings>().IsNetworkGame = false;
        SceneManager.LoadScene("TestGameScene");
        GameObject.Destroy(GameObject.Find("MainMenuDollPrefab"));
    }

    public void NetworkButtonPress()
    {
        GameObject.FindGameObjectWithTag("GameSettings").GetComponent<NetworkSettings>().IsNetworkGame = true;
        SceneManager.LoadScene("ChoosingNetworkGameScene", LoadSceneMode.Single);
    }

    public void ExitButtonPress()
    {
        // Show the "Are you sure" menu
        QuitMenu.enabled = true;
       
        // Disable the main buttons
        LocalGameButton.enabled = false;
        NetworkGameButton.enabled = false;
        ExitGameButton.enabled = false;
    }

    public void ConfirmExitButtonPress()
    {
        Application.Quit();
    }

    public void CancelExitButtonPress()
    {
        // Remove the "Are you sure" menu
        QuitMenu.enabled = false;

        // Re-enable the main buttons
        LocalGameButton.enabled = true;
        NetworkGameButton.enabled = true;
        ExitGameButton.enabled = true;
    }
}
