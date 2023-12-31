﻿using Microsoft.Extensions.Logging;
using Semester_3.Models;
using Semester_3.Sơ_Vít.In_tơ_phây;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semester_3.Sơ_Vít.Ìm_le_mần_sơ_vít
{
    public class OrderCRUD : IServiceCRUD<Order>
    {
        private readonly DatabaseContext _databaseContext;

        public OrderCRUD(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Create(Order entity)
        {
            try
            {
                _databaseContext.Orders.Add(entity);
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
                var orderEntity = _databaseContext.Orders.FirstOrDefault(o => o.OrderId == id);
                if (orderEntity != null)
                {
                    _databaseContext.Orders.Remove(orderEntity);
                    return _databaseContext.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public dynamic Get(int id) => _databaseContext.Orders.FirstOrDefault(o => o.OrderId == id);

        public dynamic Read() => _databaseContext.Orders.ToList();

        public bool Update(Order entity)
        {
            try
            {
                _databaseContext.Orders.Update(entity);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
