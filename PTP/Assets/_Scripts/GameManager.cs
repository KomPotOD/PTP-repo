using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    private void Start()
    {
        if (S != null)
        {
            Destroy(gameObject);
        }

        S = this;
        DontDestroyOnLoad(gameObject);
    }
}
