using Microsoft.Extensions.Logging;
using Semester_3.Models;
using Semester_3.Sơ_Vít.In_tơ_phây;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semester_3.Sơ_Vít.Ìm_le_mần_sơ_vít
{
    public class ProvinceCRUD : IServiceCRUD<Province>
    {
        private readonly DatabaseContext _databaseContext;

        public ProvinceCRUD(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Create(Province entity)
        {
            try
            {
                _databaseContext.Provinces.Add(entity);
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
                var provinceEntity = _databaseContext.Provinces.FirstOrDefault(p => p.Code == id.ToString());
                if (provinceEntity != null)
                {
                    _databaseContext.Provinces.Remove(provinceEntity);
                    return _databaseContext.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public dynamic Get(int id) => _databaseContext.Provinces.FirstOrDefault(p => p.Code == id.ToString());

        public dynamic Read() => _databaseContext.Provinces.ToList();

        public bool Update(Province entity)
        {
            try
            {
                _databaseContext.Provinces.Update(entity);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
