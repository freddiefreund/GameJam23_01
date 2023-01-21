using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public static SFXPlayer instance = null;

    [SerializeField] private GameObject audioSourcePrefab;
    [SerializeField] private float lifetime;

    private void Start()
    {
        if (instance != null) return;
        instance = this;
        DontDestroyOnLoad(this);
    }

    public void PlaySound(AudioClip audioClip)
    {
        GameObject instance = Instantiate(audioSourcePrefab);
        AudioSource audioSource = instance.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();

        Destroy(instance, lifetime);
    }
}
