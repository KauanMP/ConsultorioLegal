using CL.CoreShared.ModelViews.Especialidade;

namespace CL.CoreShared.ModelViews.Medico
{
    public class MedicoView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CRM { get; set; }
        
        public ICollection<EspecialidadeView> Especialidades { get; set; }
    }
}