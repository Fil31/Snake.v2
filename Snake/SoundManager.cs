using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.Wave;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class SoundManager
    {
        private string _backgroundMusicPath = @"C:\Users\clash\source\repos\Snake\Snake\start.mp3";

        public async Task PlayEatSoundAsync()
        {
            string eatSoundPath = @"C:\Users\clash\source\repos\Snake\Snake\eat.mp3";
            await PlaySoundAsync(eatSoundPath);
        }

        public async Task PlayGameOverSoundAsync()
        {
            string gameOverSoundPath = @"C:\Users\clash\source\repos\Snake\Snake\game_over.mp3";
            await PlaySoundAsync(gameOverSoundPath);
        }

        public async Task PlayBackgroundMusicAsync()
        {
            await PlayBackgroundMusicAsync(_backgroundMusicPath);
        }

        private async Task PlayBackgroundMusicAsync(string musicPath)
        {
            await Task.Run(() =>
            {
                using (var audioFile = new AudioFileReader(musicPath))
                using (var outputDevice = new WaveOutEvent { DesiredLatency = 200 })
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(1000);
                    }
                }
            });
        }

        private async Task PlaySoundAsync(string soundPath)
        {
            await Task.Run(() =>
            {
                using (var audioFile = new AudioFileReader(soundPath))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(50);
                    }
                }
            });
        }
    }
}
