﻿using Microsoft.Extensions.Logging;
using Semester_3.Models;
using Semester_3.Sơ_Vít.In_tơ_phây;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semester_3.Sơ_Vít.Ìm_le_mần_sơ_vít
{
    public class WishlistCRUD : IServiceCRUD<Wishlist>
    {
        private readonly DatabaseContext _databaseContext;

        public WishlistCRUD(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Create(Wishlist entity)
        {
            try
            {
                _databaseContext.Wishlists.Add(entity);
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
                var wishlistEntity = _databaseContext.Wishlists.FirstOrDefault(w => w.WishlistId == id);
                if (wishlistEntity != null)
                {
                    _databaseContext.Wishlists.Remove(wishlistEntity);
                    return _databaseContext.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public dynamic Get(int id) => _databaseContext.Wishlists.FirstOrDefault(w => w.WishlistId == id);

        public dynamic Read() => _databaseContext.Wishlists.ToList();

        public bool Update(Wishlist entity)
        {
            try
            {
                _databaseContext.Wishlists.Update(entity);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
