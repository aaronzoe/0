using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Web;

namespace WebService.ServiceInterface
{
    public class CustomCredentialsAuthProvider : CredentialsAuthProvider
    {

        public override IHttpResult OnAuthenticated(IServiceBase authService, IAuthSession session, IAuthTokens tokens, Dictionary<string, string> authInfo)
        {
            session.ReferrerUrl = authService.Request.GetParam("redirect");
            return base.OnAuthenticated(authService, session, tokens, authInfo);
        }
        public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
        {
            var authRepo = authService.TryResolve<IAuthRepository>().AsUserAuthRepository(authService.GetResolver());

            var session = authService.GetSession();
            IUserAuth userAuth;
            if (authRepo.TryAuthenticate(userName, password, out userAuth))
            {
                if (IsAccountLocked(authRepo, userAuth))
                    return false;
                // throw new AuthenticationException("This account has been locked");

                var holdSessionId = session.Id;
                session.PopulateWith(userAuth); //overwrites session.Id
                session.Id = holdSessionId;
                session.IsAuthenticated = true;
                session.UserAuthId = userAuth.Id.ToString(CultureInfo.InvariantCulture);
                session.ProviderOAuthAccess = authRepo.GetUserAuthDetails(session.UserAuthId)
                    .ConvertAll(x => (IAuthTokens)x);

                return true;
            }

            return false;
        }
    }
}