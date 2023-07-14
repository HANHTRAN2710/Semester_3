using Microsoft.Extensions.Logging;
using Semester_3.Models;
using Semester_3.Sơ_Vít.In_tơ_phây;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semester_3.Sơ_Vít.Ìm_le_mần_sơ_vít
{
    public class WardCRUD : IServiceCRUD<Ward>
    {
        private readonly DatabaseContext _databaseContext;

        public WardCRUD(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Create(Ward entity)
        {
            try
            {
                _databaseContext.Wards.Add(entity);
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
                var wardEntity = _databaseContext.Wards.FirstOrDefault(w => w.Code == id);
                if (wardEntity != null)
                {
                    _databaseContext.Wards.Remove(wardEntity);
                    return _databaseContext.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public dynamic Get(int id) => _databaseContext.Wards.FirstOrDefault(w => w.Code == id);

        public dynamic Read() => _databaseContext.Wards.ToList();

        public bool Update(Ward entity)
        {
            try
            {
                _databaseContext.Wards.Update(entity);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
