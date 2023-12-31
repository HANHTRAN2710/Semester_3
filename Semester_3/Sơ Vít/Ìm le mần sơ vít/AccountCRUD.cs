﻿using Microsoft.Extensions.Logging;
using Semester_3.Models;
using Semester_3.Sơ_Vít.In_tơ_phây;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semester_3.Sơ_Vít.Ìm_le_mần_sơ_vít
{
    public class AccountCRUD : IServiceCRUD<Account>
    {
        private readonly DatabaseContext _databaseContext;

        public AccountCRUD(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Create(Account entity)
        {
            try
            {
                _databaseContext.Accounts.Add(entity);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var accountEntity = _databaseContext.Accounts.FirstOrDefault(a => a.AccountId == id);
                if (accountEntity != null)
                {
                    _databaseContext.Accounts.Remove(accountEntity);
                    return _databaseContext.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public dynamic Get(int id) => _databaseContext.Accounts.FirstOrDefault(a => a.AccountId == id);

        public dynamic Read() => _databaseContext.Accounts.ToList();

        public bool Update(Account entity)
        {
            try
            {
                _databaseContext.Accounts.Update(entity);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
