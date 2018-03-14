using System.Collections.Generic;
using LifeLine.Core.DAO;

namespace LifeLine.Core.Interfaces
{
    public interface IBloodDonorRepository
    {
        void Add(BloodDonor b);
        void Edit(BloodDonor b);
        void Remove(string bloodDonorId);
        IEnumerable<BloodDonor> GetBloodDonors();
        BloodDonor FindById(string bloodDonorId);  
    }
}
