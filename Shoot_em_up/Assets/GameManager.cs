using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public GameObject[] Can;

    private void Awake()
    {
        GM = this;
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void ActiveUi(string n)
    {
        for(int i = 0; i < Can.Length; i++)
        {
            if(Can[i].name == n)
            {
                Can[i].SetActive(true);
            }
            else
            {
                Can[i].SetActive(false);
            }
        }
    }
}
