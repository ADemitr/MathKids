namespace MathKidsCore.Model
{
    public struct MathTask
    {
        public string Description { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public MathTask(string description, bool isCorrectAnswer)
        {
            Description = description;
            IsCorrectAnswer = isCorrectAnswer;
        }
    }
}
