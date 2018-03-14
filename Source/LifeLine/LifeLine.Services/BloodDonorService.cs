using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeLine.Core.DAO;
using LifeLine.Core.Interfaces;

namespace LifeLine.Services
{
    public class BloodDonorService
    {
        private readonly IBloodDonorRepository _bloodDonorRepository;

        public BloodDonorService(IBloodDonorRepository bloodDonorRepository)
        {
            _bloodDonorRepository = bloodDonorRepository;
        }

        public void AddBloodDonor()
        {
            _bloodDonorRepository.Add(new BloodDonor());
        }

        public int GetBloodDonorById(int id)
        {
            return 1;
        }
    }

    public interface IBloodDonorService
    {
        void AddBloodDonor();

        void UpdateBloodDonor();

        int GetBloodDonorById(int id);

    }
}
