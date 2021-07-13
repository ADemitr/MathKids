using MathKidsCore;
using System;
using System.Drawing;
using System.IO;
using System.Media;
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

            _gameController.OnCountDown += (o, progress) => Task.Run(() => { })
                .ContinueWith(t => timeElapsedProgressBar.Value = progress, _guiTaskScheduler);

            _gameController.OnTimeForMathTaskUp += (o, e) => Task.Run(() => { })
                .ContinueWith(t => PlayScenarioTimeForMathTaskIsUp(), _guiTaskScheduler);

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
            labelMaxInARow.Text = "Максимум правильных ответов подряд: " + _gameController.MaxInARow.ToString();
            buttonCurrentinARow.Text = _gameController.CurrentInARow.ToString();
        }

        private void CheckAnswer(bool solvedCorrect, Button button)
        {
            Stream soundStream = solvedCorrect ? Properties.Resources.Correct : Properties.Resources.Wrong3;
            _myPlayer.Stream = soundStream;
            _myPlayer.Play();

            Color color = solvedCorrect ? Color.Green : Color.Red;
            button.BackColor = color;

            buttonYes.Enabled = false;
            buttonNo.Enabled = false;

            Task.Delay(250)
                .ContinueWith(t => LoadNextMathTask(), _guiTaskScheduler);
        }

        private void PlayScenarioTimeForMathTaskIsUp()
        {
            timeElapsedProgressBar.Value = 100;
            timeElapsedProgressBar.Value = 99;
            timeElapsedProgressBar.Value = 100;
            timeElapsedProgressBar.Style = ProgressBarStyle.Blocks;
            buttonYes.BackColor = Color.Red;
            buttonNo.BackColor = Color.Red;
            CheckAnswer(false, buttonYes);
        }

        private void buttonYes_Click(object sender, EventArgs e) =>
            CheckAnswer(_gameController.CheckAnswerAndCancelCountDown(true), (Button)sender);

        private void buttonNo_Click(object sender, EventArgs e) => 
            CheckAnswer(_gameController.CheckAnswerAndCancelCountDown(false), (Button)sender);


    }
}
