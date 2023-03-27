using Microsoft.Win32;
using MinimalApiPaladino.Migrations;

namespace DemoMinimalApi.Models
{
    public class Master
    {
        public int Id { get; set; }
        public string Dominio { get; set; }
        public string NumUnico { get; set; }
        public string Classificação { get; set; }
        public string? Responsavel { get; set; } = "";
        public string Oficio { get; set; } = "";
        public string? Registro { get; set; } = "";
        public string? Inicio { get; set; } = "";
        public string? Fim { get; set; } = "";
        public string? Protecao { get; set; } = "";
        public string? Curatelado { get; set; } = "";

        public void Atualiza(Master m)
        {
            this.Dominio = m.Dominio;
            this. NumUnico = m.NumUnico;
            this.Classificação = m.Classificação;
            this.Responsavel = m.Responsavel;
            this.Oficio = m.Oficio;
            this.Registro = m.Registro;
            this.Inicio = m.Inicio;
            this.Fim = m.Fim;
            this.Protecao = m.Protecao;
            this.Curatelado = m.Curatelado;

        }

    }

   
}
