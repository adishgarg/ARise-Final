using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControls : MonoBehaviour
{
    public VideoPlayer  videoPlayer;

    public Button playPauseButton;
    public Button fullscreenButton;

    public Sprite playImage;
    public Sprite pauseImage;
    public Sprite fullscreenImage;
    public Sprite exitFullscreenImage;

    private bool isPlaying = true;
    private bool isFullscreen = false;

    void Start()
    {
        // Add listeners to the buttons
        playPauseButton.onClick.AddListener(TogglePlayPause);
        fullscreenButton.onClick.AddListener(ToggleFullscreen);

        // Initialize button images
        playPauseButton.image.sprite = pauseImage;
        fullscreenButton.image.sprite = fullscreenImage;
    }

    void TogglePlayPause()
    {
        if (isPlaying)
        {
            videoPlayer.Pause();
            playPauseButton.image.sprite = playImage;
        }
        else
        {
            videoPlayer.Play();
            playPauseButton.image.sprite = pauseImage;
        }
        isPlaying = !isPlaying;
    }

    void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen;
        if (isFullscreen)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            fullscreenButton.image.sprite = exitFullscreenImage;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            fullscreenButton.image.sprite = fullscreenImage;
        }
    }

}
