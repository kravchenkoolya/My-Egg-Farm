using System.Collections.Generic;
using PlayerComponents;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PauseController : MonoBehaviour
    {
        public List<IPauseObject> PauseObjects; 
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Buscket _buscket;
        
        private void OnEnable()
        {
            _restartButton.onClick.AddListener(Restart);
            _mainMenuButton.onClick.AddListener(BackToMainMenu);
            StopGame();
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(Restart);
            _mainMenuButton.onClick.RemoveListener(BackToMainMenu);
            ContinueGame();
        }

        private void Restart()
        {
            OnExit();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        private void BackToMainMenu()
        {
            OnExit();
            SceneManager.LoadScene(0);
        }

        private void OnExit()
        {
            Data.MaxEgg = _buscket.EggCount;
            Data.EggCount += _buscket.EggCount;
        }

        public void StopGame()
        {
            foreach (IPauseObject pauseObject in PauseObjects)
            {
                pauseObject.Pause();
            }
        }

        public void ContinueGame()
        {
            foreach (IPauseObject pauseObject in PauseObjects)
            {
                pauseObject.Play();
            }
        }
        
        
    }
}