using CL.CoreShared.ModelViews.Especialidade;

namespace CL.CoreShared.ModelViews
{
    public class NovoMedico
    {
        public string Nome { get; set; }
        public int CRM { get; set; }
        public ICollection<ReferenciaEspecialidade> Especialidades { get; set; }
    }
}