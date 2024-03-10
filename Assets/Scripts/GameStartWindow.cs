using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartWindow : MonoBehaviour
{
    public void OpenGameScene()
    {
        SceneManager.LoadScene(1); // burada oyun sahnesi yükleniyor
    }
}
