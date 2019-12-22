using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SE { zoomIn, zoomOut, breakPlayer, breakWall, reward};

public enum BGMEnum {game };

public class AudioManager : MonoBehaviour {

    #region Singleton
    public static AudioManager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            CreateAudioSources();
        }
        else {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Local Variables
    AudioSource[] bgm;

    AudioSource[] seAudioSource;

    const int maxSEAtSameTime = 10;
    #endregion


    #region Inspector Variables
    public AudioClip[] soundEffects;

    public AudioClip[] bgmClip;

    AudioClip nextBGM;

    int actualBGM = 0;

    bool changeBGM = false;

    #endregion

    private void CreateAudioSources() {
        bgm = new AudioSource[2];
        for (int i = 0; i < bgm.Length; i++) {
            bgm[i] = gameObject.AddComponent<AudioSource>();
            bgm[i].playOnAwake = true;
            bgm[i].loop = true;
        }

        seAudioSource = new AudioSource[maxSEAtSameTime];
        for (int i = 0; i < maxSEAtSameTime; i++) {
            seAudioSource[i] = gameObject.AddComponent<AudioSource>();
            seAudioSource[i].volume = 0.5f;
            seAudioSource[i].playOnAwake = false;
        }

    }

    public void PlayBGM (BGMEnum i) {
        if (bgm[0].clip == bgmClip[(int)i] && bgm[0].isPlaying)
            return;

        bgm[0].clip = bgmClip[(int)i];
        bgm[0].volume = 0.8f;
        bgm[0].Play();
        Debug.Log("oloco");
    }

    public void ChangeMusic() {
        actualBGM++;
        nextBGM = bgmClip[actualBGM];
        changeBGM = true;
    }

    private void Update() {
        if (changeBGM) {
            changeBGM = false;
            //bgm.clip = nextBGM;    //ta dando problea e tem que arrumar
        }
    }

    public void PlaySE(SE se, bool uniqueSound = false) {

        int i = 0;

        if (uniqueSound) {
            for (i = 0; i < maxSEAtSameTime; i++) {
                if (seAudioSource[i].clip == soundEffects[(int)se] && seAudioSource[i].isPlaying) {
                    return;
                }
            }
        }

        for (i = 0; i < maxSEAtSameTime; i++) {
            if (seAudioSource[i].isPlaying)
                continue;
            else
                break;
        }
        if (i >= maxSEAtSameTime) {
            i = 0;
        }
        seAudioSource[i].clip = soundEffects[(int)se];
        seAudioSource[i].Play();
    }

}
