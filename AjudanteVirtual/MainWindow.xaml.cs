using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AjudanteVirtual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
        }

        private void btnFalar_Click(object sender, RoutedEventArgs e)
        {
            SpeechSynthesizer speak = new SpeechSynthesizer();
            speak.SelectVoiceByHints(VoiceGender.Male);
            speak.SpeakAsync("Arthur, eu sou seu asistente virtual");
        }

        private void btnFalar_Click2(object sender, RoutedEventArgs e)
        {
            SpeechSynthesizer speak = new SpeechSynthesizer();
            speak.SelectVoiceByHints(VoiceGender.Male);
            StarTimer();
            speak.SpeakCompleted += Speak_SpeakCompleted;
            speak.SpeakAsync(tx.Text);
        }

        private void Speak_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            StopTimer();
        }

        private void StarTimer()
        {
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0,0, 200);
            dispatcherTimer.Start();
        }

        private void StopTimer()
        {
            dispatcherTimer.Stop();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (imgClosed.Visibility == Visibility.Visible)
            {
                imgClosed.Visibility = Visibility.Collapsed;
                imgOpen.Visibility = Visibility.Visible;

            }
            else
            {
                imgClosed.Visibility = Visibility.Visible;
                imgOpen.Visibility = Visibility.Collapsed;
            }
        }
    }
}
