using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class JobMatchingWizard : MonoBehaviour
    {
        public TMP_Text Profit;
        public TMP_Text NotificationText;
        public TMP_Text FinalMessageText;
        public GameObject PickCandidateButton;
        public GameObject JobsTabContainer;
        public GameObject HomeTabContainer;
        public GameObject HomeTabButton;
        public GameObject JobsTabButton;
        public GameObject PauseMenu;
        public GameObject Overlay;
        public GameObject FinalMessage;
        public GameObject[] JobDescriptions;
        public GameObject[] Resumes;
        public GameObject[] Profiles;
        public GameObject[] HomePosts;
        private int _profit;
        private int _successfulMatchedJobs;
        private int _currentJobId = 1;
        private int _currentSelectedCandidateId = 1;
        private int[] _jobsBudget = new int[] {300000, 450000, 50000, 150000, 2000, 0, 0};
        private int[] _candidatesBudget = new int[] {270000, 200000, 400000, 300000, 450000, 10000, 35000, 100000, 90000, 0, 0, 0, 0, 0};
        private int[] _candidatesChances = new int[] {85, 50, 60, 80, 100, 10, 75, 75, 60, 100, 100, 100, 100, 100};

        private void Start()
        {
            JobDescriptions[0].SetActive(true);
            Profiles[0].SetActive(true);
            PickCandidateButton.SetActive(false);
        }

        public void SetCurrentCandidateId(int id)
        {
            PickCandidateButton.SetActive(true);
            Resumes[_currentSelectedCandidateId-1].SetActive(false);
            Resumes[id-1].SetActive(true);
            _currentSelectedCandidateId = id;
        }

        public void PickCurrentCandidate()
        {
            if (_currentSelectedCandidateId == 14)
            {
                FinalMessageText.text =
                    $"After this test period you've managed to make {_profit} JamCoins by successfully matching {_successfulMatchedJobs} candidates." +
                    $" Should you be proud of that? I don't know, but thanks for playing!";
                Overlay.gameObject.SetActive(true);
                FinalMessage.gameObject.SetActive(true);
                return;
            }
                
            bool willBeSelected = false;
            int chance = _candidatesChances[_currentSelectedCandidateId - 1];
            
            if (Random.Range(0f, 1f) <= chance / 100f) 
                willBeSelected = true;

            NotificationText.text = "We are sorry! Your last applicant was not accepted for the position";

            if (willBeSelected)
            {
                _profit += (_jobsBudget[_currentJobId - 1] - _candidatesBudget[_currentSelectedCandidateId - 1]);
                Profit.text = _profit.ToString() + " JamCoins";
                _successfulMatchedJobs++;
                NotificationText.text = "Congratulations! Your last applicant was accepted for the position";
            }

            JobDescriptions[_currentJobId-1].SetActive(false);
            Profiles[_currentJobId-1].SetActive(false);
            HomePosts[_currentJobId-1].SetActive(false);
            _currentJobId++;
            
            JobDescriptions[_currentJobId-1].SetActive(true);
            Profiles[_currentJobId-1].SetActive(true);
            HomePosts[_currentJobId-1].SetActive(true);
            Resumes[_currentSelectedCandidateId-1].SetActive(false);
            
            HomeTabContainer.SetActive(true);
            JobsTabContainer.SetActive(false);

            var homeTabButtonOrder = HomeTabButton.transform.GetSiblingIndex();
            var jobsTabButtonOrder = JobsTabButton.transform.GetSiblingIndex();
            HomeTabButton.transform.SetSiblingIndex(jobsTabButtonOrder);
            JobsTabButton.transform.SetSiblingIndex(homeTabButtonOrder);
            PickCandidateButton.SetActive(false);
        }

        public void OnExit()
        {
            Application.Quit();
        }

        public void TryAgain()
        {
            SceneManager.LoadScene("Browser");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Overlay.SetActive(!PauseMenu.gameObject.activeSelf);
                PauseMenu.SetActive(!PauseMenu.gameObject.activeSelf);
            }
        }
    }
}