using System;
using System.Reflection;
using Serilog;

namespace PicDB.Helper
{
    public static class ExceptionHandling
    {
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