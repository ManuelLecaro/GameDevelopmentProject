using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class vid : MonoBehaviour
{
	public RawImage rawImage;
	public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayVideo());
    }

    // Update is called once per frame
    IEnumerator PlayVideo(){
    	   videoPlayer.Prepare();
          WaitForSeconds waitForSeconds = new WaitForSeconds(1);
          while (!videoPlayer.isPrepared)
          {
               yield return waitForSeconds;
               break;
          }
          rawImage.texture = videoPlayer.texture;
          videoPlayer.Play();
    videoPlayer.loopPointReached += EndReached;

    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
 {
     SceneManager.LoadScene(1);
 }

}
