using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    public static UIMenuManager self;

    private void Awake()
    {
        if (self == null)
        {
            self = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public AudioSource audioSource;

    public void StartSoundOnBtn()
    {
        audioSource.mute = false;
    }

    public void StartSoundOffBtn()
    {
        audioSource.mute = true;
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void GameBtn()
    {
        SceneManager.LoadScene("Game");
    }

    public void MenuBtn()
    {
        SceneManager.LoadScene("Menu");
    }
}
