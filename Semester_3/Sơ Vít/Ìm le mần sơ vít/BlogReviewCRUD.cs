﻿using Microsoft.Extensions.Logging;
using Semester_3.Models;
using Semester_3.Sơ_Vít.In_tơ_phây;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Semester_3.Sơ_Vít.Ìm_le_mần_sơ_vít
{
    public class BlogReviewCRUD : IServiceCRUD<BlogReview>
    {
        private readonly DatabaseContext _databaseContext;

        public BlogReviewCRUD(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Create(BlogReview entity)
        {
            try
            {
                _databaseContext.BlogReviews.Add(entity);
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
                var blogReviewEntity = _databaseContext.BlogReviews.FirstOrDefault(br => br.BlogReviewId == id);
                if (blogReviewEntity != null)
                {
                    _databaseContext.BlogReviews.Remove(blogReviewEntity);
                    return _databaseContext.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public dynamic Get(int id) => _databaseContext.BlogReviews.FirstOrDefault(br => br.BlogReviewId == id);

        public dynamic Read() => _databaseContext.BlogReviews.ToList();

        public bool Update(BlogReview entity)
        {
            try
            {
                _databaseContext.BlogReviews.Update(entity);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
