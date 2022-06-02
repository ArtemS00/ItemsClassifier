namespace ItemsClassifier
{
    public class PostClassificationSettings
    {
        public ClassificationType ClassificationType { get; set; } = ClassificationType.Individual;
        public CategoriesConflictBehaviorType ConflictBehavior { get; set; } = CategoriesConflictBehaviorType.ChooseMax;
        public double CriticalValue { get; set; } = 0.65;
    }
}
