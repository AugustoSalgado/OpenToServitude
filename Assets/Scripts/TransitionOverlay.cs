using System.Collections;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class TransitionOverlay : MonoBehaviour
    {
        public Image OverlayBackground;
        public Image ChainedInLogo;
        public JobMatchingWizard JobMatchingWizard;
        public float FadeDuration;

        public void DoTransition()
        {
            OverlayBackground.color = new Color(0, 0,0, 0.5f);
            ChainedInLogo.color = new Color(1, 1,1, 0.5f);
            OverlayBackground.gameObject.SetActive(true);
            StartCoroutine(TransitionCoroutine());
        }

        private IEnumerator TransitionCoroutine()
        {
            
            while (OverlayBackground.color.a < 1f)
            {
                OverlayBackground.color = new Color(0, 0,0, OverlayBackground.color.a + 1 / (FadeDuration * 10f));
                ChainedInLogo.color = new Color(1, 1,1, ChainedInLogo.color.a + 1 / (FadeDuration * 10f));
                yield return new WaitForSeconds(0.1f);
            }

            JobMatchingWizard.SwitchTabs();
            yield return new WaitForSeconds(1.5f);
            
            while (OverlayBackground.color.a > 0f)
            {
                OverlayBackground.color = new Color(0, 0,0, OverlayBackground.color.a - 1 / (FadeDuration * 10f));
                ChainedInLogo.color = new Color(1, 1,1, ChainedInLogo.color.a - 1 / (FadeDuration * 10f));
                yield return new WaitForSeconds(0.1f);
            }    
            
            OverlayBackground.gameObject.SetActive(false);
        }
    }
}