using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SoundControll : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSourceBackground;
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _xIcon;
        private void Awake()
        {
            _xIcon.SetActive(!Data.SoundEffect);
            
            _audioSourceBackground.enabled = Data.SoundEffect;
            _button.onClick.AddListener(ChangeSoundSetting);
        }

        private void ChangeSoundSetting()
        {
            Data.SoundEffect=!Data.SoundEffect;
            _xIcon.SetActive(!Data.SoundEffect);
            _audioSourceBackground.enabled = Data.SoundEffect;
        }
    }
}