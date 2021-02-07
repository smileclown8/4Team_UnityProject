using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MovieController : MonoBehaviour
{
    public RawImage mScreen = null;
    public VideoPlayer mVidepPlayer = null;

    // Start is called before the first frame update
    void Start()
    {
        if ( mScreen != null && mVidepPlayer != null)
        {
            StartCoroutine(PrepareVideo());
        }
    }

    protected IEnumerator PrepareVideo()
    {
        mVidepPlayer.Prepare();

        while(!mVidepPlayer.isPrepared)
        {
            yield return null;
        }
        mScreen.texture = mVidepPlayer.texture;
    }

    public void PlayVideo()
    {
        if(mVidepPlayer != null && mVidepPlayer.isPrepared)
        {
            mVidepPlayer.Play();
        }
    }

    public void StopVideo()
    {
        if(mVidepPlayer != null && mVidepPlayer.isPrepared)
        {
            mVidepPlayer.Stop();
        }
    }
}
