namespace MathKidsCore.Model
{
    public struct MathTask
    {
        public string Description { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public int Result { get; set; }

        public MathTask(string description, bool isCorrectAnswer, int result = 0)
        {
            Description = description;
            IsCorrectAnswer = isCorrectAnswer;
            Result = result;
        }
    }
}
