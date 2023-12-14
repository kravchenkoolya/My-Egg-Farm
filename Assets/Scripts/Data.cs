using UnityEngine;
using UnityEngine;

public static class Data
{
    private const string MAX_EGG_Key = "MAXEGG";
    private const string EGG_COUNT_Key = "EGGCOUNT";
    private const string SOUND_EFFECT_Key = "SOUNDEFFECT";

    private static int _maxEgg,_eggCount;
    private static bool _soundEffect;
    public static int MaxEgg
    {
        set
        {
            if (value > _maxEgg)
            {
                
                _maxEgg = value;
                PlayerPrefs.SetInt(MAX_EGG_Key,_maxEgg);
                PlayerPrefs.Save();
            }
        }
        get => _maxEgg;
    }

    public static int EggCount
    {
        set
        {
            _eggCount = value;
            PlayerPrefs.SetInt(EGG_COUNT_Key,_eggCount);
            PlayerPrefs.Save();
        }
        get => _eggCount;
    }

    public static bool SoundEffect
    {
        set
        {
            if (value != _soundEffect)
            {
                _soundEffect = value;
                int se = 0;
                if (_soundEffect)
                {
                    se = 1;
                }
                PlayerPrefs.SetInt(SOUND_EFFECT_Key,se);
                PlayerPrefs.Save();
            } 
        }
        get => _soundEffect;
    }

    static Data()
    {
        if (PlayerPrefs.HasKey(MAX_EGG_Key))
        {
            MaxEgg = PlayerPrefs.GetInt(MAX_EGG_Key);
        }   
        if (PlayerPrefs.HasKey(EGG_COUNT_Key))
        {
            EggCount = PlayerPrefs.GetInt(EGG_COUNT_Key);
        }   
        if (PlayerPrefs.HasKey(SOUND_EFFECT_Key))
        {
            if (PlayerPrefs.GetInt(SOUND_EFFECT_Key)==1)
            {
                SoundEffect = true;
            }
            else
            {
                SoundEffect = false;
            }
        }
        else
        {
                SoundEffect = true;
        }
        
    }
}