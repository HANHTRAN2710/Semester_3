using Microsoft.Extensions.Logging;
using Semester_3.Models;
using Semester_3.Sơ_Vít.In_tơ_phây;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semester_3.Sơ_Vít.Ìm_le_mần_sơ_vít
{
    public class CartDetailCRUD : IServiceCRUD<CartDetail>
    {
        private readonly DatabaseContext _databaseContext;

        public CartDetailCRUD(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Create(CartDetail entity)
        {
            try
            {
                _databaseContext.CartDetails.Add(entity);
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
                var cartDetailEntity = _databaseContext.CartDetails.FirstOrDefault(cd => cd.CartDetailId == id);
                if (cartDetailEntity != null)
                {
                    _databaseContext.CartDetails.Remove(cartDetailEntity);
                    return _databaseContext.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public dynamic Get(int id) => _databaseContext.CartDetails.FirstOrDefault(cd => cd.CartDetailId == id);

        public dynamic Read() => _databaseContext.CartDetails.ToList();

        public bool Update(CartDetail entity)
        {
            try
            {
                _databaseContext.CartDetails.Update(entity);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
