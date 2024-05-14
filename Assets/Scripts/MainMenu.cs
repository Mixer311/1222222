using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour
{
    public AudioSource myFX;

    public Slider musicSlider;
    public Slider soundSlider;
    public AudioMixer musicMixer;
    public AudioMixer soundMixer;

    public void SetVolume()
    {
        musicMixer.SetFloat("MusicVolume", musicSlider.value);
        soundMixer.SetFloat("SoundVolume", soundSlider.value);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Выход из игры!");
    }
}
