﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Domain.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        int Add(TEntity obj);
        TEntity Get(TEntity obj);        
        IEnumerable<TEntity> GetAll();
        int Update(TEntity obj);
        int Remove(int id);
        void Dispose();
    }
}
