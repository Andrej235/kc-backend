using System.Diagnostics;

namespace kc_backend.Utilities
{
    public static class LogDebugger
    {
        public static void LogError(this Exception ex, bool includeStackTrace = true) => Debug.WriteLine(ex.GetErrorMessage(includeStackTrace));

        public static string GetErrorMessage(this Exception ex, bool includeStackTrace = false) => includeStackTrace
                ? ex.InnerException is null
                    ? $"---> Error occurred: {ex.Message}\n{ex.StackTrace}\n"
                    : $"---> Error occurred: {ex.Message}\n{ex.InnerException.Message}\n{ex.StackTrace}\n"
                : ex.InnerException is null
                    ? $"---> Error occurred: {ex.Message}"
                    : $"---> Error occurred: {ex.Message}\n{ex.InnerException.Message}";
    }
}
