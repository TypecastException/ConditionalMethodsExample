using System.Diagnostics;

namespace ConditionalMethodsExample.Properties 
{

    internal sealed partial class Settings 
    {
        public Settings() 
        {
            // Each method corrsponds to a build version. We call both methods, because
            // the conditional compilation will only compile the one indicated:
            this.SetLiveApplicationSettings();
            this.SetTestApplicationSettings();
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
