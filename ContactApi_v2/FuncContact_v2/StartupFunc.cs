﻿using FuncContact_v2.ConstantsFunc;
using FuncContact_v2.ContactsRepository;
using FuncContact_v2.UtilExtensions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FuncContact_v2.StartupFunc))]

namespace FuncContact_v2
{
    public class StartupFunc : FunctionsStartup
    {
        private readonly string _module = typeof(StartupFunc).Assembly.GetName().Name ?? "<NO NAME>";

        public override void Configure(IFunctionsHostBuilder builder)
        {
            this.Execute(CreateQueuesFunction, _module, "Checking the queues to the function");
        }

        private void CreateQueuesFunction()
        {
            var connStr = Constants.ConnStrFunc;
            var asm = typeof(StartupFunc).Assembly;
            var adm = new AdminQueueService(connStr);

            adm.CreateQueuesFunction();
        }
    }
}
