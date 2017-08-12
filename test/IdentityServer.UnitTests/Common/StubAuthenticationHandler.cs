// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace IdentityServer4.UnitTests.Common
{
    public class StubAuthenticationHandlerOptions : AuthenticationSchemeOptions
    {
        public ClaimsPrincipal User { get; set; }
        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
    }
    public class StubAuthenticationHandler : 
        AuthenticationHandler<StubAuthenticationHandlerOptions>,  IAuthenticationSignInHandler
    {
        public StubAuthenticationHandler(IOptionsMonitor<StubAuthenticationHandlerOptions> options) 
            : base(options, new LoggerFactory(), UrlEncoder.Default, new SystemClock())
        {

        }

        public Task SignInAsync(ClaimsPrincipal user, AuthenticationProperties properties)
        {
          
            return Task.CompletedTask;
        }

        public Task SignOutAsync(AuthenticationProperties properties)
        {
            return Task.CompletedTask;
        }

        // public ClaimsPrincipal User { get; set; }
        //  public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
        //public string Scheme { get; set; }

        //public StubAuthenticationHandler(, string scheme)
        //{
        //    User = user;
        //    Scheme = scheme;
        //}

        //public Task AuthenticateAsync(AuthenticateContext context)
        //{
        //    if (Options.User == null)
        //    {
        //        context.NotAuthenticated();
        //    }
        //    else if (Scheme == null || Scheme.Name == context.AuthenticationScheme)
        //    {
        //        context.Authenticated(Options.User, Properties, new Dictionary<string, object>());
        //    }

        //    return Task.FromResult(0);
        //}

        //public Task ChallengeAsync(ChallengeContext context)
        //{
        //    if (Scheme == null || context.AuthenticationScheme == Scheme.Name)
        //    {
        //        context.Accept();
        //    }

        //    return Task.FromResult(0);
        //}

        //public void GetDescriptions(DescribeSchemesContext context)
        //{
        //}

        //public Task SignInAsync(SignInContext context)
        //{
        //    if (Scheme == null || context.AuthenticationScheme == Scheme.Name)
        //    {
        //        context.Accept();
        //    }

        //    return Task.FromResult(0);
        //}

        //public Task SignOutAsync(SignOutContext context)
        //{
        //    if (Scheme == null || context.AuthenticationScheme == Scheme.Name)
        //    {
        //        context.Accept();
        //    }

        //    return Task.FromResult(0);
        //}

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (Options.User == null)
            {
                return Task.FromResult(AuthenticateResult.Fail("Not Authenticated"));
            }
         
                return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(Options.User,
                    new AuthenticationProperties(Options.Properties),Scheme.Name)));

               // context.Authenticated(Options.User, Properties, new Dictionary<string, object>());
            
        }
    }
}
