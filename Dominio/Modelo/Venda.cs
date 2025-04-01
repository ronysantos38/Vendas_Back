using System.Numerics;

namespace Dominio.Modelo
{
    public class Venda
    {
        public int Vendaid { get; set; }
        public int Clienteid { get; set; }
        public int FilialId { get; set; }
        public char statusVenda { get; set; }
        public DateTime dataVenda { get; set; }
    }
}
