using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class JobMatchingWizard : MonoBehaviour
    {
        public TMP_Text Profit;
        private int _profit;
        private int _currentJobId;
        private int _currentSelectedCandidateId;
        private int[] _jobsBudget = new int[] {300000, 450000, 50000, 150000, 2000, 0, 0};
        private int[] _candidatesBudget = new int[] {270000, 200000, 400000, 300000, 450000, 10000, 35000, 100000, 90000, 0, 0, 0, 0, 0};
        private int[] _candidatesChances = new int[] {270000, 200000, 400000, 300000, 450000, 10000, 35000, 100000, 90000, 0, 0, 0, 0, 0};

        public void SetCurrentCandidateId(int id)
        {
            _currentSelectedCandidateId = id;
        }

        public void PickCurrentCandidate()
        {
            bool willBeSelected = false;
            int chance = _candidatesChances[_currentSelectedCandidateId - 1];
            
            if (Random.Range(0f, 1f) >= chance / 100f) 
                willBeSelected = true;

            if (willBeSelected)
            {
                _profit += (_jobsBudget[_currentJobId - 1] - _candidatesBudget[_currentSelectedCandidateId - 1]);
                Profit.text = _profit.ToString();
            }
        }
    }
}