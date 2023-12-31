﻿using Microsoft.Extensions.Logging;
using Semester_3.Models;
using Semester_3.Sơ_Vít.In_tơ_phây;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semester_3.Sơ_Vít.Ìm_le_mần_sơ_vít
{
    public class RoleCRUD : IServiceCRUD<Role>
    {
        private readonly DatabaseContext _databaseContext;

        public RoleCRUD(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Create(Role entity)
        {
            try
            {
                _databaseContext.Roles.Add(entity);
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
                var roleEntity = _databaseContext.Roles.FirstOrDefault(r => r.RoleId == id);
                if (roleEntity != null)
                {
                    _databaseContext.Roles.Remove(roleEntity);
                    return _databaseContext.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public dynamic Get(int id) => _databaseContext.Roles.FirstOrDefault(r => r.RoleId == id);

        public dynamic Read() => _databaseContext.Roles.ToList();

        public bool Update(Role entity)
        {
            try
            {
                _databaseContext.Roles.Update(entity);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
