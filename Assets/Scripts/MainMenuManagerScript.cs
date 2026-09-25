using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameplay1()
    {
        SceneManager.LoadScene("Gameplay 1");
    }
        public void StartGameplay2()
    {
        SceneManager.LoadScene("Gameplay 2");
    }
}
