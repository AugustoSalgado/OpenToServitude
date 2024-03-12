using UnityEngine;

namespace DefaultNamespace
{
    public class ChangeTab : MonoBehaviour
    {
        public GameObject TargetTab;
        public GameObject OtherTab;
        public GameObject CurrentTabButton;
        public GameObject TargetTabButton;

        public void PerformChangeTab()
        {
            if (TargetTab.activeSelf)
                return;
            
            TargetTab.SetActive(true);
            OtherTab.SetActive(false);
            
            var homeTabButtonOrder = CurrentTabButton.transform.GetSiblingIndex();
            var jobsTabButtonOrder = TargetTabButton.transform.GetSiblingIndex();
            CurrentTabButton.transform.SetSiblingIndex(jobsTabButtonOrder);
            TargetTabButton.transform.SetSiblingIndex(homeTabButtonOrder);
        }
    }
}