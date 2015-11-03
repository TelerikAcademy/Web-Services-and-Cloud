namespace SourceControlSystem.Api.Tests.TestObjects
{
    using System;
    using System.Security.Principal;

    public class MockedIIdentity : IIdentity
    {
        public string AuthenticationType
        {
            get
            {
                return string.Empty;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get
            {
                return "Test User";
            }
        }
    }
}
