using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutScene4 : MonoBehaviour
{

    VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        StartCoroutine("WaitForMovieEnd");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator WaitForMovieEnd()
    {
        while (!video.isPrepared || video.isPlaying)
        {
            yield return new WaitForEndOfFrame();

        }
        OnMovieEnded();
    }

    void OnMovieEnded()
    {
        SceneManager.LoadScene("BossLevel");
    }

    public void SkipButton()
    {
        SceneManager.LoadScene("BossLevel");
    }
}
