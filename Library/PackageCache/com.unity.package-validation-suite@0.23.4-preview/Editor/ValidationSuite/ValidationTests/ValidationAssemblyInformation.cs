using System.Linq;
using UnityEditor.Compilation;

namespace UnityEditor.PackageManager.ValidationSuite.ValidationTests
{
    /// <summary>
    /// Used by tests to override assembly information for ApiValidation
    /// </summary>
    internal class ValidationAssemblyInformation
    {
        public bool? isPreviousPackageTestOverride;
        public bool? isProjectPackageTestOverride;

        public string previousAssemblyNameOverride { get; private set; }
        public string projectAssemblyNameOverride { get; private set; }

        public ValidationAssemblyInformation()
        { }

        public ValidationAssemblyInformation(bool? isPreviousPackageTestOverride, bool? isProjectPackageTestOverride, string previousAssemblyNameOverride, string projectAssemblyNameOverride)
        {
            this.isPreviousPackageTestOverride = isPreviousPackageTestOverride;
            this.isProjectPackageTestOverride = isProjectPackageTestOverride;
            this.previousAssemblyNameOverride = previousAssemblyNameOverride;
            this.projectAssemblyNameOverride = projectAssemblyNameOverride;
        }

        public virtual bool IsTestAssembly(AssemblyInfo assembly)
        {
            if (isProjectPackageTestOverride.HasValue)
                return isProjectPackageTestOverride.Value;

            return Utilities.IsTestAssembly(assembly.assembly);
        }

        public string GetAssemblyName(Assembly assembly, bool isPrevious)
        {
            return GetOverriddenAssemblyName(isPrevious) ?? assembly.name;
        }

        public string GetAssemblyName(AssemblyDefinition assembly, bool isPrevious)
        {
            return GetOverriddenAssemblyName(isPrevious) ?? assembly.name;
        }

        private string GetOverriddenAssemblyName(bool isPrevious)
        {
            if (isPrevious && previousAssemblyNameOverride != null)
                return previousAssemblyNameOverride;
            if (!isPrevious && projectAssemblyNameOverride != null)
                return projectAssemblyNameOverride;

            return null;
        }
    }
}
