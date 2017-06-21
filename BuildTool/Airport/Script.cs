﻿namespace BuildTool.Airport
{
    using Framework.BuildTool;

    public class Script
    {
        /// <summary>
        /// Load Airport.xlsx into database.
        /// </summary>
        public static void Run()
        {
            string connectionString = Framework.Server.ConnectionManager.ConnectionString;
            string fileName = Framework.Util.FolderName + "Submodule/Office/bin/Debug/Office.exe";
            // SqlDrop
            {
                string command = "SqlDrop";
                string arguments = command + " " + "\"" + connectionString + "\"";
                UtilBuildTool.Start(Framework.Util.FolderName, fileName, arguments);
            }
            // SqlCreate
            {
                string command = "SqlCreate";
                string arguments = command + " " + "\"" + connectionString + "\"";
                UtilBuildTool.Start(Framework.Util.FolderName, fileName, arguments);
            }
            // Run
            {
                string command = "Run";
                string folderName = Framework.Util.FolderName + "Build/Airport/";
                string arguments = command + " " + "\"" + connectionString + "\"" + " " + "\"" + folderName + "\"";
                UtilBuildTool.Start(Framework.Util.FolderName, fileName, arguments);
            }
        }
    }
}