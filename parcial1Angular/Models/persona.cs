using System;
using Entity;

public class PersonaInputModel{
    public string Identificacion { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Sexo { get; set; }
    public int Edad { get; set; }
    public string Departamento { get; set; }
    public string Ciudad { get; set; }
    public decimal valorApoyoRecibido { get; set; }
    public string ModalidadApoyo { get; set; }
    public DateTime Fecha { get; set; }
  
    
}
public class PersonaViewModel:PersonaInputModel{
    public PersonaViewModel()
    {
        
    }
    public PersonaViewModel(Persona persona){
        Identificacion = persona.Identificacion;
        Nombre = persona.Nombre;
        Apellido = persona.Apellido;
        Sexo = persona.Sexo;
        Edad = persona.Edad;
        Departamento = persona.Departamento;
        Ciudad = persona.Ciudad;
        valorApoyoRecibido = persona.valorApoyoRecibido;
        ModalidadApoyo = persona.ModalidadApoyo;
        Fecha = persona.Fecha;
    }

}