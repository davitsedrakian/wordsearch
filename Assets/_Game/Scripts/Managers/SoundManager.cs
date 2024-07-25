using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   
   public static SoundManager instance;


   [SerializeField] private AudioSource musicSource;
   [SerializeField] private AudioSource effectsSource;

   [SerializeField] private AudioClip gameLaunchSound;
   [SerializeField] private AudioClip popSound;
   public bool soundEnabled { get; set; }
   

   private void Start()
   {
      soundEnabled = true;
      PlaySound(gameLaunchSound);
   }

   public void PlayMusic()
   {
      if (soundEnabled)
      {
         musicSource.Play();
         musicSource.mute = false;
      }
       
   }

   public void StopMusic()
   {
      musicSource.Stop();
      musicSource.mute = true;
   }

   public void PlayPopSound()
   {
      PlaySound(popSound);
   }

   public void PlaySound(AudioClip clip)
   {
      if(soundEnabled)
         effectsSource.PlayOneShot(clip);
   }

   public void ChangeMasterVolume(float value)
   {
      AudioListener.volume = value;
   }
}
