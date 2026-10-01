using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public int Respawn;

    public void PlayGame()
    {
        SceneManager.LoadScene(Respawn);
    }

}
