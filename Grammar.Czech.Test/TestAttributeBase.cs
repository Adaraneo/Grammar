using System.Reflection;
using System.Text;

namespace Grammar.Czech.Test
{
    /// <summary>
    /// Provides shared behavior for custom MSTest data attributes.
    /// </summary>
    internal abstract class TestAttributeBase : Attribute, ITestDataSource
    {
        /// <summary>
        /// Provides data rows for a parameterized MSTest method.
        /// </summary>
        /// <param name="methodInfo">The test method requesting data.</param>
        /// <returns>The test data rows for the requested method.</returns>
        public abstract IEnumerable<object?[]> GetData(MethodInfo methodInfo);

        /// <summary>
        /// Builds a display name for a parameterized MSTest data row.
        /// </summary>
        /// <param name="methodInfo">The test method requesting data.</param>
        /// <param name="data">The test case data used to build the display name.</param>
        /// <returns>The display name used by the test runner.</returns>
        public virtual string? GetDisplayName(MethodInfo methodInfo, object?[]? data)
        {
            if (data is not null)
            {
                var sb = new StringBuilder();
                foreach (var d in data)
                {
                    sb.AppendFormat("{0}", string.Join(",", d.ToString()));
                }

                return string.Format("{0} ({1})", methodInfo.Name, sb.ToString());
            }

            return methodInfo.Name;
        }
    }
}
