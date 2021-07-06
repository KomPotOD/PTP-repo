using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    private string _playerName;

    public string playerName    // ENCAPSULATION
    { get { return _playerName; } set { if(value.Length <= 11) _playerName = value; } }

    public void GameStart()
    {
        if (playerName == null || playerName.Length == 0)
        {
            Debug.LogError("Name is not set!");
            return;
        }
        GameManager.S.playerName = playerName;
        SceneManager.LoadScene(1);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

}
