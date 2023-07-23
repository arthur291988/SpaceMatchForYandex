using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField]
    private AudioSource flagShot;
    [SerializeField]
    private AudioSource cruisShot;
    [SerializeField]
    private AudioSource destrShot;
    [SerializeField]
    private AudioSource Explosion;
    [SerializeField]
    private AudioSource tileSound0;
    [SerializeField]
    private AudioSource tileSound1;
    [SerializeField]
    private AudioSource reloadSound;
    [SerializeField]
    private AudioSource victorySound;
    [SerializeField]
    private AudioSource alarmSound;
    [SerializeField]
    private AudioSource alienVoice;
    [SerializeField]
    private AudioSource assistantVoice;
    [SerializeField]
    private AudioSource messageAlarm;
    [SerializeField]
    private AudioSource connectionEstablished;

    private void Awake()
    {
        Instance = this;
    }

    public void shotSoundPlay(int index) {
        if (index == 0) destrShot.Play();
        else if (index == 1) cruisShot.Play();
        else flagShot.Play();
    }
    public void explosionPlay()
    {
        Explosion.Play();
    }
    public void tilePlay(int value)
    {
        if (value < 5) tileSound0.Play();
        else tileSound1.Play();
    }

    public void reloadPlay() {
        reloadSound.Play();
    }

    public void endGameSoundPlay(bool victory)
    {
        if (victory) victorySound.Play();
        else alarmSound.Play();
    }

    public void alarmSoundPlay(bool play) {

        if (play) alarmSound.Play();
        else alarmSound.Stop();
    }

    public void alienVoiceFunc(bool play) {
        if (play) alienVoice.Play();
        else alienVoice.Stop();
    }
    public void assistantVoiceFunc(bool play)
    {
        if (play) assistantVoice.Play();
        else assistantVoice.Stop();
    }
    public void messageVoiceFunc(bool play)
    {
        if (play) messageAlarm.Play();
        else messageAlarm.Stop();
    }
    public void connectionVoice()
    {
        connectionEstablished.Play();
    }
}
