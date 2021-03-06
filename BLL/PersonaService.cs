﻿using System;
using Entity;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class PersonaService
    {
        private readonly ConnectionManager _connection;
        private readonly PersonaRepository _repositorio;

        public PersonaService(string connection)
        {
            _connection = new ConnectionManager(connection);
            _repositorio = new PersonaRepository(_connection);
        }

        public GuardarPersonaResponse Guardar(Persona persona)
        {
            string mensaje = "";
            try
            {
                _connection.Open();
                if (_repositorio.BuscarPersona(persona.Identificacion) == null)
                {
                    if ((_repositorio.Total() + persona.valorApoyoRecibido) > 60000000)
                    {
                        mensaje = "Error: Ayudas superadas. ";
                        _connection.Close();
                        return new GuardarPersonaResponse(mensaje);
                    }
                    else
                    {
                        mensaje = "Se ha guardado la persona. ";
                        _repositorio.GuardarPersona(persona);
                        _connection.Close();
                        return new GuardarPersonaResponse(mensaje,persona);
                    }
                }
                else
                {
                    mensaje = "Error: La persona ya se encuentra registrada. ";
                    _connection.Close();
                    return new GuardarPersonaResponse(mensaje);
                }
            }
            catch(Exception e)
            {
                _connection.Close();
                return new GuardarPersonaResponse($"Error en la aplicacion: {e.Message}");
            }
        }

        public decimal Total()
        {
            decimal total= 0;
            _connection.Open();
            total = _repositorio.Total();
            _connection.Close();
            return total;
        }

        public int AyudasTotales()
        {
            int totalayudas = 0;
            _connection.Open();
            totalayudas = _repositorio.AyudaTotales();
            _connection.Close();
            return totalayudas;
        }

        public PersonaConsultaResponse Consultar()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                _connection.Open();
                personas = _repositorio.Consultar();
                _connection.Close();
                return new PersonaConsultaResponse(personas);
            }
            catch(Exception e)
            {
                _connection.Close();
                return new PersonaConsultaResponse($"Error en la aplicacion al conultar: {e.Message}");
            }
        }
        public class GuardarPersonaResponse
        {
            public GuardarPersonaResponse(string mensaje, Persona persona)
            {
                Error = false;
                Mensaje = mensaje;
                Persona = persona;
            }

            public GuardarPersonaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Persona Persona { get; set; }
        }

        public class PersonaConsultaResponse
        {
            public PersonaConsultaResponse(List<Persona> personas)
            {
                Error = false;
                Personas = personas;
            }

            public PersonaConsultaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Persona> Personas { get; set; }
        }
    }
}
