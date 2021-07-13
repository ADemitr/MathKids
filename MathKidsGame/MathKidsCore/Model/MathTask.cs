namespace MathKidsCore.Model
{
    public struct MathTask
    {
        public string Description { get; set; }
        public bool CorrectAnswer { get; set; }
        public MathTask(string description, bool isCorrectAnswer)
        {
            Description = description;
            CorrectAnswer = isCorrectAnswer;
        }
    }
}
