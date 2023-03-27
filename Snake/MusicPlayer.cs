using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Snake
{
    public class MusicPlayer : IDisposable
    {
        private readonly Mp3FileReader _mp3FileReader;
        private readonly WaveOutEvent _waveOut;

        public MusicPlayer(string mp3FilePath)
        {
            _mp3FileReader = new Mp3FileReader(mp3FilePath);
            _waveOut = new WaveOutEvent();
            _waveOut.Init(_mp3FileReader);
        }

        public void PlayLooping()
        {
            _waveOut.PlaybackStopped += (s, e) => { _mp3FileReader.Position = 0; _waveOut.Play(); };
            _waveOut.Play();
        }

        public void Stop()
        {
            _waveOut.Stop();
        }

        public void Dispose()
        {
            _waveOut.Dispose();
            _mp3FileReader.Dispose();
        }
    }
}