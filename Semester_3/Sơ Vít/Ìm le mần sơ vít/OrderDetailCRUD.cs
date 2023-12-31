﻿using Microsoft.Extensions.Logging;
using Semester_3.Models;
using Semester_3.Sơ_Vít.In_tơ_phây;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semester_3.Sơ_Vít.Ìm_le_mần_sơ_vít
{
    public class OrderDetailCRUD : IServiceCRUD<OrderDetail>
    {
        private readonly DatabaseContext _databaseContext;

        public OrderDetailCRUD(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Create(OrderDetail entity)
        {
            try
            {
                _databaseContext.OrderDetails.Add(entity);
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
                var orderDetailEntity = _databaseContext.OrderDetails.FirstOrDefault(od => od.OrderDetailId == id);
                if (orderDetailEntity != null)
                {
                    _databaseContext.OrderDetails.Remove(orderDetailEntity);
                    return _databaseContext.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public dynamic Get(int id) => _databaseContext.OrderDetails.FirstOrDefault(od => od.OrderDetailId == id);

        public dynamic Read() => _databaseContext.OrderDetails.ToList();

        public bool Update(OrderDetail entity)
        {
            try
            {
                _databaseContext.OrderDetails.Update(entity);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
