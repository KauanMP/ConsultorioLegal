using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.CoreShared.ModelViews.Medico;
using CL.CoreShared.ModelViews;

namespace CL.Manager.Interfaces
{
    public interface IMedicoManager
    {
        Task<IEnumerable<MedicoView>> GetAllMedicosAsync();
        Task<MedicoView> GetMedicoByIdAsync(int id);
        Task<MedicoView> InsertMedicoAsync(NovoMedico novoMedico);
        Task<MedicoView> UpdateMedicoAsync(AlteraMedico alteraMedico);
        Task DeleteMedicoAsync(int id);
    }
}