using System;

namespace Grau_A
{
    public class Reserva
    {
        public int diaInicio{get; set;}       
        public int diaFim{get; set;}       
        public string cliente{get; set;}        
        public Quarto quarto{get; set;}        
        public char status{get; set;} //(A/C/I/O)

        public Reserva(int dataIni, int dataFim, string cliente, Quarto quarto)
        {
            diaInicio = dataIni;
            diaFim = dataFim;
            this.cliente = cliente;
            this.quarto = quarto;
            this.status = 'A';
        }
    }
}