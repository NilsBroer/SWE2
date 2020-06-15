using System;
using System.Reflection;
using Serilog;

namespace PicDB.Helper
{
    ///
    /// Methods for Exception Handling
    ///
    public static class ExceptionHandling
    {
        ///
        /// Executes any Function inside a try/catch (Might be bad for Performance since Non-specific Exception handling is costly.)
        ///
        public static dynamic Try<T>(Func<T> getFunction /*(param)*/)
        {
            try
            {
                return getFunction(/*param*/);
            }
            catch (Exception e)
            {
                Log.Error("Error executing function '{m}'. Exception: {e}",
                    getFunction.GetMethodInfo()?.Name, e);
                throw;
            }
        }

        ///
        /// Executes any Function inside a try/catch (Might be bad for Performance since Non-specific Exception handling is costly.)
        ///
        public static void Try(Action getFunction)
        {
            try
            {
                getFunction();
            }
            catch (Exception e)
            {
                Log.Error("Error executing function '{m}'. Exception: {e}",
                    getFunction.GetMethodInfo()?.Name, e);
                throw;
            }
        }
    }
}