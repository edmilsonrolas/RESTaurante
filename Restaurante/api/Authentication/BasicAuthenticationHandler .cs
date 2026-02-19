// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Net.Http.Headers;
// using System.Text;
// using System.Text.Encodings.Web;
// using System.Threading.Tasks;
// using api.Data;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.CodeAnalysis.Options;
// using Microsoft.Extensions.Options;

// namespace api.Authentication
// {
//     public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
//     {
//         private readonly ApplicationDBContext _context;

//         public BasicAuthenticationHandler (
//             IOptionsMonitor<AuthenticationSchemeOptions> options, 
//             ILoggerFactory logger, 
//             UrlEncoder encoder, 
//             ApplicationDBContext context)
//         : base (options, logger, encoder)
//         {
//             _context = context;
//         }

//         protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
//         {
//             try
//             {
//                 // Verificar se existe header Authorization
//                 if (!Request.Headers.ContainsKey("Authorization"))
//                     return AuthenticateResult.Fail("Sem Header de Autorizacao");

//                 // Ler header
//                 var authorizationHeader = Request.Headers["Authorization"].ToString();

//                 if (!AuthenticationHeaderValue.TryParse(authorizationHeader, out var headerValue))
//                     return AuthenticateResult.Fail("Header de Autorizacao invalido");

//                 if (!"Basic".Equals(headerValue.Scheme, StringComparison.OrdinalIgnoreCase))
//                     return AuthenticateResult.Fail("Authorization Scheme invalido");

//                 var credentialBytes = Convert.FromBase64String(headerValue.Parameter!);
//                 var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);


//                 //continua em https://dotnettutorials.net/lesson/basic-authentication-in-asp-net-core-web-api/
//             }
//         }
//     }
// }