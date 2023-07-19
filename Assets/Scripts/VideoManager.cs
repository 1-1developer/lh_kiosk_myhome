using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoClip[] videos;

    VideoPlayer videoPlayer;
    // Start is called before the first frame update
    private void OnEnable()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }
    public void PrepareClip(int index)
    {
        videoPlayer.clip = videos[index];
        videoPlayer.Prepare();
        videoPlayer.SetDirectAudioVolume(0,.6f);
    }
    public void StopVideo()
    {
        videoPlayer.Stop();
    }
    public void PlayVideo()
    {
        videoPlayer.Play();
    }

    public bool isPreparedClip()
    {
        return videoPlayer.isPrepared;
    }
}
