namespace UnityEditor.PackageManager.ValidationSuite
{
    public enum TestCategory
    {
        DataValidation,
        ApiValidation,
        ContentScan,
        TestValidation,
    }

    public interface IValidationTest
    {
        ValidationSuite Suite { get; }

        string TestName { get; }

        string TestDescription { get; }

        // Category mostly used for sorting tests, or grouping in UI.
        TestCategory TestCategory { get; }
    }
}
