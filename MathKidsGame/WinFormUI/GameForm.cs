using MathKidsCore;
using MathKidsCore.Model;
using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class GameForm : Form
    {
        private GameController _gameController = new GameController();
        private Color _neuturalColor = Color.LightGray;
        private TaskScheduler _guiTaskScheduler;
        private SoundPlayer _myPlayer = new SoundPlayer();


        public GameForm()
        {
            InitializeComponent();

            _gameController.OnCountDown += (o, progress) => Task.Run(()=> { })
                .ContinueWith(t => timeElapsedProgressBar.Value = progress, _guiTaskScheduler);

            _guiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            LoadNextMathTask();
        }

        private void LoadNextMathTask()
        {
            descriptionLabel.Text = _gameController.GenerateMathTaskAndGetDescription();

            buttonYes.Enabled = true;
            buttonNo.Enabled = true;
            buttonYes.BackColor = _neuturalColor;
            buttonNo.BackColor = _neuturalColor;
            timeElapsedProgressBar.Value = 0;
        }

        private void CheckAnswer(bool userAnswer, Button button)
        {
            bool solvedCorrect = _gameController.CheckAnswer(userAnswer);

            Stream soundStream = solvedCorrect ? Properties.Resources.Correct : Properties.Resources.Wrong3;
            _myPlayer.Stream = soundStream;
            //string soundFile = solvedCorrect ?  @"Resources\Correct.wav" : @"Resources\Wrong3.wav";
            //_myPlayer.SoundLocation = soundFile;
            _myPlayer.Play();

            Color color = solvedCorrect ? Color.Green : Color.Red;
            button.BackColor = color;

            buttonYes.Enabled = false;
            buttonNo.Enabled = false;

            Task.Delay(250)
                .ContinueWith(t => LoadNextMathTask(), _guiTaskScheduler);
        }

        private void buttonYes_Click(object sender, EventArgs e) => CheckAnswer(true, (Button)sender);

        private void buttonNo_Click(object sender, EventArgs e) => CheckAnswer(false, (Button)sender);
    }
}
