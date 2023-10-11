using CL.Core.Domains;
using CL.Manager.Interfaces;
using CL.WebApi.Context;
using Microsoft.EntityFrameworkCore;

namespace CL.WebApi.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly CLContext context;
        public MedicoRepository(CLContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Medico>> GetAllMedicosAsync()
        {
            return await context.Medicos.Include(p => p.Especialidades).AsNoTracking().ToListAsync();
        }

        public async Task<Medico> GetMedicoByIdAsync(int id)
        {
            return await context.Medicos.Include(p => p.Especialidades).AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Medico> InsertMedicoAsync(Medico medico)
        {
            await InsertMedicoEspecialidades(medico);
            await context.Medicos.AddAsync(medico);
            await context.SaveChangesAsync();
            return medico;
        }

        private async Task InsertMedicoEspecialidades(Medico medico)
        {
            var especialidadesConsultadas = new List<Especialidade>();
            // foreach (var especialidade in medico.Especialidades)
            // {
            //     var updatedEspecialidade = await context.Especialidades.AsNoTracking().FirstAsync(p => p.Id == especialidade.Id);
            //     context.Entry(especialidade).CurrentValues.SetValues(updatedEspecialidade);
            // }
            foreach (var especialidade in medico.Especialidades)
            {
                var especialidadeConsultada = await context.Especialidades.FindAsync(especialidade.Id);
                especialidadesConsultadas.Add(especialidadeConsultada);
            }
            medico.Especialidades = especialidadesConsultadas;
        }

        public async Task<Medico> UpdateMedicosAsync(Medico medico)
        {
            var updatedMedico = await context.Medicos.Include(p => p.Especialidades).SingleOrDefaultAsync(p => p.Id == medico.Id);

            if (updatedMedico == null)
            {
                return null;
            }

            context.Entry(updatedMedico).CurrentValues.SetValues(medico);
            await UpdateMedicoEspecialidades(medico, updatedMedico);

            await context.SaveChangesAsync();

            return updatedMedico;
        }

        private async Task UpdateMedicoEspecialidades(Medico medico, Medico updatedMedico)
        {
            updatedMedico.Especialidades.Clear();
            foreach (var especialidade in medico.Especialidades)
            {
                var consultedEspecialidade = await context.Especialidades.FindAsync(especialidade.Id);
                updatedMedico.Especialidades.Add(consultedEspecialidade);
            }
        }

        public async Task<Medico> DeleteMedicoAsync(int id)
        {
            var consultedMedico = await context.Medicos.FindAsync(id);
            if (consultedMedico == null)
            {
                return null;
            }

            var medicoRemovido = context.Medicos.Remove(consultedMedico);
            await context.SaveChangesAsync();
            return medicoRemovido.Entity;
        }
    }
}