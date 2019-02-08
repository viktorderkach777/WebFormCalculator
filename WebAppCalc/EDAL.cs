using System;
using System.Collections.Generic;
using System.Linq;
using WebAppCalc.Models;

namespace WebAppCalc
{
    public class EDAL : IDAL
    {
        private readonly Library _ctx = new Library();

        public bool ClearExchangeRates()
        {
            if (_ctx.Rates.Count() > 0)
            {
                _ctx.Rates.RemoveRange(_ctx.Rates);
                _ctx.SaveChanges();
            }

            if (_ctx.Rates.Count() == 0)
            {
                return true;
            }
            return false;
        }

        public bool ClearExpressions()
        {
            if (_ctx.Expressions.Count()>0)
            {
                _ctx.Expressions.RemoveRange(_ctx.Expressions);
                _ctx.SaveChanges();
            }    

            if (_ctx.Expressions.Count() == 0)
            {
                return true;
            }
            return false;
        }

        public bool DBUserSaveCredentials(string fullName, string userName, string email, string password)
        {
            var number = _ctx.DBUsers.Count();

            if (!String.IsNullOrEmpty(fullName) && !String.IsNullOrEmpty(userName) && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password))
            {
                _ctx.DBUsers.Add(new Models.DBUser() { FullName = fullName, UserName = userName, Email = email, Password = password });
                _ctx.SaveChanges();

                return _ctx.DBUsers.Count() > number;
            }

            return false;
        }

        public ICollection<Expression> GetAllExpressions()
        {
            return _ctx.Expressions.ToList();
        }

        public ICollection<ExchangeRates> GetAllRates()
        {
            return _ctx.Rates.ToList();
        }

        public bool IsUserNameInDb(string userNameOrEmail)
        {
            bool IsUser = false;

            if (!String.IsNullOrEmpty(userNameOrEmail))
            {
                try
                {
                    if (userNameOrEmail.Contains('@'))
                    {
                        Models.DBUser user = _ctx.DBUsers.First(u => u.Email == userNameOrEmail);
                        IsUser = true;
                    }
                    else
                    {
                        Models.DBUser user = _ctx.DBUsers.First(u => u.UserName == userNameOrEmail);
                        IsUser = true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return IsUser;
        }

        public bool IsUserNameInDb(string userNameOrEmail, string password)
        {
            bool IsUser = false;

            if (!String.IsNullOrEmpty(userNameOrEmail) && !String.IsNullOrEmpty(password))
            {
                try
                {
                    if (userNameOrEmail.Contains('@'))
                    {
                        Models.DBUser user = _ctx.DBUsers.First(u => u.Email == userNameOrEmail && u.Password == password);
                        IsUser = true;
                    }
                    else
                    {
                        Models.DBUser user = _ctx.DBUsers.First(u => u.UserName == userNameOrEmail && u.Password == password);
                        IsUser = true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return IsUser;
        }

        public bool SaveExpression(string line)
        {
            var number = _ctx.Expressions.Count();

            if (!String.IsNullOrEmpty(line) && line.Contains("="))
            {
                _ctx.Expressions.Add(new Models.Expression() { Line = line });
                _ctx.SaveChanges();

                return _ctx.Expressions.Count() > number;
            }

            return false;
        }

        public bool SaveRate(ExchangeRates rate)
        {
            var number = _ctx.Rates.Count();

            if (rate!=null)
            {
                _ctx.Rates.Add(new ExchangeRates() {
                    Id = rate.Id,
                    CurrencyName=rate.CurrencyName,
                    DigitalCode=rate.DigitalCode,
                    LetterCode=rate.LetterCode,
                    NumberOfUnits=rate.NumberOfUnits,
                    OfficialExchangeRates=rate.OfficialExchangeRates
                });
                _ctx.SaveChanges();

                return _ctx.Rates.Count() > number;
            }

            return false;
        }
    }
}