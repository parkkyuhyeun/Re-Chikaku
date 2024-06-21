using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] public AudioClip shooting;
    [SerializeField] public AudioClip missile;
    [SerializeField] public AudioClip hit;
    [SerializeField] public AudioClip enemyhit;
    [SerializeField] public AudioClip explosion;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Shooting()
    {
        audioSource.PlayOneShot(shooting);
    }
    public void Missile()
    {
        audioSource.PlayOneShot(missile);
    }
    public void Hit()
    {
        audioSource.PlayOneShot(hit);
    }
    public void EnemyHit()
    {
        audioSource.PlayOneShot(enemyhit);
    }
}
