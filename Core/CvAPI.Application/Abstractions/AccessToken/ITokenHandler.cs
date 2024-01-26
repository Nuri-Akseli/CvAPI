using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Abstractions.AccessToken
{
    public interface ITokenHandler
    {
        (string Token, DateTime Expires) CreateAccessToken(int minute);
        (string Token, DateTime Expires) CreateRefreshToken(DateTime tokenExpiresDate, int addedMinutes);
    }
}
