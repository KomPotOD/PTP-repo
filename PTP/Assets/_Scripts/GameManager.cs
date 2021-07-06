using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    private string _playerName;

    public string playerName    // ENCAPSULATION
    { get { return _playerName; } set { if (value.Length <= 11) _playerName = value; } }

    private void Start()
    {
        if (S != null)
        {
            Destroy(gameObject);
        }

        S = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.sceneCount == 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
