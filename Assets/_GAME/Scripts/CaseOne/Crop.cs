using System.Collections;
using UnityEngine;

namespace Scripts.CaseOne
{
    /// <summary>
    /// Manages the growth stages of a single crop.
    /// </summary>
    public class Crop : MonoBehaviour
    {
        [SerializeField] private GameObject[] growthStages; // The array of GameObjects representing each growth stage.
        [SerializeField] private float growthTime = 5f;     // Time (in seconds) between transitions from one growth stage to the next.

        private int currentStage = 0; // Tracks the current index in the growthStages array.

        private void Start()
        {
            // Sets up the initial visibility state for all growth stages.
            InitializeStages();
        }

        /// <summary>
        /// Initializes the crop by ensuring only the first stage is active.
        /// </summary>
        private void InitializeStages()
        {
            for (int i = 0; i < growthStages.Length; i++)
            {
                growthStages[i].SetActive(i == 0);
            }
        }

        /// <summary>
        /// Begins the coroutine that moves the crop through its growth stages over time.
        /// </summary>
        public void StartGrowing()
        {
            StartCoroutine(Grow());
        }

        /// <summary>
        /// Coroutine that waits for <c>growthTime</c> before moving to the next stage,
        /// until the final stage is reached.
        /// </summary>
        private IEnumerator Grow()
        {
            while (currentStage < growthStages.Length - 1)
            {
                // Wait for the specified amount of time before progressing the growth stage.
                yield return new WaitForSeconds(growthTime);

                // Deactivate the current stage and activate the next one.
                growthStages[currentStage].SetActive(false);
                currentStage++;
                growthStages[currentStage].SetActive(true);
            }
        }

        /// <summary>
        /// Checks if the crop has reached its final growth stage.
        /// </summary>
        public bool IsFullyGrown() => currentStage == growthStages.Length - 1;
    }
}
