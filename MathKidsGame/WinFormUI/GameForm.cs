using MathKidsCore;
using MathKidsCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class GameForm : Form
    {
        private IMathTaskGenerator _mathTaskGenerator = new HardCodeGanerator();
        private MathTask _correntMathTask;
        private Color _neuturalColor = Color.LightGray;
        private TaskScheduler _guiTaskScheduler;
        private SoundPlayer _myPlayer = new SoundPlayer();

        public GameForm()
        {
            InitializeComponent();

            _guiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            LoadNextMathTask();
        }

        private void LoadNextMathTask()
        {
            _correntMathTask = _mathTaskGenerator.Next();
            label1.Text = _correntMathTask.Description;

            buttonYes.Enabled = true;
            buttonNo.Enabled = true;
            buttonYes.BackColor = _neuturalColor;
            buttonNo.BackColor = _neuturalColor;
        }

        private void CheckAnswer(bool isCorrectAnswer, Button button)
        {
            bool solvedCorrect = isCorrectAnswer == _correntMathTask.IsCorrectAnswer;

            string soundFile = solvedCorrect ? @"C:\Users\dmitr\Downloads\Correct.wav" : @"C:\Users\dmitr\Downloads\Wrong3.wav";
            _myPlayer.SoundLocation = soundFile;
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
