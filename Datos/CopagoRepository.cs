using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class CopagoRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Copago> _personas = new List<Copago>();
        public CopagoRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Copago copago)
        {
            using (var command = _connection.CreateCommand())
            {

                command.CommandText = @"Insert Into Copago (Identificacion,ValorHospitalizacion,Salario,ValorCopago) 
                                        values (@Identificacion,@ValorHospitalizacion,@Salario,@ValorCopago)";
                command.Parameters.AddWithValue("@Identificacion", copago.Identificacion);
                command.Parameters.AddWithValue("@ValorHospitalizacion", copago.ValorHospitalizacion);
                command.Parameters.AddWithValue("@Salario", copago.Salario);
                command.Parameters.AddWithValue("@ValorCopago", copago.ValorCopago);
                var filas = command.ExecuteNonQuery();
            }
        }

        public List<Copago> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Copago> copagos = new List<Copago>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from copago ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Copago copago = DataReaderMapToPerson(dataReader);
                        copagos.Add(copago);
                    }
                }
            }
            return copagos;
        }
        
        private Copago DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Copago copago = new Copago();
            copago.Identificacion = (string)dataReader["Identificacion"];
            copago.ValorHospitalizacion = (decimal)dataReader["ValorHospitalizacion"];
            copago.Salario = (decimal)dataReader["Salario"];
            copago.ValorCopago = (decimal)dataReader["ValorCopago"];  
            return copago;
        }
    }
}