using AutoMapper;
using CL.Core.Domains;
using CL.CoreShared.ModelViews;
using CL.CoreShared.ModelViews.Medico;
using CL.Manager.Interfaces;

namespace CL.Manager.Implementation
{
    public class MedicoManager : IMedicoManager
    {
        private readonly IMedicoRepository medicoRepository;
        private readonly IMapper mapper;

        public MedicoManager(IMedicoRepository medicoRepository, IMapper mapper)
        {
            this.medicoRepository = medicoRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MedicoView>> GetAllMedicosAsync()
        {
            return mapper.Map<IEnumerable<Medico>, IEnumerable<MedicoView>>(await medicoRepository.GetAllMedicosAsync());
        }

        public async Task<MedicoView> GetMedicoByIdAsync(int id)
        {
            return mapper.Map<MedicoView>(await medicoRepository.GetMedicoByIdAsync(id));
        }

        public async Task<MedicoView> InsertMedicoAsync(NovoMedico novoMedico)
        {
            var medico = mapper.Map<Medico>(novoMedico);
            return mapper.Map<MedicoView>(await medicoRepository.InsertMedicoAsync(medico));
        }

        public async Task<MedicoView> UpdateMedicoAsync(AlteraMedico alteraMedico)
        {
            var medico = mapper.Map<Medico>(alteraMedico);
            return mapper.Map<MedicoView>(await medicoRepository.UpdateMedicosAsync(medico));
        }

        public async Task DeleteMedicoAsync(int id)
        {
            await medicoRepository.DeleteMedicoAsync(id);
        }
    }
}