﻿using Microsoft.Extensions.Logging;
using Semester_3.Models;
using Semester_3.Sơ_Vít.In_tơ_phây;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semester_3.Sơ_Vít.Ìm_le_mần_sơ_vít
{
    public class OrderStatusCRUD : IServiceCRUD<OrderStatus>
    {
        private readonly DatabaseContext _databaseContext;

        public OrderStatusCRUD(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Create(OrderStatus entity)
        {
            try
            {
                _databaseContext.OrderStatuses.Add(entity);
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
                var orderStatusEntity = _databaseContext.OrderStatuses.FirstOrDefault(os => os.OrderStatusId == id);
                if (orderStatusEntity != null)
                {
                    _databaseContext.OrderStatuses.Remove(orderStatusEntity);
                    return _databaseContext.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public dynamic Get(int id) => _databaseContext.OrderStatuses.FirstOrDefault(os => os.OrderStatusId == id);

        public dynamic Read() => _databaseContext.OrderStatuses.ToList();

        public bool Update(OrderStatus entity)
        {
            try
            {
                _databaseContext.OrderStatuses.Update(entity);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
