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
