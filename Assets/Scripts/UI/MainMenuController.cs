using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private TextMeshProUGUI _maxEggCountT;
        [SerializeField] private TextMeshProUGUI _eggCountT;

        private void Start()
        {
            _playButton.onClick.AddListener(()=>SceneManager.LoadScene(1));
            _eggCountT.text = "Egg Count: "+Data.EggCount.ToString();
            _maxEggCountT.text = "Max Egg Count: "+Data.MaxEgg.ToString();
        }
    }
}