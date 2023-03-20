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


    }
}
