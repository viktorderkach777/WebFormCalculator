using System.Collections.Generic;
using WebAppCalc.Models;

namespace WebAppCalc
{
    public interface IDAL
    {
        bool DBUserSaveCredentials(string fullName, string userName, string email, string password);
        ICollection<Expression> GetAllExpressions();
        bool IsUserNameInDb(string userNameOrEmail);
        bool IsUserNameInDb(string userNameOrEmail, string password);
        bool SaveExpression(string line);
        ICollection<ExchangeRates> GetAllRates();
        bool SaveRate(ExchangeRates rate);
        bool ClearExpressions();
        bool ClearExchangeRates();
    }
}
