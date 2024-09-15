using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class pathupdater : MonoBehaviour
{
    
   public VideoPlayer videoPlayer;
   private void Start(){
    videoPlayer.url = PickFolder.finalpath;
    Debug.Log(videoPlayer.url);
    videoPlayer.Prepare();
    videoPlayer.Play();
    }
}