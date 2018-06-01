using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Security.Permissions;

// http://www.dotnetfunda.com/articles/show/2307/custom-installation-using-setup-and-deployment-project

namespace Slider
{
    [RunInstaller(true)]
    public class ProjectInstall : Installer
    {
        [SecurityPermission(SecurityAction.Demand)]
        public override void Install(IDictionary savedState)
        {

        }
        [SecurityPermission(SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
        }
        [SecurityPermission(SecurityAction.Demand)]
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }
        [SecurityPermission(SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
        }
    }
}
