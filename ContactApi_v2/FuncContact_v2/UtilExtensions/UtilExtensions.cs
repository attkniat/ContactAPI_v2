using System;

namespace FuncContact_v2.UtilExtensions
{
    public static class UtilExtensions
    {
        public static void Execute(this object instance, Action action, string module, string opetation)
        {
            try
            {
                Console.WriteLine($"{module} - {opetation}");
                action();
                Console.WriteLine($"{module} - {opetation} - SUCCESS!");
            }
            catch (Exception e)
            {
                throw new Exception($"{module} - {opetation} - ERROR", e);
            }
        }
    }
}