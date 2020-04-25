using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Button button;

    public AudioSource audioMenu;
    bool isMuted = false;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void ToggleFullScreen(bool isFullScreen) {
        Debug.Log("Toggle is " + isFullScreen);
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log(Screen.fullScreen);
    }

    void TaskOnClick() {
        if (isMuted == false) {
            audioMenu.Pause();
            isMuted = true;
        } else {
            audioMenu.Play();
            isMuted = false;
        }
    }

}
