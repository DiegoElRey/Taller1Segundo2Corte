using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Entity;
using System.Linq;

namespace DAL
{
    public class PersonaRepository 
    {
        private SqlConnection _connection;
        private List<Persona> _personas;

        public PersonaRepository(ConnectionManager conection)
        {
            _connection = conection._connection;
            _personas = new List<Persona>();
        }

        public void GuardarPersona(Persona persona)
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO persona(Identificacion,Nombre,apellido,Sexo,Edad,Departamento,Ciudad,ValorApoyo,modalidad,Fecha)Values"+
                    "(@Identificacion,@Nombre,@apellido,@Sexo,@Edad,@Departamento,@Ciudad,@valorApoyo,@modalidad,@Fecha)";
                command.Parameters.AddWithValue("@identificacion", persona.Identificacion);
                command.Parameters.AddWithValue("@nombre", persona.Nombre);
                command.Parameters.AddWithValue("@apellido", persona.Apellido);
                command.Parameters.AddWithValue("@sexo", persona.Sexo);
                command.Parameters.AddWithValue("@edad", persona.Edad);
                command.Parameters.AddWithValue("@departamento", persona.Departamento);
                command.Parameters.AddWithValue("@ciudad", persona.Ciudad);
                command.Parameters.AddWithValue("@valorApoyo", persona.valorApoyoRecibido);
                command.Parameters.AddWithValue("@modalidad", persona.ModalidadApoyo);
                command.Parameters.AddWithValue("@fecha", persona.Fecha);
                command.ExecuteNonQuery();
            }
        }

        public List<Persona> Consultar()
        {
            SqlDataReader dataReader;
            _personas.Clear();
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from persona";
                dataReader = command.ExecuteReader();
                if(dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        Persona persona = MapearPersona(dataReader);
                        _personas.Add(persona);
                    }
                }
            }
            return _personas;
        }

        private Persona MapearPersona(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Persona persona = new Persona();
            persona.Identificacion = (string)dataReader["Identificacion"];
            persona.Nombre = (string)dataReader["Nombre"];
            persona.Apellido = (string)dataReader["Apellido"];
            persona.Sexo = (string)dataReader["Sexo"];
            persona.Edad = (int)dataReader["Edad"];
            persona.Departamento = (string)dataReader["Departamento"];
            persona.Ciudad = (string)dataReader["Ciudad"];
            persona.valorApoyoRecibido = (decimal)dataReader["valorApoyo"];
            persona.ModalidadApoyo = (string)dataReader["modalidad"];
            persona.Fecha = (DateTime)dataReader["Fecha"];
            return persona;
        }

        public decimal Total()
        {
            return Consultar().Sum(p =>p.valorApoyoRecibido);
        }

        public int AyudaTotales()
        {
            return Consultar().Count;
        }

        public Persona BuscarPersona(string id)
        {
            return Consultar().Find(p => p.Identificacion == id);
        }
    }
}
