using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximitySound : MonoBehaviour
{
    public SoundList SoundIndex;
    private AudioManager SoundManager;
    private PlayerMovement Player;
    private RoomParameters Room;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager = GameObject.Find("SoundManager").GetComponent<AudioManager>();
        Player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        Room = GetComponentInParent<RoomParameters>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(Player.transform.position.x - transform.position.x) < Room.Size.x)
        {
            SoundManager.PlaySound((int)SoundIndex, SfxChannels.CH_SFX, true);
            SoundManager.SetSoundVolume((int)SoundIndex, 1.0f-Math.Abs(Player.transform.position.x - transform.position.x) / Room.Size.x);
        }
        else
        {
            SoundManager.StopSound((int)SoundIndex);
        }
    }
}
