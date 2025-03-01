using System.Collections;
using UnityEngine;

namespace Scripts.CaseOne
{
    public class Crop : MonoBehaviour
    {
        [SerializeField] private GameObject[] growthStages; // Assign crop models in Inspector
        [SerializeField] private float growthTime = 5f;

        private int currentStage = 0;

        private void Start()
        {
            InitializeStages();
        }

        private void InitializeStages()
        {
            for (int i = 0; i < growthStages.Length; i++)
            {
                growthStages[i].SetActive(i == 0);
            }
        }

        public void StartGrowing()
        {
            StartCoroutine(Grow());
        }

        private IEnumerator Grow()
        {
            while (currentStage < growthStages.Length - 1)
            {
                yield return new WaitForSeconds(growthTime);

                growthStages[currentStage].SetActive(false);
                currentStage++;
                growthStages[currentStage].SetActive(true);
            }
        }

        public bool IsFullyGrown() => currentStage == growthStages.Length - 1;
    }
}