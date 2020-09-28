using System;
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
    public class ObraSocialQuery : IObraSocialQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public ObraSocialQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<ResponseObraSocialDTO> GetAllObrasSociales()
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("ObrasSociales");

            var result = query.Get<ResponseObraSocialDTO>();

            return result.ToList();
        }

        public ResponseObraSocialDTO GetById(int id)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("ObrasSociales")
                .Where("ObraSocial_Id", "=", id);

            return query.FirstOrDefault<ResponseObraSocialDTO>();
        }
    }
}
