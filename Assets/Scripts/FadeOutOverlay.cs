using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace DefaultNamespace
{
    public class FadeOutOverlay : MonoBehaviour
    {
        public Image Overlay;
        public TMP_Text Text;
        public AudioSource SplashMusic;
        public AudioSource BackgroundMusic;
        public float StandByTime = 5f;
        public float FadeOutDuration = 2f;

        private void Start()
        {
            StartCoroutine(FadeCoroutine());
        }

        public void ExitGame()
        {
            Overlay.color = new Color(1, 1, 1, 1);
            Text.color = new Color(1, 1, 1, 1);
            BackgroundMusic.Stop();
            SplashMusic.volume = 0.25f;
            SplashMusic.Play();
            StartCoroutine(FadeCoroutine(true));
        }
        public IEnumerator FadeCoroutine(bool exitGameAfter = false)
        {
            yield return new WaitForSeconds(StandByTime);
            
            if(exitGameAfter)
                Application.Quit();
            
            while (Overlay.color.a > 0f)
            {
                Overlay.color = new Color(1, 1,1, Overlay.color.a - 1 / (FadeOutDuration * 10f));
                Text.color = new Color(1, 1,1, Text.color.a - 1 / (FadeOutDuration * 10f));
                SplashMusic.volume -= 1 / (FadeOutDuration * 10f);
                yield return new WaitForSeconds(0.1f);
            }    
            
            BackgroundMusic.Play();
            gameObject.SetActive(false);
        }
    }
}