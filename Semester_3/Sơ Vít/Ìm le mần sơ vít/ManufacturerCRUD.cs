using Microsoft.Extensions.Logging;
using Semester_3.Models;
using Semester_3.Sơ_Vít.In_tơ_phây;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semester_3.Sơ_Vít.Ìm_le_mần_sơ_vít
{
    public class ManufacturerCRUD : IServiceCRUD<Manufacturer>
    {
        private readonly DatabaseContext _databaseContext;

        public ManufacturerCRUD(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Create(Manufacturer entity)
        {
            try
            {
                _databaseContext.Manufacturers.Add(entity);
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
                var manufacturerEntity = _databaseContext.Manufacturers.FirstOrDefault(m => m.MftId == id);
                if (manufacturerEntity != null)
                {
                    _databaseContext.Manufacturers.Remove(manufacturerEntity);
                    return _databaseContext.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public dynamic Get(int id) => _databaseContext.Manufacturers.FirstOrDefault(m => m.MftId == id);

        public dynamic Read() => _databaseContext.Manufacturers.ToList();

        public bool Update(Manufacturer entity)
        {
            try
            {
                _databaseContext.Manufacturers.Update(entity);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
