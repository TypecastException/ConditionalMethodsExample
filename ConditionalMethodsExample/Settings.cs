using System;
using System.Diagnostics;

namespace ConditionalMethodsExample.Properties
{

    internal sealed partial class Settings
    {
        public Settings()
        {
            // Each method corrsponds to a build version. We call all four methods, because
            // the conditional compilation will only compile the one indicated:
            this.SetDebugApplicationSettings();
            this.SetReleaseApplicationSettings();
            this.SetLiveApplicationSettings();
            this.SetTestApplicationSettings();
        }

        [Conditional("DEBUG")]
        private void SetDebugApplicationSettings()
        {
            // Set the two Settings values to use the resource files designated
            // for the DEBUG version of the app:
            this["BuildVersionMessage"] = "This is the Debug Build";
            this["OutputFolderPath"] = Environment.CurrentDirectory + @"\Debug Output Folder\";
        }


        [Conditional("RELEASE")]
        private void SetReleaseApplicationSettings()
        {
            // Set the two Settings values to use the resource files designated
            // for the RELEASE version of the app:
            this["BuildVersionMessage"] = "This is the Release Build";
            this["OutputFolderPath"] = Environment.CurrentDirectory + @"\Release Output Folder\";
        }


        [Conditional("LIVE")]
        private void SetLiveApplicationSettings()
        {
            // Set the two Settings values to use the resource files designated
            // for the LIVE version of the app:
            this["BuildVersionMessage"] = Resources.LiveVersionMessage;
            this["OutputFolderPath"] = Resources.LiveOutputFolderPath;
        }


        [Conditional("TEST")]
        private void SetTestApplicationSettings()
        {
            // Set the two Settings values to use the resource files designated
            // for the TEST version of the app:
            this["BuildVersionMessage"] = Resources.TestVersionMessage;
            this["OutputFolderPath"] = Resources.TestOutputFolderPath;
        }
    }
}