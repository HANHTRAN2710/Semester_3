﻿using Microsoft.Extensions.Logging;
using Semester_3.Models;
using Semester_3.Sơ_Vít.In_tơ_phây;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semester_3.Sơ_Vít.Ìm_le_mần_sơ_vít
{
    public class ProductImageCRUD : IServiceCRUD<ProductImage>
    {
        private readonly DatabaseContext _databaseContext;

        public ProductImageCRUD(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Create(ProductImage entity)
        {
            try
            {
                _databaseContext.ProductImages.Add(entity);
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
                var productImageEntity = _databaseContext.ProductImages.FirstOrDefault(pi => pi.ImageId == id);
                if (productImageEntity != null)
                {
                    _databaseContext.ProductImages.Remove(productImageEntity);
                    return _databaseContext.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public dynamic Get(int id) => _databaseContext.ProductImages.FirstOrDefault(pi => pi.ImageId == id);

        public dynamic Read() => _databaseContext.ProductImages.ToList();

        public bool Update(ProductImage entity)
        {
            try
            {
                _databaseContext.ProductImages.Update(entity);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
