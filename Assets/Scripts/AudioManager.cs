using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SfxChannels
{
    CH_STEPS=1,
    CH_SFX=2
}

public enum SoundList
{
    DOG,
    DOOR,
    DOOR2,
    RADIO
}

public enum TrackList
{
    SON,
    MYSTERIOS,
    JAZZ,
    HOPELESS,
    HOPE,
    DULCE_HABANA
}

public class AudioManager : MonoBehaviour
{
    private int SFX_CHANNELS = 3;

    public AudioClip[] Music;
    public AudioClip[] Sfx;
    public AudioSource[] AudioChannels;


    // Use this for initialization
    void Start()
    {
        SFX_CHANNELS = AudioChannels.Length - 2;
    }

    public void PlaySound(int sound, SfxChannels channel, bool loop = false)
    {
        if (channel == SfxChannels.CH_STEPS)
        {
            if (AudioChannels[1].clip != Sfx[sound])
            {
                AudioChannels[1].clip = Sfx[sound];
                AudioChannels[1].loop = loop;
                AudioChannels[1].Play();
            }
            else if (!AudioChannels[1].isPlaying)
            {
                AudioChannels[1].loop = loop;
                AudioChannels[1].Play();
            }
        }
        else
        {
            int i, exist_in_channel = -1;
            bool play = true;
            for (i = 2; i < SFX_CHANNELS + 2; i++)
            {
                if (AudioChannels[i].clip == Sfx[sound])
                {
                    exist_in_channel = i;
                    AudioChannels[i].loop = loop;
                    if (AudioChannels[i].isPlaying)
                    {
                        play = false;
                    }
                }
            }
            if (play)
            {
                if (exist_in_channel == -1)
                {
                    for (i = 2; i < SFX_CHANNELS + 2; i++)
                    {
                        if (!AudioChannels[i].isPlaying)
                        {
                            AudioChannels[i].loop = loop;
                            AudioChannels[i].clip = Sfx[sound];
                            AudioChannels[i].Play();
                        }
                    }
                }
                else
                {
                    AudioChannels[exist_in_channel].Play();
                }
            }
        }
    }

    public void SetSoundVolume(int sound, float volume)
    {
        for (int i = 1; i < SFX_CHANNELS + 2; i++)
        {
            if (AudioChannels[i].clip == Sfx[sound])
            {
                AudioChannels[i].volume = volume;
            }
        }
    }

    public void StopSound(int sound)
    {
        for (int i = 1; i < SFX_CHANNELS + 2; i++)
        {
            if (AudioChannels[i].clip == Sfx[sound])
            {
                AudioChannels[i].loop = false;
                AudioChannels[i].Stop();
            }
        }
    }

    public void PauseSFX()
    {
        for (int i = 1; i < SFX_CHANNELS + 2; i++)
        {
            AudioChannels[i].Pause();
        }
    }

    public void ResumeSFX()
    {
        for (int i = 1; i < SFX_CHANNELS + 2; i++)
        {
            AudioChannels[i].UnPause();
        }
    }

    public void PlayMusic(TrackList track)
    {
        if (AudioChannels[0].clip != Music[(int)track])
        {
            AudioChannels[0].clip = Music[(int)track];
            AudioChannels[0].loop = true;
            AudioChannels[0].Play();
        }
    }

    public void PauseMusic()
    {
        AudioChannels[0].Pause();
    }

    public void ResumeMusic()
    {
        AudioChannels[0].UnPause();
    }

    public void SetMusicVolume(float volume)
    {
        AudioChannels[0].volume = volume;
    }

    public void StopMusic()
    {
        AudioChannels[0].Stop();
    }
}
