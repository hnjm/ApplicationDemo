﻿namespace Application
{
    using Framework.Server.Application;
    using System;

    public class Application : ApplicationBase
    {
        protected override void ProcessInit(ProcessList processList)
        {
            base.ProcessInit(processList);
            processList.AddBefore<ProcessGridMasterIsClick, ProcessGridIsClickFalse>();
        }

        protected override Type TypePageMain()
        {
            return typeof(PageMain);
        }
    }
}
