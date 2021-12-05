using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameManager.instance.health = GameManager.instance.maxHealth;

        
    }
    // Start is called before the first frame update
    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Reload()
    {
        SceneManager.LoadScene(GameManager.instance.lastScene);
    }
}
