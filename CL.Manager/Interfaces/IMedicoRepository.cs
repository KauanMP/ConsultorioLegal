using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.Core.Domains;

namespace CL.Manager.Interfaces
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetAllMedicosAsync();
        Task<Medico> GetMedicoByIdAsync(int id);
        Task<Medico> InsertMedicoAsync(Medico medico);
        Task<Medico> UpdateMedicosAsync(Medico medico);
        Task<Medico> DeleteMedicoAsync(int id);

    }
}