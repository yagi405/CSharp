﻿using System;
using System.Data;

namespace NetOfficePoc.Db
{
    public static class DbCommandExtensions
    {
        public static void AddParameter<T>(this IDbCommand self, string parameterName, T value)
        {
            var param = self.CreateParameter();
            param.ParameterName = parameterName;
            if (value == null)
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = value;
            }

            self.Parameters.Add(param);
        }
    }
}
