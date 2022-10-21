﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public partial class GestorRRHHContext
    {
        private IGestorRRHHContextProcedures _procedures;

        public virtual IGestorRRHHContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new GestorRRHHContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IGestorRRHHContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<sp_loginResult>().HasNoKey().ToView(null);
        }
    }

    public partial class GestorRRHHContextProcedures : IGestorRRHHContextProcedures
    {
        private readonly GestorRRHHContext _context;

        public GestorRRHHContextProcedures(GestorRRHHContext context)
        {
            _context = context;
        }

        public virtual async Task<int> sp_cambio_claveAsync(string i_usuario, string i_clave_a, string i_clave_n, OutputParameter<long?> o_codigo, OutputParameter<string> o_mensaje, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parametero_codigo = new SqlParameter
            {
                ParameterName = "o_codigo",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = o_codigo?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.BigInt,
            };
            var parametero_mensaje = new SqlParameter
            {
                ParameterName = "o_mensaje",
                Size = 128,
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = o_mensaje?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.VarChar,
            };
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "i_usuario",
                    Size = 50,
                    Value = i_usuario ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "i_clave_a",
                    Size = 50,
                    Value = i_clave_a ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "i_clave_n",
                    Size = 50,
                    Value = i_clave_n ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parametero_codigo,
                parametero_mensaje,
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[sp_cambio_clave] @i_usuario, @i_clave_a, @i_clave_n, @o_codigo OUTPUT, @o_mensaje OUTPUT", sqlParameters, cancellationToken);

            o_codigo.SetValue(parametero_codigo.Value);
            o_mensaje.SetValue(parametero_mensaje.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<sp_loginResult>> sp_loginAsync(string i_usuario, string i_clave, OutputParameter<string> o_name, OutputParameter<long?> o_codigo, OutputParameter<string> o_mensaje, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parametero_name = new SqlParameter
            {
                ParameterName = "o_name",
                Size = 256,
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = o_name?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.VarChar,
            };
            var parametero_codigo = new SqlParameter
            {
                ParameterName = "o_codigo",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = o_codigo?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.BigInt,
            };
            var parametero_mensaje = new SqlParameter
            {
                ParameterName = "o_mensaje",
                Size = 256,
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = o_mensaje?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.VarChar,
            };
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "i_usuario",
                    Size = 75,
                    Value = i_usuario ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "i_clave",
                    Size = 75,
                    Value = i_clave ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parametero_name,
                parametero_codigo,
                parametero_mensaje,
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<sp_loginResult>("EXEC @returnValue = [dbo].[sp_login] @i_usuario, @i_clave, @o_name OUTPUT, @o_codigo OUTPUT, @o_mensaje OUTPUT", sqlParameters, cancellationToken);

            o_name.SetValue(parametero_name.Value);
            o_codigo.SetValue(parametero_codigo.Value);
            o_mensaje.SetValue(parametero_mensaje.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> sp_nueva_claveAsync(string i_usuario, string i_otp, string i_clave_a, string i_clave_n, OutputParameter<long?> o_codigo, OutputParameter<string> o_mensaje, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parametero_codigo = new SqlParameter
            {
                ParameterName = "o_codigo",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = o_codigo?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.BigInt,
            };
            var parametero_mensaje = new SqlParameter
            {
                ParameterName = "o_mensaje",
                Size = 128,
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = o_mensaje?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.VarChar,
            };
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "i_usuario",
                    Size = 50,
                    Value = i_usuario ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "i_otp",
                    Size = 50,
                    Value = i_otp ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "i_clave_a",
                    Size = 50,
                    Value = i_clave_a ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "i_clave_n",
                    Size = 50,
                    Value = i_clave_n ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parametero_codigo,
                parametero_mensaje,
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[sp_nueva_clave] @i_usuario, @i_otp, @i_clave_a, @i_clave_n, @o_codigo OUTPUT, @o_mensaje OUTPUT", sqlParameters, cancellationToken);

            o_codigo.SetValue(parametero_codigo.Value);
            o_mensaje.SetValue(parametero_mensaje.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}