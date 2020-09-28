﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TP_Domain.DTOs;
using TP_Domain.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Linq;

namespace TP_AccessData.Queries
{
    public class PacienteQuery : IPacienteQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public PacienteQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }


        public List<ResponsePacienteDTO> GetAllPacientes()
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Pacientes");

            var result = query.Get<ResponsePacienteDTO>();

            return result.ToList();
        }

        public ResponsePacienteDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}