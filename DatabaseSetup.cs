using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TeamSystem.Data.UnitTesting;

namespace 背了再上
{
    [TestClass()]
    public class DatabaseSetup
    {

        [AssemblyInitialize()]
        public static void IntializeAssembly(TestContext ctx)
        {
            // 根據組態檔中的設定來設定
            // 測試資料庫
            DatabaseTestClass.TestService.DeployDatabaseProject();
            DatabaseTestClass.TestService.GenerateData();
        }

    }
}
