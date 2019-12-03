using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ifsc.tcc.Portal.Application.AdvisorModule.Models.Commands;
using ifsc.tcc.Portal.Domain.AdvisorModule;
using Microsoft.IdentityModel.Tokens;

namespace ifsc.tcc.Portal.Application.AdvisorModule
{
    public interface IAdvisorAppService
    {
        Task<Advisor> AuthenticateAsync(AuthenticateCommand command);
    }

    public class AdvisorAppService : BaseAppService<IAdvisorRepository>, IAdvisorAppService
    {
        public AdvisorAppService(IAdvisorRepository repository)
            : base(repository)
        { }

        public async Task<Advisor> AuthenticateAsync(AuthenticateCommand command)
        {
            var advisor = await Repository.GetByUsernameAndPasswordAsync(command.Login, command.Password);

            if (advisor == null) { return null; }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("1312358653DF49C98DC841974DB3D775");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, advisor.ID.ToString()),
                    new Claim(ClaimTypes.Role, "admin")
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            advisor.SetToken(tokenHandler.WriteToken(token));

            advisor.SetPassword("");

            return advisor;
        }
    }
}
