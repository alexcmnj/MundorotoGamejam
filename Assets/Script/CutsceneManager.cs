using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string escenaJuego = "GameScene";

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoTerminado;
        videoPlayer.Play();
    }

    void OnVideoTerminado(VideoPlayer vp)
    {
        SceneManager.LoadScene(escenaJuego);
    }
}