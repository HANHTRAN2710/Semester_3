﻿using Microsoft.Extensions.Logging;
using Semester_3.Models;
using Semester_3.Sơ_Vít.In_tơ_phây;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semester_3.Sơ_Vít.Ìm_le_mần_sơ_vít
{
    public class AdministrativeUnitCRUD : IServiceCRUD<AdministrativeUnit>
    {
        private readonly DatabaseContext _databaseContext;

        public AdministrativeUnitCRUD(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Create(AdministrativeUnit entity)
        {
            try
            {
                _databaseContext.AdministrativeUnits.Add(entity);
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
                var administrativeUnitEntity = _databaseContext.AdministrativeUnits.FirstOrDefault(a => a.Id == id);
                if (administrativeUnitEntity != null)
                {
                    _databaseContext.AdministrativeUnits.Remove(administrativeUnitEntity);
                    return _databaseContext.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public dynamic Get(int id) => _databaseContext.AdministrativeUnits.FirstOrDefault(a => a.Id == id);

        public dynamic Read() => _databaseContext.AdministrativeUnits.ToList();

        public bool Update(AdministrativeUnit entity)
        {
            try
            {
                _databaseContext.AdministrativeUnits.Update(entity);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
